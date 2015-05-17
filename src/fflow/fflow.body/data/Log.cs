using System;
using System.Linq;
using System.Diagnostics;
using System.IO;

namespace fflow.body.data
{
	interface ILog {
		void Append_to (string documentpath, string @event, string info = "");
		string[] Entries_for (string documentpath);
		string Logfilepath_for (string documentpath);
	}

	class Log : ILog {
		public static ILog Current = new Log ();


		public void Append_to(string documentpath, string @event, string info = "") {
			var logentry = string.Format ("{0:O}\t{1}\t{2}\t{3}", DateTime.Now, Environment.UserName, @event, info);
			File.AppendAllLines (Logfilepath_for(documentpath), new[]{ logentry });
		}


		public string[] Entries_for(string documentpath) {
			return File.ReadAllLines (Logfilepath_for(documentpath));
		}


		public string Logfilepath_for(string documentpath) {
			return documentpath + ".log";
		}
	}
}