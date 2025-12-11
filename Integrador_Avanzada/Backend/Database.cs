using System.Data.SqlClient;

namespace Integrador_Avanzada.Backend
{
    public static class Database
    {
        // eh we aqui cada quien tiene que poner su string de conexion
        public static string ConnectionString = "";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
