using Integrador_Avanzada.Backend.Modelos;
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
        public List<EjemplarModel> mostrarEjemplares()
        {
            var lista = new List<EjemplarModel>();
            string sql = "SELECT * FROM ejemplares";
            var conn = Database.GetConnection();
            conn.Open();
            using (var cmd = new SqlCommand(sql, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new EjemplarModel
                        {
                            ejemplarId = reader.GetInt32(0),
                            libroId = reader.GetInt32(1),
                            estado = reader.GetString(2),
                            numInventario = reader.GetString(3)
                        });
                    }
                }
            }
            return lista;
        }
    }
}
