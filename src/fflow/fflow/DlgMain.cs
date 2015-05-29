using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fflow.body;

namespace fflow
{
    public partial class DlgMain : Form
    {
        private readonly IBody _body;
        private string _workflowpath;
        private string _stationname;

        public DlgMain(IBody body)
        {
            _body = body;
            InitializeComponent();
        }


        private void mnuOpenFlow_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.SelectedPath = Environment.CurrentDirectory;
            if (this.folderBrowserDialog1.ShowDialog() != DialogResult.OK) return;

            _workflowpath = this.folderBrowserDialog1.SelectedPath;
            this.Text = string.Format("Folder Flow [{0}]", Path.GetFileName(_workflowpath));

            var stations = _body.Get_stations(_workflowpath);

            this.cboStations.Items.Clear();
            stations.ToList().ForEach(s => this.cboStations.Items.Add(s.Name));
        }


        private void cboStations_SelectedIndexChanged(object sender, EventArgs e)
        {
            _stationname = this.cboStations.SelectedItem.ToString();

            var docs = _body.Get_station_documents(_workflowpath, _stationname);

            this.lstInbox.Items.Clear();
            docs.InboxDocumentnames.ToList().ForEach(docname => this.lstInbox.Items.Add(docname));

            this.lstWIP.Items.Clear();
            docs.WIPDocumentnames.ToList().ForEach(docname => this.lstWIP.Items.Add(docname));

            this.contextMenuStrip1.Items.Clear();
            foreach (var an in docs.Actionnames)
            {
                var mnuaction = this.contextMenuStrip1.Items.Add(an);
                mnuaction.Click += mnuAction_Click;
            }
        }


        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstInbox_DoubleClick(object sender, EventArgs e)
        {
            var docname = ((ListBox)sender).SelectedItem.ToString();

            var docinfo = _body.Edit(_workflowpath, _stationname, docname);

            this.lstLog.Items.Clear();
            docinfo.Loglines.ToList().ForEach(ll => this.lstLog.Items.Add(ll));
        }

        private void lstWIP_DoubleClick(object sender, EventArgs e)
        {
            lstInbox_DoubleClick(sender, e);
        }


        private void mnuAction_Click(object sender, EventArgs e)
        {
            var actionname = ((ToolStripMenuItem) sender).Text;
            MessageBox.Show("action: " + actionname);
        }
    }
}
