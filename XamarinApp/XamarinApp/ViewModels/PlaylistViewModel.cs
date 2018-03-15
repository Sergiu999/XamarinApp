using Xamarin.Forms;

namespace XamarinApp.ViewModels
{
    public class PlaylistViewModel : BaseViewModel
    {
        public string Title { get; set; }

        private bool _isFavorite;
        public bool IsFavorite
        {
            get => _isFavorite;
            set
            {
                SetValue(ref _isFavorite, value);

                OnPropertyChanged(nameof(Color));
            }
        }

        public Color Color => IsFavorite ? Color.Pink : Color.Black;
    }
}
