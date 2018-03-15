
using Xamarin.Forms;
using XamarinApp.SectionMVVM;

namespace XamarinApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PlaylistsPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }


        private const string TitleKey = "Name";
        private const string NotificationsEnabledKey = "NotificationsEnabled";

        public string Title
        {
            get => Properties.ContainsKey(TitleKey) ? Properties[TitleKey].ToString() : "";
            set => Properties[TitleKey] = value;
        }

        public bool NotificationsEnabled
        {
            get => Properties.ContainsKey(NotificationsEnabledKey) && (bool)Properties[NotificationsEnabledKey];
            set => Properties[NotificationsEnabledKey] = value;
        }
    }
}
