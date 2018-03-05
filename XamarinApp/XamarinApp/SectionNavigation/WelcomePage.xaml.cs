using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.SectionNavigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new IntroductionPage());
        }
    }
}