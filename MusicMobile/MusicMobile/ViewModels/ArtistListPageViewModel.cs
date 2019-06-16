using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using MusicMobile.Models;
using MusicMobile.Helpers;
using MusicMobile.Services;

using Xamarin.Forms;

namespace MusicMobile.ViewModels
{
    public class ArtistListPageViewModel : BaseViewModel
    {
        string controller = Constants.ArtistsApi;

        public INavigation Navigation { get; set; }
        public ICommand NewArtistCommand { get; set; }
        public ICommand ViewArtistCommand { get; set; }

        Artist selectedArtist;

        public Artist SelectedArtist
        {
            get => selectedArtist;
            set { selectedArtist = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<Artist> artistsList;

        public ObservableCollection<Artist> ArtistsList
        {
            get => artistsList;
            set { artistsList = value; RaisePropertyChanged(); }
        }

        public ArtistListPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            NewArtistCommand = new Command(async () => await NewArtist());
            ViewArtistCommand = new Command(async () => await ViewArtist());
        }

        public async Task LoadData()
        {
            IsBusy = true;
            ArtistsList = new ObservableCollection<Artist>(await MusicService<Artist>.GetData(controller));
            IsBusy = false;
        }

        async Task NewArtist()
        {
            await Navigation.PushAsync(new Views.ArtistDetailPage(new ArtistDetailViewModel(new Artist(), Navigation)));
        }

        async Task ViewArtist()
        {
            await Navigation.PushAsync(new Views.ArtistDetailPage(new ArtistDetailViewModel(SelectedArtist, Navigation)));
        }
    }
}
