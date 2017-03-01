using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;

namespace ResetZoom
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", Vsix.Version, IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideOptionPage(typeof(Options), "Environment", "Reset Zoom", 0, 0, true, ProvidesLocalizedCategoryName = false)]
    [Guid(PackageGuids.guidPackageString)]
    public sealed class ResetZoomPackage : Package
    {
        public static Options Options
        {
            get;
            private set;
        }

        protected override void Initialize()
        {
            Options = (Options)GetDialogPage(typeof(Options));
            ResetCommand.Initialize(this);
        }
    }
}
