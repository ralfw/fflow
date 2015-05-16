using System;
using System.Linq;
using System.Diagnostics;
using CLAP;
using System.IO;

namespace fflow.console
{
	public class FilesystemProvider {
		public string Locate_document(string workflowpath, string stationname, string documentfilename) {
			var stationpath = Locate_station (workflowpath, stationname);
			return Directory.GetFiles (stationpath, "*.*", SearchOption.AllDirectories)
				.First (fp => fp.EndsWith (documentfilename, StringComparison.CurrentCultureIgnoreCase));
		}

		public string Locate_station(string workflowpath, string stationname) {
			return Directory.GetDirectories(workflowpath, "*.*", SearchOption.AllDirectories)
							.First(dp => dp.EndsWith(stationname, StringComparison.CurrentCultureIgnoreCase));
		}

		public string Pull_document(string documentpath) {
			const string WIP_FOLDERNAME = "wip";

			if (Path.GetDirectoryName (documentpath).EndsWith (WIP_FOLDERNAME))
				return documentpath;
			else {
				var wippath = Path.Combine(Path.GetDirectoryName (documentpath), WIP_FOLDERNAME);
				Directory.CreateDirectory (wippath);

				var wipdocumentpath = Path.Combine (wippath, Path.GetFileName (documentpath));
				File.Move (documentpath, wipdocumentpath);
				var stationname = Path.GetDirectoryName (documentpath).Split (new[]{ Path.DirectorySeparatorChar }).Last ();
				Logger.Current.Write (wipdocumentpath, "pulled", stationname);
				return wipdocumentpath;
			}
		}
	}
	
}