using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador_Avanzada.Backend.Modelos
{
    internal class LibroModel
    {
        public int libroId { get; set; }
        public string libroTitulo { get; set; }
        public string libroISBN { get; set; }
        public int libroAPublicacion { get; set; }
        public string libroAutor { get; set; }
        public string libroEditorial { get; set; }
    }
}
