using Integrador_Avanzada.Backend.Modelos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador_Avanzada.Backend.Servicios
{
    internal class EditorialService
    {
        public void agregarEditorial(string ciudad, string pais, string nombre) //agregar editorial
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                        INSERT INTO editoriales (nombre, ciudad, pais)
                        VALUES (@nombre, @ciudad, @pais)";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@ciudad", ciudad);
                    cmd.Parameters.AddWithValue("@pais", pais);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void eliminarEditorial(int editorialId) //eliminar editorial
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                        DELETE FROM editoriales
                        WHERE editorial_id = @id";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", editorialId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EditorialModel> getEditoriales() //devuelve todas las editoriales
        {
            var editoriales = new List<EditorialModel>();

            using (var conn = Database.GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM editoriales";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            editoriales.Add(new EditorialModel
                            {
                                editorialId = reader.GetInt32(0),
                                editorialName = reader.GetString(1),
                                editorialCidudad = reader.GetString(2),
                                editorialPais = reader.GetString(3)
                            });
                        }
                    }
                }
            }

            return editoriales;
        }
    }
}
