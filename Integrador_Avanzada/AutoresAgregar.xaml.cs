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
    /// Lógica de interacción para AutoresAgregar.xaml
    /// </summary>
    public partial class AutoresAgregar : Window
    {
        public AutoresAgregar()
        {
            InitializeComponent();
            this.Loaded += A_L_Loaded;
        }

        private void A_L_Loaded(object sender, RoutedEventArgs e)
        {
            mostrarAutores(sender, e);
        }

        private void mostrarAutores(object sender, RoutedEventArgs e)
        {
            AutorService autor = new AutorService();
            List<AutorModel> modelo = new List<AutorModel>();
            modelo = autor.mostrarAutores();
            dgAutor.ItemsSource = modelo;
        }

        private void SancionesBtn_Click(object sender, RoutedEventArgs e)
        {
            Sanciones irSanciones = new Sanciones();
            irSanciones.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            irSanciones.Show();
        }

        private void PrestamoBtn_Click(object sender, RoutedEventArgs e)
        {
            Prestamo irPrestamo = new Prestamo();
            irPrestamo.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            irPrestamo.Show();
        }

        private void EjemplarBtn_Click(object sender, RoutedEventArgs e)
        {
            Ejemplar irEjemplar = new Ejemplar();
            irEjemplar.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            irEjemplar.Show();
        }
        private void AutorBtn_Click(object sender, RoutedEventArgs e)
        {
            Autores irAutores = new Autores();
            irAutores.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            irAutores.Show();
        }

        private void LibroBtn_Click(object sender, RoutedEventArgs e)
        {
            Libro irLibro = new Libro();
            irLibro.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            irLibro.Show();
        }

        private void UsuarioBtn_Click(object sender, RoutedEventArgs e)
        {
            Usuario irUsuario = new Usuario();
            irUsuario.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            irUsuario.Show();
        }

        private void dgAutor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AutorModel modelo;
            modelo = dgAutor.SelectedItem as AutorModel;
            if (modelo == null)
            {
                txtNombreAutor.Text = "";
                txtNacionalidadAutor.Text = "";
                return;
            }
            txtNombreAutor.Text = modelo.autorName;
            txtNacionalidadAutor.Text = modelo.nacionalidad;
        }

        private void agregarBtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtNacionalidadAutor.Text.IsNullOrEmpty() || txtNombreAutor.Text.IsNullOrEmpty()) MessageBox.Show("Uno o múltiples campos vacíos, rellenelos");
            else
            {
                string name = txtNombreAutor.Text;
                string nacionalidad = txtNacionalidadAutor.Text;

                AutorService autorS = new AutorService();

                autorS.agregarAutores(name, nacionalidad);
                mostrarAutores(sender, e);
            }
        }
    }
}
