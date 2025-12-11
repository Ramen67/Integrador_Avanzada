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
    /// Lógica de interacción para Usuario.xaml
    /// </summary>
    public partial class Usuario : Window
    {
        public Usuario()
        {
            InitializeComponent();
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

        private void rPresbtn_Click(object sender, RoutedEventArgs e)
        {
            int usuarioId;
            string nombre;
            string correo;
            string telefono;

            if (int.TryParse(txtIdUsuario.Text, out usuarioId) )
            {
                nombre = txtNombre.Text;
                correo = txtCorreo.Text;
                telefono = txtTel.Text;

                UsuarioService userService = new UsuarioService();
                userService.agregarUsuario(nombre,usuarioId, correo, telefono);

                MessageBox.Show("Usuario registrado con éxito.");
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de usuario y un número de teléfono válidos (solo números).");
            }
        }

        private void rVerbtn_Click(object sender, RoutedEventArgs e)
        {
            UsuarioService userservice = new UsuarioService();
            List<UsuarioModel> lista = userservice.consultarUsuarios();
            dguser.ItemsSource = lista;
        }
    }
}
