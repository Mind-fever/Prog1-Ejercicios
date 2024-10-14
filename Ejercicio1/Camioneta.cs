using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public class Camioneta:Vehiculo
    {
        public bool Es4x4 { get; set; }
        public override string ObtenerDescripcion()
        {
            return $"{NumeroPlaca} - {Marca}, {Modelo}, color:{Color} - {(Es4x4 ? "Es 4x4" : "No es 4x4")}";
        }
    }
}
