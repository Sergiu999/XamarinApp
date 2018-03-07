using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.FormsSection
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactMethodsPage : ContentPage
    {
        public ContactMethodsPage()
        {
            InitializeComponent();

            listView.ItemsSource = new List<string>
            {
                "None",
                "Email",
                "SMS"
            };
        }

        public ListView ContactMethods
        {
            get { return listView; }
        }
    }
}