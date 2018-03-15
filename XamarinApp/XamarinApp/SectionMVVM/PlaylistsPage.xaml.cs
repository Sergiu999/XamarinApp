
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.ViewModels;

namespace XamarinApp.SectionMVVM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistsPage : ContentPage
    {

        public PlaylistsPage()
        {
            ViewModel = new PlaylistsViewModel(new PageService());
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void OnPlaylistSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectPlaylistCommand.Execute(e.SelectedItem);
        }

        private PlaylistsViewModel ViewModel
        {
            get => BindingContext as PlaylistsViewModel;
            set => BindingContext = value;
        }
    }
}