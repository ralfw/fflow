using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using fflow.body;
using fflow.body.data;

namespace fflow.gui.tests
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var body = new FakeBody();
            var dlg = new DlgMain(body);

            Application.Run(dlg);
        }
    }

    class FakeBody : IBody
    {
        public StationInfo[] Get_stations(string workflowpath)
        {
            var wfname = Path.GetFileName(workflowpath);
            var stations = new List<StationInfo>();
            for(var i=0; i<5; i++)
                stations.Add(new StationInfo{Name = wfname + i.ToString()});
            return stations.ToArray();
        }

        public StationDetails Get_station_documents(string workflowpath, string stationname)
        {
            var wfname = Path.GetFileName(workflowpath);

            var inboxdocnames = new List<string>();
            for (var i = 0; i < 5; i++)
                inboxdocnames.Add(string.Format("{0}.{1}.inbox-{2}", wfname, stationname, i));
            var wipdocnames = new List<string>();
            for (var i = 0; i < 3; i++)
                wipdocnames.Add(string.Format("{0}.{1}.wip-{2}", wfname, stationname, i));

            return new StationDetails {
                Name = wfname,
                Actionnames = new []{wfname+"1", wfname+"2"},
                InboxDocumentnames = inboxdocnames.ToArray(),
                WIPDocumentnames = wipdocnames.ToArray()
            };
        }

        public DocumentInfo Edit(string workflowpath, string stationname, string documentfilename)
        {
            MessageBox.Show("Edit: " + documentfilename);

            return new DocumentInfo
            {
                Documentpath = workflowpath + "/" + stationname + "/" + documentfilename,
                Loglines = new[] {documentfilename + "1", documentfilename + "2"}
            };
        }

        public DocumentInfo Push(string workflowpath, string stationname, string documentfilename, string actionname)
        {
            return new DocumentInfo
            {
                Documentpath = workflowpath + "/" + stationname + "/" + documentfilename,
                Loglines = new[] { documentfilename + "1", documentfilename + "2", actionname + " " + documentfilename }
            };
        }
    }
}
