using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.String;

namespace XamarinApp.MarkupExtensions
{
    public class EmbeddedImage : IMarkupExtension
    {
        public string ResourceId { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (IsNullOrWhiteSpace(ResourceId))
                return null;

            return ImageSource.FromResource(ResourceId);
        }
    }
}
