using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ejercicio24_2p.Models;
using Xam.Forms.VideoPlayer;

namespace ejercicio24_2p.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReproducirVideoPage : ContentPage
    {
        public ReproducirVideoPage(VideoModel video)
        {
            InitializeComponent();
            setearDatos(video);
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void setearDatos(VideoModel video)
        {
            lbldescripcion.Text = video.Descripcion;
            UriVideoSource uriVideoSurce = new UriVideoSource()
            {
                Uri = video.Uri
            };
            videoPlayer2.Source = uriVideoSurce;
        }
    }
}