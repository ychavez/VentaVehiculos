using System;
using System.Collections.Generic;
using VentaVehiculos.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VentaVehiculos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarsForSale : ContentPage
    {
        List<Car> CarsList = new List<Car>();
        public CarsForSale()
        {
            InitializeComponent();
            CarsList.Add(new Car
            {
                Brand = "Chevrolet",
                Description = "Corvette 8va gen 455hp",
                Model = "Corvette",
                PhotoUrl = "https://img.remediosdigitales.com/d9c5a7/chevrolet-corvette_c8_stingray-2020-1600-02/1366_2000.jpg",
                Price = 1_000_000
            });
            CarsList.Add(new Car
            {
                Brand = "Chevrolet",
                Description = "Corvette 8va gen 455hp",
                Model = "Corvette",
                PhotoUrl = "https://img.remediosdigitales.com/d9c5a7/chevrolet-corvette_c8_stingray-2020-1600-02/1366_2000.jpg",
                Price = 1_000_000
            });
            CarsList.Add(new Car
            {
                Brand = "Chevrolet",
                Description = "Camaro 6ta generacion lt4",
                Model = "Camaro",
                PhotoUrl = "https://acroadtrip.blob.core.windows.net/catalogo-imagenes/s/RT_V_fdf2792f4ef94f45a2624c08ef7ebcca.jpg",
                Price = 5_000_000
            });
            CarsList.Add(new Car
            {
                Brand = "Chevrolet",
                Description = "Corvette 8va gen 455hp",
                Model = "Corvette",
                PhotoUrl = "https://img.remediosdigitales.com/d9c5a7/chevrolet-corvette_c8_stingray-2020-1600-02/1366_2000.jpg",
                Price = 1_000_000
            });
            CarsList.Add(new Car
            {
                Brand = "Chevrolet",
                Description = "Corvette 8va gen 455hp",
                Model = "Corvette",
                PhotoUrl = "https://img.remediosdigitales.com/d9c5a7/chevrolet-corvette_c8_stingray-2020-1600-02/1366_2000.jpg",
                Price = 1_000_000
            });
            CarsListView.ItemsSource = CarsList;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCar());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("El auto seleccionado fue", ((Car)((Button)sender).BindingContext).Description, "Ok");
        }
    }
}