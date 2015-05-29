using System;
using System.Linq;
using System.IO;
using fflow.body.providers;
using fflow.body.data;

namespace fflow.body
{
    public class Body : IBody
    {
		WorkflowProvider wfprov;
		ProcessProvider process;
		WorkflowConfigRepository configrepo;
		ActionCommands acmds;

		public Body (WorkflowProvider wfprov, 
					 ProcessProvider process, WorkflowConfigRepository configrepo,
					 ActionCommands acmds)
		{
			this.acmds = acmds;
			this.configrepo = configrepo;
			this.process = process;
			this.wfprov = wfprov;
		}


		public StationInfo[] Get_stations(string workflowpath) {
			var stationnames = this.wfprov.Collect_stationnames (workflowpath);
			return stationnames.OrderBy(n => n)
							   .Select (n => new StationInfo{ Name = n }).ToArray ();
		}


		public StationDetails Get_station_documents(string workflowpath, string stationname) {
			var stationpath = this.wfprov.Locate_station (workflowpath, stationname);
			var inboxdocumentpaths = this.wfprov.Collect_inbox_documents (stationpath);
			var wipdocumentpaths = this.wfprov.Collect_wip_documents (stationpath);
			var config = this.configrepo.Load_workflow_config (stationpath);
			return new StationDetails{ 
				Name = stationname,
				InboxDocumentnames = inboxdocumentpaths.Select(Path.GetFileName).ToArray(),
				WIPDocumentnames = wipdocumentpaths.Select(Path.GetFileName).ToArray(),
				Actionnames = config.Actions.Select(a => a.Name).ToArray()
			};
		}


		public DocumentInfo Edit(string workflowpath, string stationname, string documentfilename) {
			var documentpath = this.wfprov.Locate_document (workflowpath, stationname, documentfilename);
			documentpath = this.wfprov.Pull_document (documentpath);
			this.process.Open_document (documentpath);
			return new DocumentInfo{ 
				Documentpath = documentpath,
				Loglines = Log.Current.Entries_for(documentpath)
			};
		}

		public DocumentInfo Push(string workflowpath, string stationname, string documentfilename, string actionname) {
			var documentpath = this.wfprov.Locate_document (workflowpath, stationname, documentfilename);

			var stationpath = this.wfprov.Locate_station (workflowpath, stationname);
			var config = this.configrepo.Load_workflow_config (stationpath);

			documentpath = this.acmds.Execute (workflowpath, documentpath, actionname, config.Actions);

			return new DocumentInfo { 
				Documentpath = documentpath,
				Loglines = Log.Current.Entries_for(documentpath)
			};
		}
	}		
}