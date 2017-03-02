using Microsoft.VisualStudio.Shell;
using System.ComponentModel;

namespace ResetZoom
{
    public class Options : DialogPage
    {
        [Category("General")]
        [DisplayName("Default zoom level")]
        [Description("Set the default zoom level to a number between 20 and 400")]
        [DefaultValue(100)]
        public int DefaultZoomLevel { get; set; } = 100;

        protected override void OnApply(PageApplyEventArgs e)
        {
            if (DefaultZoomLevel > 400)
                DefaultZoomLevel = 400;
            else if (DefaultZoomLevel < 20)
                DefaultZoomLevel = 20;

            base.OnApply(e);
        }
    }
}
