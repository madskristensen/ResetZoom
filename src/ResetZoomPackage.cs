using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;

namespace ResetZoom
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", Vsix.Version, IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuids.guidPackageString)]
    public sealed class ResetZoomPackage : Package
    {
        protected override void Initialize()
        {
            ResetCommand.Initialize(this);
        }
    }
}
