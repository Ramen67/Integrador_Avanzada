using Integrador_Avanzada.Backend.Modelos;
using Integrador_Avanzada.Backend.Servicios;
using Microsoft.IdentityModel.Tokens;
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
            libroWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            libroWindow.Show();
        }

        private void UsuarioBtn_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuarioWindow = new Usuario();
            usuarioWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            usuarioWindow.Show();
        }

        private void SancionesBtn_Click(object sender, RoutedEventArgs e)
        {
            Sanciones sancionesWindow = new Sanciones();
            sancionesWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            sancionesWindow.Show();
        }

        private void PrestamoBtn_Click(object sender, RoutedEventArgs e)
        {
            Prestamo prestamoWindow = new Prestamo();
            prestamoWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            prestamoWindow.Show();
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            mainWindow.Show();
        }

        private void mostrarBtn_Click(object sender, RoutedEventArgs e)
        {
            EjemplarServicio servicio = new EjemplarServicio();
            List<EjemplarModel> modelo = new List<EjemplarModel>();
            modelo = servicio.mostrarEjemplares();
            dgEjemplar.ItemsSource = modelo;
        }

        private void agregarBtn_Click(object sender, RoutedEventArgs e)
        {
            string numInventario = txtInven.Text;
            int idLibro;
            if(string.IsNullOrEmpty(numInventario) || !int.TryParse(txtLibro.Text,out idLibro))
            {
                MessageBox.Show("Ingresa valores validos por favor");
                return;
            }
            EjemplarServicio ejemplarServicio = new EjemplarServicio();
            ejemplarServicio.agregarEjemplar(idLibro, numInventario);
            MessageBox.Show("Se agrego exitosamente");
        }

        private void dispoBtn_Click(object sender, RoutedEventArgs e)
        {
            List<EjemplarModel> dispo = new List<EjemplarModel>();
            EjemplarServicio servicio = new EjemplarServicio();
            List<EjemplarModel> modelo = new List<EjemplarModel>();
            modelo = servicio.mostrarEjemplares();
            var disponible = from disponibles in modelo
                             where disponibles.estado == "Disponible"
                             select disponibles;
            foreach(var disponibles in disponible)
            {
                dispo.Add(disponibles);
            }
            dgDisponibles.ItemsSource = dispo;
        }
    }
}
