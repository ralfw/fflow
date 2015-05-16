using System;
using System.Linq;
using System.Diagnostics;
using CLAP;
using System.IO;

namespace fflow.console
{
		
	public class Head {
		Session session;

		public Head(Session session) {
			this.session = session;
		}


		[Verb]
		public void Edit(
			[Aliases("p,path,w,wf,workflow")] string workflowpath,
			[Aliases("s,station,step")] string stationname,
			[Aliases("d,doc,docname,f,file,filename"),Required] string documentfilename
		){
			workflowpath = this.session.Switch_to_workflow (workflowpath);
			stationname = this.session.Switch_to_station (stationname);

			var documentpath = Locate_document (workflowpath, stationname, documentfilename);

			documentpath = Pull_document (documentpath);

			Open_document (documentpath);
		}


		public string Locate_document(string workflowpath, string stationname, string documentfilename) {
			var stationpath = Directory.GetDirectories(workflowpath, "*.*", SearchOption.AllDirectories)
									   .First(dp => dp.EndsWith(stationname, StringComparison.CurrentCultureIgnoreCase));
			return Directory.GetFiles (stationpath, "*.*", SearchOption.AllDirectories)
							.First (fp => fp.EndsWith (documentfilename, StringComparison.CurrentCultureIgnoreCase));
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
				Log (wipdocumentpath, "pull");
				return wipdocumentpath;
			}
		}


		public void Open_document(string documentpath) {
			var pi = new ProcessStartInfo ("open", documentpath);
			var p = Process.Start (pi);
			p.WaitForExit ();
			Log (documentpath, "open");
		}


		public void Log(string documentpath, string info) {
			var logentry = string.Format ("{0:O}\t{1}\t{2}", DateTime.Now, Environment.UserName, info);
			var logfilepath = documentpath + ".log";
			File.AppendAllLines (logfilepath, new[]{ logentry });
		}

	
		[Verb]
		public void Push(
			[Aliases("p,path,w,wf,workflow")] string workflowpath,
			[Aliases("s,station,step")] string stationname,
			[Aliases("d,doc,docname,f,file,filename"),Required] string documentfilename,
			[Aliases("a,act"),Required] string action
		){
			workflowpath = this.session.Switch_to_workflow (workflowpath);
			stationname = this.session.Switch_to_station (stationname);

			Console.WriteLine ("push: {0},{1},{2},{3}", workflowpath,stationname,documentfilename,action);	
		}
	}
}