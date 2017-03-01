using Microsoft.VisualStudio.Shell;
using System.ComponentModel;

namespace ResetZoom
{
    public class Options : DialogPage
    {
        [Category("General")]
        [DisplayName("Default zoom level")]
        [Description("Set the default zoom level to one of the supported values in the editor zoom dropdown (e.g. 91, 110, 121).")]
        [DefaultValue(100)]
        public int DefaultZoomLevel { get; set; } = 100;
    }
}
