using Microsoft.Data.SqlClient;

namespace Integrador_Avanzada.Backend
{
    public static class Database
    {
        // arzate subió a la nube la bd, entonces ya tenemos un string de conexión "universal" q a todos les jala, no deberían de tener problemas si dejan esto así, pero si llegan a tener pedos diganlo en el grupo 
        public static string ConnectionString = "Server=sql1001.site4now.net; Database=db_ac222b_biblioteca; User Id=db_ac222b_biblioteca_admin; Password=Balatro1234; TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
