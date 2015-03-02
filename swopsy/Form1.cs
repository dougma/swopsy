using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace swopsy
{

    public partial class Form1 : Form
    {
        int _port = 8765;
        int _delay;
        Server _server;
        Statistic _requests = new Statistic("requets");
        Statistic _bundles = new Statistic("bundles");
        Statistic _biggestBundle = new Statistic("biggest bundle");

        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = new List<Statistic>() { _requests, _bundles, _biggestBundle };
            trackBarDelay.ValueChanged += (sender, e) =>
            {
                labelDelay.Text = String.Format("delay per bundle {0}ms", trackBarDelay.Value);
                _delay = trackBarDelay.Value;
            };
            trackBarDelay.Value = 1000;

            _server = new Server(_port, () => TimeSpan.FromMilliseconds(_delay), HandleBundle);
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

            SwappingProxy.HandleBundle(b, checkBoxReverse.Checked);
        }
    }
}
