using VentaVehiculos.Context;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VentaVehiculos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoriteCars : ContentPage
    {
        public FavoriteCars()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData() 
        {
            CarsListView.ItemsSource = null;
            CarsListView.ItemsSource = new DatabaseManager().GetFavoriteCars();     
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadData();
        }

    }
}