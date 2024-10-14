using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClases
{
    public class Suscripcion
    {
        public int Codigo { get; set; }
        public int DNI { get; set; }
        public int MontoBase { get; set; }
        public DateTime FechaInicio { get; set; }
        public List<Pago> Pagos { get; set; } = new List<Pago>();
        public DateTime? FechaEliminacion { get; set; }
    }
}
