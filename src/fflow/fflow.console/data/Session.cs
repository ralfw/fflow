using System;
using CLAP;
using System.IO;
using Newtonsoft.Json;

namespace fflow.console
{
	public class Session {
		public string WorkflowPath {get;set;}
		public string Stationname { get; set; }

		public void Update(string workflowpath, string stationname) {
			if (!string.IsNullOrWhiteSpace(workflowpath) && this.WorkflowPath != workflowpath)
				this.WorkflowPath = workflowpath;
			if (!string.IsNullOrEmpty(stationname) && this.Stationname != stationname)
				this.Stationname = stationname;
		}
	}
	
}