using Integrador_Avanzada.Backend.Modelos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador_Avanzada.Backend.Servicios
{
    internal class AutorService
    {
        public List<AutorModel> mostrarAutores()
        {
            var lista = new List<AutorModel>();
            string sql = "SELECT autor_id, nombre, nacionalidad FROM autores";
            var conn = Database.GetConnection();
            conn.Open();
            using (var cmd = new SqlCommand(sql, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new AutorModel
                        {
                            autorId = reader.GetInt32(0),
                            autorName = reader.GetString(1),
                            nacionalidad = reader.GetString(2)
                        });
                    }
                }
            }
            return lista;
        }

        public void agregarAutores(string nombre, string nacionalidad)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                        INSERT INTO autores(nombre, nacionalidad)
                        VALUES (@name, @nacionalidad)";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", nombre);
                    cmd.Parameters.AddWithValue("@nacionalidad", nacionalidad);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
