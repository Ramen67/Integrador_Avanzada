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
    /// Lógica de interacción para Autores.xaml
    /// </summary>
    public partial class Autores : Window
    {
        public Autores()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            this.Loaded += A_L_Loaded;
        }
        private void A_L_Loaded(object sender, RoutedEventArgs e)
        {
            mostrarAutores(sender, e);
            mostrarLibros(sender, e);
        }

        private void agregarBtn_Click(object sender, RoutedEventArgs e)
        {
            int idLibro, idAutor;
            if (!int.TryParse(txtAutor.Text, out idAutor) || !int.TryParse(txtLibro.Text, out idLibro))
            {
                MessageBox.Show("Ingresa valores validos por favor");
                return;
            }
            AutorLibro conexion = new AutorLibro();
            conexion.agregarAutorLibro(idLibro, idAutor);
            MessageBox.Show("Se agrego exitosamente");
        }
        private void mostrarAutores(object sender, RoutedEventArgs e)
        {
            AutorService autor = new AutorService();
            List<AutorModel> modelo= new List<AutorModel>();
            modelo = autor.mostrarAutores();
            dgAutor.ItemsSource= modelo;
        }
        private void mostrarLibros(object sender, RoutedEventArgs e)
        {
            LibroService libroService = new LibroService();
            List<LibroModel> modelo = new List<LibroModel>();
            modelo = libroService.obtenerTodosLosLibros();
            dgLibro.ItemsSource = modelo;
        }
        private void LibroBtn_Click(object sender, RoutedEventArgs e)
        {
            Libro libro = new Libro();
            libro.WindowStartupLocation= WindowStartupLocation.CenterScreen;
            this.Close();
            libro.Show();
        }

        private void UsuarioBtn_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            usuario.Show();
        }

        private void SancionesBtn_Click(object sender, RoutedEventArgs e)
        {
            Sanciones sanciones = new Sanciones();
            sanciones.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            sanciones.Show();
        }

        private void PrestamoBtn_Click(object sender, RoutedEventArgs e)
        {
            Prestamo prestamo = new Prestamo();
            prestamo.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            prestamo.Show();
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            main.Show();
        }

        private void dgAutor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AutorModel modelo;
            modelo = dgAutor.SelectedItem as AutorModel;
            if (modelo == null)
            {
                txtAutor.Text = "";
                return;
            }
            txtAutor.Text = modelo.autorId.ToString();
            
        }

        private void dgLibro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LibroModel modelo;
            modelo = dgLibro.SelectedItem as LibroModel;
            if (modelo == null)
            {
                txtLibro.Text = "";
                return;
            }
            txtLibro.Text= modelo.libroId.ToString();
        }

        private void AgregarAutorBtn_Click(object sender, RoutedEventArgs e)
        {
            AutoresAgregar autorAgregar = new AutoresAgregar();
            autorAgregar.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            autorAgregar.Show();
        }
    }
}
