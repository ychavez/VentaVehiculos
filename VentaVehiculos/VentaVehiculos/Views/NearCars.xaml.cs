﻿using Plugin.Geolocator;
using System.Collections.Generic;
using System.IO.Compression;
using System.Threading.Tasks;
using VentaVehiculos.Context;
using VentaVehiculos.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace VentaVehiculos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NearCars : ContentPage
    {
        private readonly MapManager mapManager;
        public NearCars()
        {
            InitializeComponent();
            mapManager = new MapManager();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await SetMapCars();
        }

        private async Task SetMapCars()
        {
            var locator = CrossGeolocator.Current;

            locator.DesiredAccuracy = 100;

            var position = await locator.GetPositionAsync();


            List<Pin> pins = new List<Pin>();

            var cars = await new CarsRepo().GetCars();

            cars.ForEach(x =>
            {

                if (!(x.Lon == null || x.Lat == null))
                {
                    pins.Add(new Pin
                    {

                        Type = PinType.Generic,
                        Label = x.Description,
                        Address = x.Model,
                        Position = new Position(x.Lat.Value, x.Lon.Value)

                    });
                }
                
            });

            var circle = new Circle
            {

                Center = new Position(position.Latitude, position.Longitude),
                Radius = new Distance(10000),
                FillColor = Color.Blue
            };


            Content = mapManager.GetMap(true, new Position(position.Latitude, position.Longitude), circle, pins);

        }
    }
}