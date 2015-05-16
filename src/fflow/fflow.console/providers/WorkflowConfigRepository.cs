using System;
using System.Linq;
using System.Diagnostics;
using CLAP;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace fflow.console
{
	public class WorkflowConfigRepository {
		public WorkflowConfig Load_workflow_config(string stationpath) {
			var flowconfigpath = Path.Combine (stationpath, ".fflow.json");
			if (!File.Exists (flowconfigpath)) return new WorkflowConfig ();

			var flowconfigjson = File.ReadAllText (flowconfigpath);
			return JsonConvert.DeserializeObject<WorkflowConfig> (flowconfigjson);
		}
	}
}