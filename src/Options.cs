using Microsoft.VisualStudio.Shell;
using System.ComponentModel;

namespace ResetZoom
{
    public class Options : DialogPage
    {
        [Category("General")]
        [DisplayName("Default zoom level")]
        [Description("Set the default zoom level to a number between 20 and 200")]
        [DefaultValue(100)]
        public int DefaultZoomLevel { get; set; } = 100;

        protected override void OnApply(PageApplyEventArgs e)
        {
            if (DefaultZoomLevel > 200 || DefaultZoomLevel < 20)
            {
                System.Windows.Forms.MessageBox.Show("Default zoom level must be between 20 and 200");
                e.ApplyBehavior = ApplyKind.CancelNoNavigate;
            }
            else
            {
                base.OnApply(e);
            }
        }
    }
}
