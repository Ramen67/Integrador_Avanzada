using Integrador_Avanzada.Backend.Modelos;
using Integrador_Avanzada.Backend.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Integrador_Avanzada
{
    /// <summary>
    /// Lógica de interacción para Editoriales.xaml
    /// </summary>
    public partial class Editoriales : Window
    {
        public Editoriales()
        {
            InitializeComponent();
        }
        private void SancionesBtn_Click(object sender, RoutedEventArgs e)
        {
            Sanciones irSanciones = new Sanciones();
            irSanciones.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            irSanciones.Show();
        }

        private void PrestamoBtn_Click(object sender, RoutedEventArgs e)
        {
            Prestamo irPrestamo = new Prestamo();
            irPrestamo.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            irPrestamo.Show();
        }
        /*
        private void DevolucionBtn_Click(object sender, RoutedEventArgs e)
        {
            Devolucion irDevolucion = new Devolucion();
            this.Close();
            irDevolucion.Show();
        }*/

        private void UsuarioBtn_Click(object sender, RoutedEventArgs e)
        {
            Usuario irUsuario = new Usuario();
            irUsuario.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            irUsuario.Show();
        }

        private void EjemplarBtn_Click(object sender, RoutedEventArgs e)
        {
            Ejemplar irEjemplar = new Ejemplar();
            irEjemplar.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            irEjemplar.Show();
        }
        private void AutorBtn_Click(object sender, RoutedEventArgs e)
        {
            Autores irAutores = new Autores();
            this.Close();
            irAutores.Show();
        }

        private void LibroBtn_Click(object sender, RoutedEventArgs e)
        {
            /* Conexion a la base de datos de prueba
            try
            {
                using (var con = Database.GetConnection())
                {
                    con.Open(); // ← aquí truena si el ConnectionString está mal
                    MessageBox.Show("Conexión exitosa.", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al conectar con la base de datos:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }*/
            Libro irLibro = new Libro();
            irLibro.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            irLibro.Show();
        }
        private void agregarBtn_Click(object sender, RoutedEventArgs e)
        {
            string nombreCiudad = txtCiudad.Text;
            string nombrePais = txtPais.Text;
            string nombre = txtNombre.Text;

            if (string.IsNullOrEmpty(nombreCiudad) || string.IsNullOrEmpty(nombrePais) || string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Ingresa valores válidos por favor");
                return;
            }

            EditorialService editorialservice= new EditorialService();
            editorialservice.agregarEditorial(nombreCiudad, nombrePais, nombre);
            MessageBox.Show("Se agregó exitosamente");
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int EditorialId;
            if (int.TryParse(txtId.Text, out EditorialId))
            {
                EditorialService editorialservice = new EditorialService();
                editorialservice.eliminarEditorial(EditorialId);
            }
        }

        private void VerBtn_Click(object sender, RoutedEventArgs e)
        {
            EditorialService editorialservice = new EditorialService();
            List<EditorialModel> list=editorialservice.getEditoriales();
            dgEdit.ItemsSource = list;

        }
    }
}
