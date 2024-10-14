using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public abstract class Vehiculo
    {
        public string NumeroPlaca { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AñoFabricacion { get; set; }
        public ColorEnum Color { get; set; }
        public enum ColorEnum 
        {
            Rojo=1,
            Negro,
            Blanco,
            Gris
        }

        public virtual string ObtenerDescripcion()
        {
            return null;
        }
    }
}
