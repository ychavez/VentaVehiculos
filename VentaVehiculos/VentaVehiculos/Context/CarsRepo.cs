using System.Collections.Generic;
using System.Threading.Tasks;
using VentaVehiculos.Models;

namespace VentaVehiculos.Context
{
    public class CarsRepo
    {
        private readonly RestService _RestService;

        public CarsRepo()
        {
            _RestService = new RestService();
        }


        public async Task<List<Car>> GetCars()
            => await _RestService.GetDataAsync<Car>("carsForSalesApi");


    }
}
