
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuotesPage : ContentPage
    {
        public QuotesPage()
        {
            InitializeComponent();

            CurrentQuote.Text = _quotes[_index];

            slider.Maximum = 50;
            slider.Minimum = 16;
        }

        private readonly string[] _quotes = {
            "fraza1",
            "fraza2",
            "fraza3"
        };
        private int _index = 0;

        private void Button_OnClicked(object sender, EventArgs e)
        {
            _index++;
            if (_index > 2)
                _index = 0;

            CurrentQuote.Text = _quotes[_index];

        }
    }
}