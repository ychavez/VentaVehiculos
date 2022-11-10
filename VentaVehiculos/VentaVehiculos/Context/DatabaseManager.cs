using SQLite;
using System.Collections.Generic;
using System.Data;
using VentaVehiculos.DependencyServices;
using VentaVehiculos.Models;
using Xamarin.Forms;

namespace VentaVehiculos.Context
{
    public class DatabaseManager
    {
        private SQLiteConnection db;

        public DatabaseManager()
        {
            // obtenemos la conection de la plataforma en uso
            db = DependencyService.Get<ISQLite>().GetConnection();

            if (!TableExists("Car"))
                db.CreateTable<Car>();


        }
        bool TableExists(string str)
        {
            TableMapping map = new TableMapping(typeof(SqlDbType));

            object[] ps = new object[0];

            int tableCount = db.Query(map, $"select * from sqlite_master where type = 'table' and name = '{str}'", ps).Count;

            return tableCount > 0;

        }


        public List<Car> GetFavoriteCars()
        {
            return db.Query<Car>("Select * from car");

        }

        public bool AddFavoriteCar(Car car) 
        {

            if (db.Query<Car>($"select * from car where id = {car.Id}").Count > 0)
                return false;

            db.Insert(car);
            return true;
        
        
        }


    }
}
