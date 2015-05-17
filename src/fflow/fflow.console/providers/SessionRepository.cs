using System;
using System.IO;
using Newtonsoft.Json;
using fflow.body.data;
using fflow.console.data;

namespace fflow.console.providers
{
	public class SessionRepository {
		const string SESSION_FILENAME = "session.json";


		public Session Update(string workflowpath) {
			var session = new Session{ WorkflowPath = workflowpath, Stationname = "" };
			Store (session);
			return session;
		}

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