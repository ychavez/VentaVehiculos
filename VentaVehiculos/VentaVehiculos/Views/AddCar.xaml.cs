//using Plugin.Geolocator;
using Plugin.Geolocator;
using System;
using VentaVehiculos.Context;
using VentaVehiculos.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VentaVehiculos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCar : ContentPage
    {
        public AddCar()
        {
            InitializeComponent();
        }

        private async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 100;

            var position = await locator.GetPositionAsync();

            var carsRepo = new CarsRepo();
            await carsRepo.AddCar(new Car()
            {
                Model = txtmodelo.Text,
                Brand = txtMarca.Text,
                Description = txtDescripcion.Text,
                Price = decimal.Parse(txtPrecio.Text),
                PhotoUrl = "https://i.pinimg.com/236x/5a/19/93/5a19936163f821c1c53a197775b9bd64.jpg",
                Lat = position.Latitude,
                Lon = position.Longitude
            });

            await DisplayAlert("Agregado", "El vehiculo se agrego correctamente","Aceptar");

            MessagingCenter.Send<Page>(this, "CarAdded");

            await Navigation.PopAsync();
        }

        private async void btnFoto_Clicked(object sender, EventArgs e)
        {
            if (Plugin.Media.CrossMedia.Current.IsCameraAvailable && Plugin.Media.CrossMedia.Current.IsTakePhotoSupported)
            {
                var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                    SaveMetaData = false
                });

                if (photo != null)
                {
                    img.Source = ImageSource.FromStream(() => photo.GetStream());
                }
            }
        }
    }
}

