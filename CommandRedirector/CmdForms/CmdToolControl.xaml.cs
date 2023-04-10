using CommandRedirector.CmdForms.Helpers;
using CommandRedirector.CmdForms.Model;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using stdole;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.IO.Packaging;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CommandRedirector.CmdForms
{
    /// <summary>
    /// Interaction logic for CmdToolControl.
    /// </summary>
    public partial class CmdToolControl : UserControl
    {
        public static List<CommandInfo> commandInfos = new List<CommandInfo>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CmdToolControl"/> class.
        /// </summary>
        public CmdToolControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private async void btnExecuteCmd_Click(object sender, RoutedEventArgs e)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            var cmdToolCommand = CmdToolCommand.Instance;

            CommandHelper.CloseToolWindow(cmdToolCommand);
        }

        private void txtCommand_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            lstCommand.Items.Clear();


        }

        private void MyToolWindow_Loaded(object sender, RoutedEventArgs e)
        {
            commandInfos = CommandHelper.GetAllCommands();
        }
    }
}