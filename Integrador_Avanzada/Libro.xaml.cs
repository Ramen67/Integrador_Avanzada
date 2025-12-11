using Integrador_Avanzada.Backend.Modelos;
using Integrador_Avanzada.Backend.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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
            irUsuario.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            irUsuario.Show();
        }

        private void EjemplarBtn_Click(object sender, RoutedEventArgs e)
        {
            Ejemplar irEjemplar = new Ejemplar();
            irEjemplar.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            irEjemplar.Show();
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

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow irHome = new MainWindow();
            irHome.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Close();
            irHome.Show();
        }
        private void AutorBtn_Click(object sender, RoutedEventArgs e)
        {
            Autores irAutores = new Autores();
            this.Close();
            irAutores.Show();
        }

        private void EditorialBtn_Click(object sender, RoutedEventArgs e)
        {
            Editoriales irEditoriales = new Editoriales();
            this.Close();
            irEditoriales.Show();
        }

        private void rPresbtn_Click(object sender, RoutedEventArgs e)
        {
            string txtTitulo;
            string txISBN;
            int year;
            if(int.TryParse(txtA.Text, out year))
            {
                txtTitulo = txtIdTitulo.Text;
                txISBN = txtISBN.Text;
                LibroService libroservice = new LibroService();
                libroservice.agregarLibro(txtTitulo,txISBN,year);

            }
        }

        private void rDelbtn_Click(object sender, RoutedEventArgs e)
        {
            int ID;
            if(int.TryParse(txtId.Text, out ID))
            {
                LibroService libroservice = new LibroService();
                libroservice.eliminarLibro(ID);
            }
        }

        private void rVerbtn_Click(object sender, RoutedEventArgs e)
        {
            LibroService libroservice = new LibroService();
            List<LibroModel> lista = libroservice.obtenerTodosLosLibros();
            dgbook.ItemsSource = lista;
        }
    }
}