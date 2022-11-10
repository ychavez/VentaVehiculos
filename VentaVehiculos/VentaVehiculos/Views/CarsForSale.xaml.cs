using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VentaVehiculos.Context;
using VentaVehiculos.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VentaVehiculos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarsForSale : ContentPage
    {

        public CarsForSale()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<Page>(this, "CarAdded", async o => await InitControls());
            
        }

        private async Task InitControls() {
            CarsListView.ItemsSource = await new CarsRepo().GetCars();
        }

        protected override async void OnAppearing()
        {
            await InitControls();
            base.OnAppearing();
        }
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCar());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Auto Favorito",  new DatabaseManager().AddFavoriteCar((Car)((Button)sender).BindingContext)?
                "Auto favorito agregado correctamente":"El auto ya se encuentra en favoritos" , "Ok");
        }
    }
}