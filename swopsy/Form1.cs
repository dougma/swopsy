using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace swopsy
{

    public partial class Form1 : Form
    {
        int _port = 8765;
        Func<int> _delay;
        Func<int> _requestWait;
        Server _server;
        Statistic _requests = new Statistic("requets");
        Statistic _bundles = new Statistic("bundles");
        Statistic _biggestBundle = new Statistic("biggest bundle");

        private Func<int> InitTrackBar(TrackBar tb, Label lb, int initialValue, string msg)
        {
            int value = 0;
            tb.ValueChanged += (sender, e) =>
            {
                lb.Text = String.Format(msg, tb.Value);
                value = tb.Value;
            };
            tb.Value = initialValue;
            return () => value;
        }

        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = new List<Statistic>() { _requests, _bundles, _biggestBundle };

            _delay = InitTrackBar(trackBarDelay, labelDelay, 1000, "delay per bundle {0}ms");
            _requestWait = InitTrackBar(trackBarRequestWait, labelRequestWait, 20, "request wait {0}ms");

            _server = new Server(_port, () => TimeSpan.FromMilliseconds(checkBoxActive.Checked ? _delay() : 0), HandleBundle);
            this.FormClosing += (sender, e) =>
            {
                _server.Stop();
            };

            labelPort.Text = String.Format("port {0}", _port);
        }

        private void HandleBundle(Bundle b)
        {
            _bundles.Value++;
            _biggestBundle.Value = Math.Max(b.Count, _biggestBundle.Value);
            _requests.Value += b.Count;

            Action a = dataGridView1.Refresh;
            dataGridView1.Invoke((Delegate) a);

            SwappingProxy.HandleBundle(b, 
                checkBoxActive.Checked && checkBoxReverse.Checked, 
                TimeSpan.FromMilliseconds(checkBoxActive.Checked ? _requestWait() : 0));
        }
    }
}
