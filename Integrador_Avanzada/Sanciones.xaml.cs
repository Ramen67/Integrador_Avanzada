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
            this.Close();
            Home.Show();
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
            this.Close();
            irDevolucion.Show();
        }
    }
}
