using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Integrador_Avanzada.Backend.Modelos;

namespace Integrador_Avanzada.Backend.Servicios
{
    internal class LibroService
    {
        public void agregarLibro(string titulo, string isbn, int year) //agregar libro
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    INSERT INTO libros(titulo, isbn, anio_publicacion)
                    VALUES (@titulo, @isbn, @year)";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@titulo", titulo);
                    cmd.Parameters.AddWithValue("@isbn", isbn);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void eliminarLibro(int libro_id) //eliminar libro
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                        DELETE FROM libros
                        WHERE libro_id = @libro_id";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@libro_id", libro_id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<LibroModel> buscarLibroXAutor(int autor_id) // buscar libro por su autor
        {
            var libros = new List<LibroModel>();

            using(var conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                        SELECT 
                        libros.libro_id
                        libros.titulo
                        libros.isbn
                        libros.anio_publicacion
                        FROM libros 
                        INNER JOIN autor_libro
                        ON libros.libro_id = autor_libro.libro_id
                        WHERE autor_libro.autor_id = @autor_id";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@autor_id", autor_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            libros.Add(new LibroModel
                            {
                                libroId = reader.GetInt32(0),
                                libroTitulo = reader.GetString(1),
                                libroISBN = reader.GetString(2),
                                libroAPublicacion = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }

            return libros;
        }
        public List<LibroModel> obtenerTodosLosLibros()
        {
            var libros = new List<LibroModel>();

            using (var conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"SELECT 
                            libros.libro_id, 
                            libros.titulo,
                            libros.isbn,    
                            libros.anio_publicacion,
                            autores.nombre,
                            editoriales.nombre
                            FROM libros 
                            INNER JOIN autor_libro
                            ON libros.libro_id = autor_libro.libro_id
                            INNER JOIN autores 
                            ON autor_libro.autor_id=autores.autor_id
                            INNER JOIN libro_editorial 
                            ON libros.libro_id = libro_editorial.libro_id
                            INNER JOIN editoriales
                            ON libro_editorial.editorial_id=editoriales.editorial_id;
"; // Trae todas las columnas

                using (var cmd = new SqlCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            libros.Add(new LibroModel
                            {
                                libroId = reader.GetInt32(reader.GetOrdinal("libro_id")),
                                libroTitulo = reader.GetString(reader.GetOrdinal("titulo")),
                                libroISBN = reader.GetString(reader.GetOrdinal("isbn")),
                                libroAPublicacion = reader.GetInt32(reader.GetOrdinal("anio_publicacion")),
                                libroAutor = reader.GetString(4),
                                libroEditorial = reader.GetString(5)
                            });
                        }
                    }
                }
            }
            return libros;
        }

    }
}
