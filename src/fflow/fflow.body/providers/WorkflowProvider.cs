using System;
using System.Linq;
using System.Diagnostics;
using System.IO;
using fflow.body.data;

namespace fflow.body.providers
{
	public class WorkflowProvider {
		const string WIP_FOLDERNAME = "wip";


		public string Locate_document(string workflowpath, string stationname, string documentfilename) {
			var stationpath = Locate_station (workflowpath, stationname);
			return Directory.GetFiles (stationpath, "*.*", SearchOption.AllDirectories)
				.First (fp => fp.EndsWith (documentfilename, StringComparison.CurrentCultureIgnoreCase));
		}


		public string[] Collect_stationnames(string workflowpath) {
			return Directory.GetDirectories (workflowpath, "*.*", SearchOption.AllDirectories)
							.Where (dp => dp.EndsWith (WIP_FOLDERNAME))
							.Select (dp => Path.GetFileName (dp.Substring (0, dp.Length - WIP_FOLDERNAME.Length - 1)))
							.ToArray ();
		}


		public string Locate_station(string workflowpath, string stationname) {
			return Directory.GetDirectories(workflowpath, "*.*", SearchOption.AllDirectories)
							.First(dp => dp.EndsWith(stationname, StringComparison.CurrentCultureIgnoreCase));
		}


		public string[] Collect_inbox_documents(string stationpath) {
			return Directory.GetFiles (stationpath, "*.*")
							.Where (dp => dp != Log.Current.Logfilepath_for (dp))
							.Where(dp => !Path.GetFileName(dp).StartsWith("."))
							.ToArray ();
		}

		public string[] Collect_wip_documents(string stationpath) {
			return Directory.GetFiles (Path.Combine(stationpath, WIP_FOLDERNAME), "*.*")
				.Where (dp => dp != Log.Current.Logfilepath_for (dp))
				.Where(dp => !Path.GetFileName(dp).StartsWith("."))
				.ToArray ();
		}


		public string Pull_document(string documentpath) {
			if (Path.GetDirectoryName (documentpath).EndsWith (WIP_FOLDERNAME))
				return documentpath;
			else {
				var wippath = Path.Combine(Path.GetDirectoryName (documentpath), WIP_FOLDERNAME);
				Directory.CreateDirectory (wippath);

				var wipdocumentpath = Path.Combine (wippath, Path.GetFileName (documentpath));
				File.Move (documentpath, wipdocumentpath);
				var stationname = Path.GetDirectoryName (documentpath).Split (new[]{ Path.DirectorySeparatorChar }).Last ();
				Log.Current.Append_to (wipdocumentpath, "pulled", stationname);
				return wipdocumentpath;
			}
		}


		public string Push_document(string documentpath, string workflowpath, string stationname) {
			var stationpath = Locate_station(workflowpath, stationname);

			var newDocumentpath = Path.Combine (stationpath, Path.GetFileName (documentpath));
			File.Move (documentpath, newDocumentpath);

			File.Move (Log.Current.Logfilepath_for(documentpath), Log.Current.Logfilepath_for(newDocumentpath));

			Log.Current.Append_to (newDocumentpath, "pushed", stationname);

			return newDocumentpath;
		}
	}
}