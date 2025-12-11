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
    /// Lógica de interacción para Prestamo.xaml
    /// </summary>
    public partial class Prestamo : Window
    {
        public Prestamo()
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

        private void SancionesBtn_Click(object sender, RoutedEventArgs e)
        {
            Sanciones irSanciones = new Sanciones();
            irSanciones.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            irSanciones.Show();
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
            int ejemplarId;
            int usuarioId;
            if (int.TryParse(txtIdEjemplar.Text, out ejemplarId) && int.TryParse(txtIdUsuario.Text, out usuarioId))
            {
                PrestamoService prestamoService = new PrestamoService();
                prestamoService.RealizarPrestamo(ejemplarId, usuarioId);
                MessageBox.Show("Préstamo realizado con éxito.");
            }
            else
            {
                MessageBox.Show("Por favor, ingrese IDs válidos para el ejemplar y el usuario.");
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
            PrestamoService model = new PrestamoService();
            List<PrestamoModel> prestamos;
            prestamos = model.BuscarPrestamosPorUsuario(idUsuario);
            dgPrestamo.ItemsSource = prestamos;
        }

        private void btnDevol_Click(object sender, RoutedEventArgs e)
        {
            int prestamoId;
            if (int.TryParse(txtPresbtn.Text, out prestamoId))
            {
                PrestamoService prestamoService = new PrestamoService();
                prestamoService.DevolverPrestamo(prestamoId);
                MessageBox.Show("Devolución realizada con éxito.");
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de préstamo válido.");
            }
        }
    }
}
