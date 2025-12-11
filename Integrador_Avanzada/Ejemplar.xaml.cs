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
    /// Lógica de interacción para Ejemplar.xaml
    /// </summary>
    public partial class Ejemplar : Window
    {
        public Ejemplar()
        {
            InitializeComponent();
        }

        private void LibroBtn_Click(object sender, RoutedEventArgs e)
        {
            Libro libroWindow = new Libro();
            this.Close();
            libroWindow.Show();
        }

        private void EjemplarBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
