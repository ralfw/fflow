using System;
using fflow.body.providers;
using fflow.body.data;

namespace fflow.body
{
	public class Body
	{
		WorkflowProvider wfprov;
		ProcessProvider process;
		WorkflowConfigRepository configrepo;
		Executor exec;

		public Body (WorkflowProvider wfprov, 
					 ProcessProvider process, WorkflowConfigRepository configrepo,
					 Executor exec)
		{
			this.exec = exec;
			this.configrepo = configrepo;
			this.process = process;
			this.wfprov = wfprov;
		}


		public StationInfo[] Get_stations(string workflowpath) {
			throw new NotImplementedException ();	
		}

		public StationDetails[] Get_station_documents(string workflowpath, string stationname) {
			throw new NotImplementedException ();
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

			documentpath = this.exec.Run (workflowpath, documentpath, actionname, config.Actions);

			return new DocumentInfo { 
				Documentpath = documentpath,
				Loglines = Log.Current.Entries_for(documentpath)
			};
		}
	}


	public struct StationDetails {
		public string Stationname;
		public string[] InboxDocuments;
		public string[] WIPDocuments;
		public string[] Actionnames;
	}


	public struct StationInfo {
		public string Stationname;
	}
		
	public struct DocumentInfo {
		public string Documentpath;
		public string[] Loglines;
	}
}