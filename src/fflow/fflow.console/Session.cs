using System;
using CLAP;
using System.IO;

namespace fflow.console
{

	public class Session {
		public string Switch_to_workflow(string workflowpath) {
			return Switch ("fflow.session.workflowpath.txt", workflowpath);

		}

		public string Switch_to_station(string stationname) {
			return Switch ("fflow.session.stationname.txt", stationname);	
		}

		private string Switch(string sessionfilename, string data) {
			if (string.IsNullOrWhiteSpace(data))
			{
				return File.ReadAllText (sessionfilename);
			}
			else
			{
				File.WriteAllText (sessionfilename, data);
				return data;
			}
		}
	}
}