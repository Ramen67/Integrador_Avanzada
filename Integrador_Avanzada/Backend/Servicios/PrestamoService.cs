using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient; //cambie esta libreria para que no me tiraran error las lineas con SqlCommand, si les falla cambienlo a System.Data.SqlClient
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integrador_Avanzada.Backend.Modelos;

namespace Integrador_Avanzada.Backend.Servicios
{
    public class PrestamoService
    {
        public void RealizarPrestamo(int ejemplarId, int usuarioId) //crea un nuevo prestamo para un usuario
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    INSERT INTO prestamos (ejemplar_id, usuario_id, fecha_prestamo)
                    VALUES (@ejemplar_id, @usuario_id, GETDATE());

                    UPDATE ejemplares
                    SET estado = 'Prestado'
                    WHERE ejemplar_id = @ejemplar_id;
                ";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ejemplar_id", ejemplarId);
                    cmd.Parameters.AddWithValue("@usuario_id", usuarioId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DevolverPrestamo(int prestamoId) //actualiza la info de un prestamo para que diga que ya fue devuelto (le pone fecha de devolución y pone el ejemplar como disponible)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    UPDATE prestamos
                    SET fecha_devolucion = GETDATE()
                    WHERE prestamo_id = @id;

                    UPDATE ejemplares
                    SET estado = 'Disponible'
                    WHERE ejemplar_id = (
                        SELECT ejemplar_id FROM prestamos WHERE prestamo_id = @id
                    );
                ";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", prestamoId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<PrestamoModel> BuscarPrestamosPorUsuario(int usuarioId) //devuelve prestamos que un usuario tenga en una lista de objetos de tipo "prestamo model"
        {
            var lista = new List<PrestamoModel>();

            using (var conn = Database.GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM prestamos WHERE usuario_id = @id";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", usuarioId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PrestamoModel
                            {
                                PrestamoId = reader.GetInt32(0),
                                EjemplarId = reader.GetInt32(1),
                                UsuarioId = reader.GetInt32(2),
                                FechaPrestamo = reader.GetDateTime(3),
                                FechaDevolucion = reader.IsDBNull(4) ? null : reader.GetDateTime(4)
                            });
                        }
                    }
                }
            }

            return lista;
        }
    }
}
