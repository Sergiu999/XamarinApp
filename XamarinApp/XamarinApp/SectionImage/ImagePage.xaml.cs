
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.SectionImage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : ContentPage
    {
        public ImagePage()
        {
            InitializeComponent();

            //image.Source = ImageSource.FromResource("XamarinApp.Images.background.jpg");
        }
    }
}