using System;
using System.Linq;
using System.Diagnostics;
using CLAP;
using System.IO;

namespace fflow.console
{
	public class ProcessProvider {
		public void Open_document(string documentpath) {
			var pi = new ProcessStartInfo ("open", documentpath);
			var p = Process.Start (pi);
			p.WaitForExit ();
			Log.Current.Append (documentpath, "opened");
		}
	}
}