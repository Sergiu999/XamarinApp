
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.DataAccessSection
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataAccessDemo : ContentPage
    {
        public DataAccessDemo()
        {
            InitializeComponent();

            BindingContext = Application.Current;
        }

    }
}