﻿
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.Extensions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DateCell : ViewCell
    {
        public static readonly BindableProperty LabelProperty = BindableProperty.Create("Label", typeof(string), typeof(DateCell));

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public DateCell()
        {
            InitializeComponent();

            BindingContext = this;
        }
    }
}