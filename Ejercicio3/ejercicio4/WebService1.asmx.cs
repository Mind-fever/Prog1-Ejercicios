using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using LogicaAgenciaViajes;
using System.Xml.Serialization;

namespace ejercicio4
{
    [XmlInclude(typeof(LogicaAgenciaViajes.Avion))]
    [XmlInclude(typeof(LogicaAgenciaViajes.Colectivo))]
    [XmlInclude(typeof(LogicaAgenciaViajes.Traffic))]
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        Principal principal;
        public WebService1()
        {
            principal = new Principal();
            Avion avion = new Avion()
            {
                Marca = "Yamaha",
                Modelo = "Tenere",
                Año = 2000,
                CapacidadPasajeros = 10,
                CantidadMaletas = 10,
                AltitudMaxima = 15000,
                NumeroMotores = 10,
            };
            Colectivo colectivo = new Colectivo()
            {
                Marca = "Yamaha",
                Modelo = "SuperTenere",
                Año = 1500,
                CapacidadPasajeros = 10,
                EsCocheCama = true,
                CantidadBaños = 19,
            };
            Traffic traffic = new Traffic()
            {
                Marca = "Yamaha",
                Modelo = "SuperTenere",
                Año = 2020,
                CapacidadPasajeros = 10,
                NumeroPuertas = 2,
            };
            principal.CrearMedioDeTransporte(avion);
            principal.CrearMedioDeTransporte(traffic);
            principal.CrearMedioDeTransporte(colectivo);
        }

        [WebMethod]
        public ResultadoValidacion CrearMedioDeTransporteAvion(string marca, string modelo, int año, int capPas, int numMotores, int cantMaletas, double altitudMax)
        {
            Avion avion = new Avion()
            {
                Marca = marca,
                Modelo = modelo,
                Año = año,
                CapacidadPasajeros = capPas,
                CantidadMaletas = cantMaletas,
                AltitudMaxima = altitudMax,
                NumeroMotores = numMotores,
            };

            return principal.CrearMedioDeTransporte(avion);
        }
        [WebMethod]
        public ResultadoValidacion CrearMedioDeTransporteTraffic(string marca, string modelo, int año, int capPas, int numPuertas)
        {
            Traffic traffic = new Traffic()
            {
                Marca = marca,
                Modelo = modelo,
                Año = año,
                CapacidadPasajeros = capPas,
                NumeroPuertas = numPuertas,
            };

            return principal.CrearMedioDeTransporte(traffic);
        }
        [WebMethod]
        public ResultadoValidacion CrearMedioDeTransporteColectivo(string marca, string modelo, int año, int capPas, bool esCocheCama, int cantidadBaños)
        {
            Colectivo colectivo = new Colectivo()
            {
                Marca = marca,
                Modelo = modelo,
                Año = año,
                CapacidadPasajeros = capPas,
                EsCocheCama = esCocheCama,
                CantidadBaños = cantidadBaños,
            };

            return principal.CrearMedioDeTransporte(colectivo);
        }
        [WebMethod]
        public MedioDeTransporte ObtenerMedioDeTransporte(int id)
        {
            return principal.ObtenerMedioDeTransporte(id);
        }
        [WebMethod]
        public ResultadoValidacion ActualizarMedioDeTransporte(int id, string marca, string modelo, int capPas, int año)
        {
            Avion medio = new Avion()
            {
                Marca = marca,
                Modelo = modelo,
                CapacidadPasajeros = capPas,
                Año = año,
            };
            return principal.ActualizarMedioDeTransporte(id, medio);
        }
        [WebMethod]
        public string EliminarMedioDeTransporte(int id)
        {
            return principal.EliminarMedioDeTransporte(id);
        }
        [WebMethod]
        public string ObtenerDescripcionMedioDeTransporte(int id)
        {
            return principal.ObtenerDescripcionMedioDeTransporte(id);
        }
        [WebMethod]
        public List<MedioDeTransporte> FiltrarMediosDeTransportePorAño(int añoMinimo)
        {
            return principal.FiltrarMediosDeTransportePorAño(añoMinimo);
        }
        [WebMethod]
        public double CalcularDemoraDeViaje(int id, int cantidadKilometros, int cantidadProvinciasRecorridas, Enums.MomentoDelDia momentoDia)
        {
            return principal.CalcularDemoraDeViaje(id, cantidadKilometros, cantidadProvinciasRecorridas, momentoDia);
        }
    }
}
