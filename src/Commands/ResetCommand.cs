using Community.VisualStudio.Toolkit;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text.Editor;
using Task = System.Threading.Tasks.Task;

namespace ResetZoom
{
    [Command(PackageGuids.guidPackageCmdSetString, PackageIds.ResetCommand)]
    internal sealed class ResetZoomLevel : BaseCommand<ResetZoomLevel>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            DocumentView docView = await VS.Documents.GetActiveDocumentViewAsync();

            if (docView?.TextView != null)
            {
                await ResetZoomAsync(docView.TextView);
            }
        }

        private static async Task ResetZoomAsync(IWpfTextView view)
        {
            Options options = await Options.GetLiveInstanceAsync();
            view.ZoomLevel = options.DefaultZoomLevel;

            await VS.Commands.ExecuteAsync("View.ZoomIn");
            await VS.Commands.ExecuteAsync("View.ZoomOut");
        }
    }
}
