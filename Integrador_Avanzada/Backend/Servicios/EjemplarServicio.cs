using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador_Avanzada.Backend.Servicios
{
    internal class EjemplarServicio
    {
        public void agregarEjemplar(int libro_id, string numInventario)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    INSERT INTO ejemplares(libro_id, estado, numero_inventario)
                    VALUES (@libro_id, 'Disponible', @numInv)";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@libro_id", libro_id);
                    cmd.Parameters.AddWithValue("@numInv", numInventario);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
