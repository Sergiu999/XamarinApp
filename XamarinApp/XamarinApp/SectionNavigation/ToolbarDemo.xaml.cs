using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.SectionNavigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToolbarDemo : ContentPage
    {
        public ToolbarDemo()
        {
            InitializeComponent();
        }

        private void ToolbarItem_OnActivated(object sender, EventArgs e)
        {
            DisplayAlert("Activated", "ToolbarItem Activated", "OK");
        }
    }
}