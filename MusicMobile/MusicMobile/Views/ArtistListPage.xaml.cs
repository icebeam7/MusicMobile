using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MusicMobile.ViewModels;

namespace MusicMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArtistListPage : ContentPage
    {
        ArtistListPageViewModel vm;

        public ArtistListPage()
        {
            InitializeComponent();

            vm = new ArtistListPageViewModel(this.Navigation);
            BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.LoadData();
        }
    }
}