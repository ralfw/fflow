using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using fflow.body;
using fflow.body.providers;

namespace fflow
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var wfprov = new WorkflowProvider();
            var process = new ProcessProvider();
            var configrepo = new WorkflowConfigRepository();
            var acmds = new ActionCommands();
            var body = new Body(wfprov, process, configrepo, acmds);
            var dlg = new DlgMain(body);

            Application.Run(dlg);
        }
    }
}
