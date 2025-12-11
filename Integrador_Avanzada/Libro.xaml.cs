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
    /// Lógica de interacción para Libro.xaml
    /// </summary>
    public partial class Libro : Window
    {
        public Libro()
        {
            InitializeComponent();
        }

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

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow irHome = new MainWindow();
            this.Close();
            irHome.Show();
        }
    }
}
