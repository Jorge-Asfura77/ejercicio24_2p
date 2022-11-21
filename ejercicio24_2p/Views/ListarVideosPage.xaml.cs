using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xam.Forms.VideoPlayer;

namespace ejercicio24_2p.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListarVideosPage : ContentPage
    {
        public ListarVideosPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listaVideos.ItemsSource = await App.BaseDatosObject.GetVideoList();
        }

        Models.VideoModel video;
        private async void listaVideos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            video = (Models.VideoModel)e.Item;

            await Navigation.PushAsync(new ReproducirVideoPage(this.video));
            
        }
    }
}