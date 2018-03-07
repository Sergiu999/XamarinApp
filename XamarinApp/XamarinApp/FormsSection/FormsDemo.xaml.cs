
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.FormsSection
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormsDemo : ContentPage
    {
        public FormsDemo()
        {
            InitializeComponent();

            _contactMethods = GetContactMethods();

            foreach (var method in _contactMethods)
                contactMethods.Items.Add(method.Name);
        }

        private IList<ContactMethod> GetContactMethods()
        {
            return new List<ContactMethod>
            {
                new ContactMethod { Id = 1, Name = "SMS"},
                new ContactMethod {Id = 2, Name = "Email"}
            };
        }

        //private void Switch_OnToggled(object sender, ToggledEventArgs e)
        //{
        //    label.IsVisible = e.Value;
        //}

        private void Slider_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            var hhh = e.NewValue + e.OldValue;
        }

        private void Entry_OnCompleted(object sender, EventArgs e)
        {
            pswlabel.Text = "Completed";
        }


        private readonly IList<ContactMethod> _contactMethods;

        private void Picker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var name = contactMethods.Items[contactMethods.SelectedIndex];
            var contactMethod = _contactMethods.Single(cm => cm.Name == name);
            var id = contactMethod.Id;
            DisplayAlert("Selection", name, "OK");
        }

        private void DatePicker_OnDateSelected(object sender, DateChangedEventArgs e)
        {
            var mimi = e.NewDate;
            var mimi2 = e.OldDate;
        }
    }

    public class ContactMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}