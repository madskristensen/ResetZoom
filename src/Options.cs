using System.ComponentModel;
using System.Threading.Tasks;
using Community.VisualStudio.Toolkit;

namespace ResetZoom
{
    internal class OptionsProvider
    {
        public class General : BaseOptionPage<Options> { }
    }

    public class Options : BaseOptionModel<Options>
    {
        [Category("General")]
        [DisplayName("Default zoom level")]
        [Description("Set the default zoom level to a number between 50 and 350")]
        [DefaultValue(100)]
        public int DefaultZoomLevel { get; set; } = 100;

        public override Task SaveAsync()
        {
            if (DefaultZoomLevel > 350)
            {
                DefaultZoomLevel = 350;
            }
            else if (DefaultZoomLevel < 50)
            {
                DefaultZoomLevel = 50;
            }

            return base.SaveAsync();
        }
    }
}
