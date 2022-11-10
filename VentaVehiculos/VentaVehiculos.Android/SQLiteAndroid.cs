using SQLite;
using System;
using System.IO;
using VentaVehiculos.DependencyServices;
using VentaVehiculos.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteAndroid))]
namespace VentaVehiculos.Droid
{
    public class SQLiteAndroid : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            /// declaramos el nombre del archivo de base de datos
            string sqlFileName = "Cars.db3";

            //obtenemos la ruta de donde esta instalada la aplicacion
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            // armamos la ruta completa con el archivo y la ruta
            string path = Path.Combine(docPath, sqlFileName);

            //armamos la conexion
            SQLiteConnection conn = new SQLiteConnection(path);

            return conn;

        }
    }
}