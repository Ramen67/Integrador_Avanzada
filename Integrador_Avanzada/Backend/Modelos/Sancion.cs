using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador_Avanzada.Backend.Modelos
{
    public class SancionModel
    {
        public int SancionId { get; set; }
        public int PrestamoId { get; set; }
        public int UsuarioId { get; set; }
        public decimal Monto { get; set; }
        public DateTime? FechaPago { get; set; }
    }
}
