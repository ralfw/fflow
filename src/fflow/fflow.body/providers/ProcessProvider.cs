using System;
using System.Linq;
using System.Diagnostics;
using System.IO;
using fflow.body.data;

namespace fflow.body.providers
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