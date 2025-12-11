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

        private void DevolucionBtn_Click(object sender, RoutedEventArgs e)
        {
            Devolucion irDevolucion = new Devolucion();

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
            }



            this.Close();
            irDevolucion.Show();
        }
    }
}