using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.SectionNavigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupPage : ContentPage
    {
        public PopupPage()
        {
            InitializeComponent();
        }

        //YES or NO DisplayAlert
        //private async void Button_OnClicked(object sender, EventArgs e)
        //{
        //    var response = await DisplayAlert("Warning", "Are you sure?", "Yes", "No");
        //    if (response)
        //        await DisplayAlert("Done", "Your response will be saved!", "OK");
        //}

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var response = await DisplayActionSheet("Title", "Cancel", "Delete", "Copy Link", "Message", "Email");
            await DisplayAlert("Response", response, "OK");
        }

    }
}