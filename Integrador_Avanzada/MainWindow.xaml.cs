using Integrador_Avanzada.Backend;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Integrador_Avanzada
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SancionesBtn_Click(object sender, RoutedEventArgs e)
        {
            Sanciones irSanciones = new Sanciones();
            this.Close();
            irSanciones.Show();
        }

        private void PrestamoBtn_Click(object sender, RoutedEventArgs e)
        {
            Prestamo irPrestamo = new Prestamo();
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
            this.Close();
            irUsuario.Show();
        }

        private void EjemplarBtn_Click(object sender, RoutedEventArgs e)
        {
            Ejemplar irEjemplar = new Ejemplar();
            this.Close();
            irEjemplar.Show();
        }

        private void LibroBtn_Click(object sender, RoutedEventArgs e)
        {
            /* Conexion a la base de datos de prueba
             * usala en todas las ventanas
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
            this.Close();
            irLibro.Show();
        }
    }
}