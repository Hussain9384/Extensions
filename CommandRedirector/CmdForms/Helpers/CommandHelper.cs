using CommandRedirector.CmdForms.Model;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandRedirector.CmdForms.Helpers
{
    internal class CommandHelper
    {
        public static DTE _DTE = null;

        public static List<CommandInfo> GetAllCommands()
        {

            List<CommandInfo> commandInfos = new List<CommandInfo>();

            DTE dte = getDTEObject();

            foreach (var item in dte.Commands)
            {
                var command = item as Command;
                commandInfos.Add(new CommandInfo
                {
                    Name = command.Name,
                    GUID = command.Guid,
                    Id = command.ID
                });
            }

            return commandInfos;
        }

        private static DTE getDTEObject()
        {
            if(_DTE != null) return _DTE;

            DTE dte = ServiceProvider.GlobalProvider.GetService(typeof(DTE)) as DTE;

            return ServiceProvider.GlobalProvider.GetService(typeof(DTE)) as DTE;
        }

        public static void CloseToolWindow(CmdToolCommand cmdToolCommand)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var toolWindow = cmdToolCommand.package.FindToolWindow(typeof(CmdTool), 0, true);

            // Close the tool window using the IVsWindowFrame.Hide method
            var windowFrame = (IVsWindowFrame)toolWindow.Frame;

            windowFrame.CloseFrame((uint)__FRAMECLOSE.FRAMECLOSE_PromptSave);
        }

        public static void Execute(string guid, int id)
        {

            DTE dte = getDTEObject();

            dte.Commands.Raise(guid, id, null, null);
        }
    }
}
