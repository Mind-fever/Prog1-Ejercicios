using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Taller.Turno;

namespace Taller
{
    public class TurnoDescripcion
    {
        public int NroTrabajo { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public TipoServicio ServicioTrabajo { get; set; }
        public string DetalleVehiculo { get; set; }
    }

}

