using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador_Avanzada.Backend.Modelos
{
    internal class UsuarioModel //no se q tan necesario sea pero lo hago por si lo llegaran a ocupar
    {
        public int usuarioId { get; set; }
        public string nombreUsuario { get; set; }
        public int registroUsuario { get; set; }
        public string correoUsuario { get; set; }
        public int telefonoUsuario { get; set; }
    }
}
