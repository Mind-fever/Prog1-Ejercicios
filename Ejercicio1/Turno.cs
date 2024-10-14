using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public class Turno
    {
        public int NumIdentificador { get; set; }
        public DateTime? FechaTurno { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public string NumeroPlaca { get; set; }
        public TipoServicio ServicioTrabajo { get; set; }

        public enum TipoServicio
        {
            Service_completo,
            Revisión_aire_acondicionado,
            Cambio_de_cubiertas

        }
    }
}
