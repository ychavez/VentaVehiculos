using System;
using System.Collections.Generic;
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
   
            
        }

        protected override async void OnAppearing()
        {
            CarsListView.ItemsSource = await new CarsRepo().GetCars();

            base.OnAppearing();
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