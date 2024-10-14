using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public class Auto : Vehiculo
    {

        public int CantidadPuertas { get; set; }
        public int CapacidadTanque { get; set; }
        public override string ObtenerDescripcion()
        {  
            return $"{NumeroPlaca} - {Marca}, {Modelo}, color:{Color} - {CantidadPuertas} - {CapacidadTanque}";
        }
    }
    
}
