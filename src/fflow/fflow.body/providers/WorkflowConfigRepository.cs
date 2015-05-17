using System;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using fflow.body.data;

namespace fflow.body.providers
{
	public class WorkflowConfigRepository {
		public WorkflowConfig Load_workflow_config(string path) {
			var flowconfigpath = Path.Combine (path, ".fflow.json");
			if (!File.Exists (flowconfigpath)) return new WorkflowConfig ();

			var flowconfigjson = File.ReadAllText (flowconfigpath);
			return JsonConvert.DeserializeObject<WorkflowConfig> (flowconfigjson);
		}
	}
}