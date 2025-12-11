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
    /// Lógica de interacción para Sanciones.xaml
    /// </summary>
    public partial class Sanciones : Window
    {
        
        public Sanciones()
        {
            InitializeComponent();
            
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Home = new MainWindow();
            Home.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            Home.Show();
        }

        private void PrestamoBtn_Click(object sender, RoutedEventArgs e)
        {
            Prestamo irPrestamo = new Prestamo();
            irPrestamo.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            irPrestamo.Show();
        }
        private void LibroBtn_Click(object sender, RoutedEventArgs e)
        {
            Libro irLibro = new Libro();
            irLibro.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            irLibro.Show();
        }
        private void EjemplarBtn_Click(object sender, RoutedEventArgs e)
        {
            Ejemplar irEjemplar = new Ejemplar();
            irEjemplar.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            irEjemplar.Show();
        }

        private void UsuarioBtn_Click(object sender, RoutedEventArgs e)
        {
            Usuario irUsuario = new Usuario();
            irUsuario.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            irUsuario.Show();
        }

        private void rPresbtn_Click(object sender, RoutedEventArgs e)
        {
            int prestamosId;
            decimal monto;
            int usuarioId;
            if (int.TryParse(txtIdPrestamo.Text, out prestamosId) && decimal.TryParse(txtIdMonto.Text, out monto) && int.TryParse(txtIdUsuario.Text, out usuarioId))
            {
                SancionService sancionservice=new SancionService();
                sancionservice.AplicarSancion(prestamosId, usuarioId, monto);
                
                MessageBox.Show("Sancion realizada con éxito.");
            }
            else
            {
                MessageBox.Show("Por favor, ingrese IDs válidos para el prestamo,  y el usuario.");
            }
        }
       

        private void buscarbtn_Click(object sender, RoutedEventArgs e)
        {
            int idUsuario;
            if (!int.TryParse(txtBusqueda.Text, out idUsuario))
            {
                MessageBox.Show("Por favor, ingrese un ID de usuario válido.");
                return;
            }
            SancionService sancionservice = new SancionService();
            List<SancionModel> sanciones;
            sanciones = sancionservice.ConsultarSanciones(idUsuario);
            dgsanc.ItemsSource = sanciones;
        }
    }
}
