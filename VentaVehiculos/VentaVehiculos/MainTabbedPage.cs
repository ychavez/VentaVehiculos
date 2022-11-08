using VentaVehiculos.Views;
using Xamarin.Forms;

namespace VentaVehiculos
{
    public class MainTabbedPage : TabbedPage
    {
        public MainTabbedPage()
        {
            Title = "Vende mi carro";
            Children.Add(new CarsForSale());
            Children.Add(new NearCars());
            Children.Add(new FavoriteCars());

        }
    }
}
