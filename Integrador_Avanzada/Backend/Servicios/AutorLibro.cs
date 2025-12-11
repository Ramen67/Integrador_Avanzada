using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador_Avanzada.Backend.Servicios
{
    internal class AutorLibro
    {
        public void agregarAutorLibro(int libro_id, int autor_id)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    INSERT INTO autor_libro(autor_id,libro_id)
                    VALUES (@autor_id,@libro_id)";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@autor_id", autor_id);
                    cmd.Parameters.AddWithValue("@libro_id", libro_id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
