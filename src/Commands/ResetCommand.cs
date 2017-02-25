using EnvDTE;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.ComponentModel.Design;

namespace ResetZoom
{
    internal sealed class ResetCommand
    {
        private readonly Package _package;

        private ResetCommand(Package package)
        {
            _package = package;

            if (ServiceProvider.GetService(typeof(IMenuCommandService)) is OleMenuCommandService commandService)
            {
                var menuCommandID = new CommandID(PackageGuids.guidPackageCmdSet, PackageIds.ResetCommand);
                var menuItem = new MenuCommand(Execute, menuCommandID);
                commandService.AddCommand(menuItem);
            }
        }

        public static ResetCommand Instance
        {
            get;
            private set;
        }

        private IServiceProvider ServiceProvider
        {
            get { return _package; }
        }

        public static void Initialize(Package package)
        {
            Instance = new ResetCommand(package);
        }

        private void Execute(object sender, EventArgs e)
        {
            var dte = (DTE)ServiceProvider.GetService(typeof(DTE));

            if (dte.ActiveDocument == null)
                return;

            try
            {
                IWpfTextView view = GetCurentTextView();

                if (view == null || view.ZoomLevel == 100)
                    return;

                ResetZoom(dte, view);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
            }
        }

        private static void ResetZoom(_DTE dte, IWpfTextView view)
        {
            if (view.ZoomLevel > 100)
            {
                while (view.ZoomLevel > 100)
                    dte.ExecuteCommand("View.ZoomOut");
            }
            else
            {
                while (view.ZoomLevel < 100)
                    dte.ExecuteCommand("View.ZoomIn");
            }
        }

        public IWpfTextView GetCurentTextView()
        {
            return GetTextView();
        }

        public IWpfTextView GetTextView()
        {
            var compService = ServiceProvider.GetService(typeof(SComponentModel)) as IComponentModel;
            IVsEditorAdaptersFactoryService editorAdapter = compService.GetService<IVsEditorAdaptersFactoryService>();
            return editorAdapter.GetWpfTextView(GetCurrentNativeTextView());
        }

        public IVsTextView GetCurrentNativeTextView()
        {
            var textManager = (IVsTextManager)ServiceProvider.GetService(typeof(SVsTextManager));

            ErrorHandler.ThrowOnFailure(textManager.GetActiveView(1, null, out IVsTextView activeView));
            return activeView;
        }
    }
}
