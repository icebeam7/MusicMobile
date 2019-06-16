using MusicMobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArtistDetailPage : ContentPage
    {
        public ArtistDetailPage(ArtistDetailViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}