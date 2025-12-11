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
            this.Close();
            Home.Show();
        }

        private void SancionesBtn_Click(object sender, RoutedEventArgs e)
        {
            Sanciones irSanciones = new Sanciones();
            this.Close();
            irSanciones.Show();
        }
        private void LibroBtn_Click(object sender, RoutedEventArgs e)
        {
            Libro irLibro = new Libro();
            this.Close();
            irLibro.Show();
        }

        private void EjemplarBtn_Click(object sender, RoutedEventArgs e)
        {
            Ejemplar irEjemplar = new Ejemplar();
            this.Close();
            irEjemplar.Show();
        }

        private void UsuarioBtn_Click(object sender, RoutedEventArgs e)
        {
            Usuario irUsuario = new Usuario();
            this.Close();
            irUsuario.Show();
        }
    }
}
