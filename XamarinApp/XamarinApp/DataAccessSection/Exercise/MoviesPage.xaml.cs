
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;
using XamarinApp.Services;

namespace XamarinApp.DataAccessSection.Exercise
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesPage : ContentPage
    {
        public MoviesPage()
        {
            BindingContext = this;

            InitializeComponent();
        }

        private MovieService _service = new MovieService();

        // Note that IsSearching is a bindable property. This is required for 
        // binding ActivityIndicator's IsRunning property. If we do not define 
        // IsSearching as a bindable property, its initial value (false) will 
        // be used to set ActivityIndicator.IsRunning. Later when we change
        // the value of IsSearching, ActivityIndicator will be unaware of this. 
        // So, we need to implement it as a bindable property. 
        private BindableProperty IsSearchingProperty =
            BindableProperty.Create("IsSearching", typeof(bool), typeof(MoviesPage), false);
        public bool IsSearching
        {
            get { return (bool)GetValue(IsSearchingProperty); }
            set { SetValue(IsSearchingProperty, value); }
        }

        private async void OnTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            // Here we are checking for "null" because if the user presses Cancel, 
            // e.NewTextValue will be null. 
            if (e.NewTextValue == null || e.NewTextValue.Length < MovieService.MinSearchLength)
                return;

            // Note that I've movied the logic of setting the ListView's ItemSource
            // and handling errors to LoadMovies method. The reason for this is 
            // because try/catch blocks should not be in the middle of your methods. 
            // They make the code look ugly. 
            await FindMovies(actor: e.NewTextValue);
        }

        private async Task FindMovies(string actor)
        {
            // Clean coding tip: try/catch should NOT be in the middle 
            // of a method. 

            // The responsibility of this method is quite clear. 
            // It calls the service and displays the result (either movies 
            // in the ListView or a Label). If anything unexpected happens,
            // it prevents the application from crashing and displays an alert. 
            // If we were to call this method from two different places, we 
            // wouldn't have to do error handling or setting IsSearching in
            // two different places. All these go hand-in-hand with setting
            // ListView's ItemSource. That's why I've encapsulated all that 
            // in one method. 
            try
            {
                IsSearching = true;

                var movies = await _service.FindMoviesByActor(actor);
                moviesListView.ItemsSource = movies;
                moviesListView.IsVisible = movies.Any();
                notFound.IsVisible = !moviesListView.IsVisible;
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Could not retrieve the list of movies.", "OK");
            }
            finally
            {
                IsSearching = false;
            }
        }

        private async void OnMovieSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var movie = e.SelectedItem as Movie;

            moviesListView.SelectedItem = null;

            await Navigation.PushAsync(new MovieDetailsPage(movie));
        }
    }
}