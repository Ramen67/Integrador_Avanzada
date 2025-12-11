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
    }
}
