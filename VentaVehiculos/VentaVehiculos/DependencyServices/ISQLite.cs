using SQLite;

namespace VentaVehiculos.DependencyServices
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
