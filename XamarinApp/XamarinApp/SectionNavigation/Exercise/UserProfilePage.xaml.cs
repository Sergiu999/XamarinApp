
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Services;

namespace XamarinApp.SectionNavigation.Exercise
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfilePage : ContentPage
    {
        private UserService _service = new UserService();

        public UserProfilePage(int userId)
        {
            BindingContext = _service.GetUser(userId);

            InitializeComponent();
        }
    }
}