using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador_Avanzada.Backend.Modelos
{
    internal class EjemplarModel
    {
        public int ejemplarId {  get; set; }
        public int libroId {  get; set; }
        public string estado { get; set; }
        public string numInventario { get; set; }
    }
}
