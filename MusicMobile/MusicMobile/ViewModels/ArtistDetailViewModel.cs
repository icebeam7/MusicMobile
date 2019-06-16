using System;
using System.Windows.Input;
using System.Threading.Tasks;

using MusicMobile.Models;
using MusicMobile.Helpers;
using MusicMobile.Services;

using Xamarin.Forms;

namespace MusicMobile.ViewModels
{
    public class ArtistDetailViewModel : BaseViewModel
    {
        string controller = Constants.ArtistsApi;

        public INavigation Navigation { get; set; }
        public ICommand SaveArtistCommand { get; set; }
        public ICommand DeleteArtistCommand { get; set; }

        Artist artist;

        public Artist Artist
        {
            get => artist;
            set { artist = value; RaisePropertyChanged(); }
        }

        Page MainPage;

        public ArtistDetailViewModel(Artist artist, INavigation navigation)
        {
            Navigation = navigation;
            Artist = artist;
            SaveArtistCommand = new Command(async () => await SaveArtist());
            DeleteArtistCommand = new Command(async () => await DeleteArtist());

            MainPage = Application.Current.MainPage;
        }

        async Task SaveArtist()
        {
            IsBusy = true;

            if (Artist.ArtistID == Guid.Empty)
                await MusicService<Artist>.InsertData(controller, Artist);
            else
                await MusicService<Artist>.UpdateData(controller, Artist, Artist.ArtistID);

            IsBusy = false;

            await MainPage.DisplayAlert(
                "Success", "The entry was saved successfully", "OK");

            await Navigation.PopAsync();
        }

        async Task DeleteArtist()
        {
            if (await MainPage.DisplayAlert(
                "Confirm", "Do you really want to delete this entry?", "Yes", "No"))
            {
                IsBusy = true;
                await MusicService<Artist>.DeleteData(controller, Artist.ArtistID);
                IsBusy = false;

                await MainPage.DisplayAlert("Success",
                    "The entry was deleted successfully", "OK");

                await Navigation.PopAsync();
            }
        }
    }
}
