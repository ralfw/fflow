using System;
using System.Linq;
using System.Diagnostics;
using CLAP;
using System.IO;

namespace fflow.console
{
	interface ILog {
		void Append (string documentpath, string @event, string info = "");
		string Logfilepath_for (string documentpath);
	}

	class Log : ILog {
		public static ILog Current = new Log ();


		public void Append(string documentpath, string @event, string info = "") {
			var logentry = string.Format ("{0:O}\t{1}\t{2}\t{3}", DateTime.Now, Environment.UserName, @event, info);
			File.AppendAllLines (Logfilepath_for(documentpath), new[]{ logentry });
		}


		public string Logfilepath_for(string documentpath) {
			return documentpath + ".log";
		}
	}
}