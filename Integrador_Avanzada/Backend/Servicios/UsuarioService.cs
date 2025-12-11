using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient; //cambie esta libreria para que no me tiraran error las lineas con SqlCommand, si les falla cambienlo a System.Data

namespace Integrador_Avanzada.Backend.Servicios
{
    internal class UsuarioService
    {
        public void agregarUsuario(string nombre, int reg, string correo, int tel) // agrega un usuario cff
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    INSERT INTO usuarios (nombre, registro_alumno, correo, telefono)
                    VALUES (@nombre, @reg, @correo, @tel);
                ";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@reg", reg);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@tel", tel);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
