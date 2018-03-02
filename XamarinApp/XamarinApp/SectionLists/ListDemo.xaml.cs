using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;

namespace XamarinApp.SectionLists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListDemo : ContentPage
    {
        private ObservableCollection<Contact> _contacts;

        public ListDemo()
        {
            InitializeComponent();

            //listView.ItemsSource = new List<ContactGroup>
            //{
            //    new ContactGroup("M", "M")
            //    {
            //        new Contact {Name = "Mosh", ImageUrl = "http://lorempixel.com/100/100/people/1"}
            //    },

            //    new ContactGroup("J", "J")
            //    {
            //        new Contact { Name = "John", ImageUrl = "http://lorempixel.com/100/100/people/2" , Status = "Hey, let's talk!"}
            //    }
            //};

            _contacts = new ObservableCollection<Contact>
            {
                new Contact {Name = "Mosh", ImageUrl = "http://lorempixel.com/100/100/people/1"},
                new Contact { Name = "John", ImageUrl = "http://lorempixel.com/100/100/people/2" , Status = "Hey, let's talk!"}
            };

            listView.ItemsSource = GetContacts();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var contact = e.Item as Contact;
            DisplayAlert("Tapped", contact.Name, "OK");
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var contact = e.SelectedItem as Contact;
            DisplayAlert("Selected", contact.Name, "OK");
        }

        private void Call_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;

            DisplayAlert("Call", contact.Name, "OK");
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            _contacts.Remove(contact);
        }

        IEnumerable<Contact> GetContacts(string searchText = null)
        {
            var contacts = new List<Contact>
            {
                new Contact {Name = "Mosh", ImageUrl = "http://lorempixel.com/100/100/people/1"},
                new Contact { Name = "John", ImageUrl = "http://lorempixel.com/100/100/people/2" , Status = "Hey, let's talk!"}
            };

            return string.IsNullOrWhiteSpace(searchText) ? contacts : contacts.Where(x => x.Name.StartsWith(searchText));
        }

        private void ListView_OnRefreshing(object sender, EventArgs e)
        {
            listView.ItemsSource = GetContacts();

            listView.EndRefresh();
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = GetContacts(e.NewTextValue);
        }
    }
}