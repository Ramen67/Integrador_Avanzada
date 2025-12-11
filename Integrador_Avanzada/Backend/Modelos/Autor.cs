using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador_Avanzada.Backend.Modelos
{
    internal class AutorModel
    {
        public int autorId {  get; set; }
        public string autorName { get; set; }
        public string nacionalidad { get; set; }
        public DateOnly fechaNacimiento { get; set; }
    }
}
