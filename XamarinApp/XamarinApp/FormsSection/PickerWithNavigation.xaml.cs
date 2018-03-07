using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.FormsSection
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickerWithNavigation : ContentPage
    {
        public PickerWithNavigation()
        {
            InitializeComponent();
        }

        private void Cell_OnTapped(object sender, EventArgs e)
        {
            var page = new ContactMethodsPage();

            page.ContactMethods.ItemSelected += (source, args) =>
            {
                contactMethod.Text = args.SelectedItem.ToString();
                Navigation.PopAsync();
            };

            Navigation.PushAsync(page);
        }
    }
}