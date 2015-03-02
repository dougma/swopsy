using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace swopsy
{
    class Bundle
    {
        public struct Connection
        {
            public HttpListenerContext Context;
            public DateTime Received;
        }

        private List<Connection> _received = new List<Connection>();

        public void Add(HttpListenerContext ctx)
        {
            _received.Add(new Connection()
            {
                Context = ctx,
                Received = DateTime.Now
            });
        }

        public int Count
        {
            get { return _received.Count; }
        }

        public bool Empty
        {
            get { return _received.Count == 0; }
        }

        public IEnumerable<Connection> Connections
        {
            get { return _received; }
        }
    }

    class Server
    {
        HttpListener _listener = new HttpListener();
        Func<TimeSpan> _delay;
        Action<Bundle> _action;
        Task<HttpListenerContext> _getContext;

        public Server(int port, Func<TimeSpan> delayFromFirstConnection, Action<Bundle> action)
        {
            var prefix = string.Format("http://*:{0}/", port);

            _delay = delayFromFirstConnection;
            _action = action;
            _listener.Prefixes.Add(prefix);
            _listener.Start();
            Loop();
        }

        public void Stop()
        {
            _listener.Stop();
        }

        private async Task<Bundle> NextBundle(TimeSpan ts)
        {
            var bundle = new Bundle();
            Task delay = null;

            while (true)
            {
                if (_getContext == null)
                    _getContext = _listener.GetContextAsync();

                var task = await Task.WhenAny(delay == null ? new Task[] { _getContext } : new Task[] { delay, _getContext }); 
                if (!task.IsCompleted)
                    return null;

                if (task == delay)
                    return bundle;

                Debug.Assert(task == _getContext);
                bundle.Add(_getContext.Result);
                _getContext = null;
                if (delay == null)
                    delay = Task.Delay(ts);
            }
        }

        private void Loop()
        {
            NextBundle(_delay())
                .ContinueWith(task => {
                    if (null != task.Result)
                    {
                        _action(task.Result);
                        Loop();
                    }
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
        }
    }

    class SwappingProxy
    {
        public static void HandleBundle(Bundle b, bool reverse)
        {
            var cs = reverse ? b.Connections.Reverse() : b.Connections;
            foreach (var c in cs)
            {
                Proxy.Do(c.Context).Wait();
            }
        }
    }

    class Proxy
    {
        public static async Task Do(HttpListenerContext p)
        {
            // p_ proxy related (us)
            // o_ origin related (the server we are requesting from)

            using (var http = new HttpClient())
            using (var o_req = new HttpRequestMessage(new HttpMethod(p.Request.HttpMethod), p.Request.RawUrl))
            {
                o_req.Headers.CopyFrom(p.Request.Headers);
                if (p.Request.HasEntityBody)
                {
                    o_req.Content = new StreamContent(p.Request.InputStream);
                }

                var o_resp = await http.SendAsync(o_req, HttpCompletionOption.ResponseHeadersRead);

                p.Response.Headers.CopyFrom(o_resp.Headers);
                p.Response.ContentType = o_resp.Content.Headers.ContentType.ToString();
                if (o_resp.Content.Headers.ContentLength.HasValue)
                    p.Response.ContentLength64 = o_resp.Content.Headers.ContentLength.Value;
                if (o_resp.Content.Headers.ContentEncoding.Any())
                    p.Response.AddHeader("Content-Encoding", o_resp.Content.Headers.ContentEncoding.First());
                if (o_resp.Content.Headers.ContentEncoding.Count > 1)
                {
                    // what does this mean?
                }
                await o_resp.Content.CopyToAsync(p.Response.OutputStream);
            }
        }
    }

    public static class Extension
    {
        public static void CopyFrom(this System.Net.Http.Headers.HttpRequestHeaders to, System.Collections.Specialized.NameValueCollection from)
        {
            for (var i = 0; i < from.Count; i++)
            {
                to.TryAddWithoutValidation(from.GetKey(i), from.GetValues(i));
            }
        }

        static Lazy<Action<WebHeaderCollection, string, string>> AddWithoutValidate = new Lazy<Action<WebHeaderCollection, string, string>>(() =>
        {
            var method = typeof(WebHeaderCollection).GetMethod("AddWithoutValidate", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            Action<WebHeaderCollection, string, string> result = (o, n, v) => method.Invoke(o, new object[2]{ n, v });
            return result;
        });

        public static void CopyFrom(this WebHeaderCollection to, System.Net.Http.Headers.HttpResponseHeaders from)
        {
            foreach (var nv in from)
                foreach (var v in nv.Value)
                    AddWithoutValidate.Value(to, nv.Key, v);
        }

    }


}
