
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;

namespace XamarinApp.SectionNavigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : MasterDetailPage
    {
        public ContactsPage()
        {
            InitializeComponent();

            listView.ItemsSource = new List<Contact>
            {
                new Contact {Name = "Mosh", ImageUrl = "https://picsum.photos/100"},
                new Contact {Name = "John", ImageUrl = "https://picsum.photos/100"}
            };
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //if (e.SelectedItem == null)
            //    return;

            var contact = e.SelectedItem as Contact;
            Detail = new NavigationPage(new ContactsDetailPage(contact));
            IsPresented = false;
            //await Navigation.PushAsync(new ContactsDetailPage(contact));
            //listView.SelectedItem = null;
        }
    }
}