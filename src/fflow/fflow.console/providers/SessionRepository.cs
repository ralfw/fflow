using System;
using CLAP;
using System.IO;
using Newtonsoft.Json;

namespace fflow.console
{
	public class SessionRepository {
		const string SESSION_FILENAME = "session.json";

		public Session Update(string workflowpath, string stationname) {
			if (!File.Exists (SESSION_FILENAME)) {
				var session = new Session{ WorkflowPath = workflowpath, Stationname = stationname };
				Store (session);
				return session;
			} else {
				var session = Load ();
				session.Update (workflowpath, stationname);
				Store (session);
				return session;
			}
		}


		private void Store(Session session) {
			var sessionjson = JsonConvert.SerializeObject (session);
			File.WriteAllText (SESSION_FILENAME, sessionjson);
		}


		private Session Load() {
			var sessionjson = File.ReadAllText (SESSION_FILENAME);
			return JsonConvert.DeserializeObject<Session> (sessionjson);
		}
	}
}