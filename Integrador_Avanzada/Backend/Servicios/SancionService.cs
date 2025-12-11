using Integrador_Avanzada.Backend.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integrador_Avanzada.Backend.Modelos;

namespace Integrador_Avanzada.Backend.Servicios
{
    public class SancionService
    {
        public void AplicarSancion(int prestamoId, int usuarioId, decimal monto)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    INSERT INTO sanciones (prestamo_id, usuario_id, monto, fecha_pago)
                    VALUES (@prestamo, @usuario, @monto, NULL);
                ";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@prestamo", prestamoId);
                    cmd.Parameters.AddWithValue("@usuario", usuarioId);
                    cmd.Parameters.AddWithValue("@monto", monto);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<SancionModel> ConsultarSanciones(int usuarioId)
        {
            var lista = new List<SancionModel>();

            using (var conn = Database.GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM sanciones WHERE usuario_id = @id";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", usuarioId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new SancionModel
                            {
                                SancionId = reader.GetInt32(0),
                                PrestamoId = reader.GetInt32(1),
                                UsuarioId = reader.GetInt32(2),
                                Monto = reader.GetDecimal(3),
                                FechaPago = reader.IsDBNull(4) ? null : reader.GetDateTime(4)
                            });
                        }
                    }
                }
            }

            return lista;
        }
    }
}
