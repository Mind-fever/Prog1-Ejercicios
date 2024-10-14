using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Taller.Vehiculo;
using static Taller.Turno;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace Taller
{
    public class Taller
    {
        public List<Vehiculo> vehiculos;
        public List<Turno> turnos;
       
        private int contador = 0;

        public Taller()
        {
            vehiculos = new List<Vehiculo>();
            turnos = new List<Turno>();

        }
        public Resultado RegistrarVehiculo(int tipoVehiculo, string numeroPlaca, string marca, string modelo, int anioFabricacion, ColorEnum color, int? cantidadPuertas = null, int? litrosTanqueNafta = null, bool? es4x4 = null)
        {
            if (!Enum.IsDefined(typeof(ColorEnum), color))
            {
                return new Resultado { Success = false, Message = "El color especificado no es valido, ingrese un color del 1 al 4 del listado." };
            }
            if (vehiculos != null && vehiculos.Any(v => v.NumeroPlaca == numeroPlaca))
            {
                return new Resultado { Success = false, Message = "Ya hay un vehiculo con ese numero de placa" };
            }
            else
            {
                if (tipoVehiculo == 1)
                {
                    Auto vehiculoCreado = new Auto();
                    vehiculoCreado.NumeroPlaca = numeroPlaca;
                    vehiculoCreado.Marca = marca;
                    vehiculoCreado.Modelo = modelo;
                    vehiculoCreado.AñoFabricacion = anioFabricacion;
                    vehiculoCreado.Color = color;
                    vehiculoCreado.CantidadPuertas = cantidadPuertas ?? 0;
                    vehiculoCreado.CapacidadTanque = litrosTanqueNafta ?? 0;
                    vehiculos.Add(vehiculoCreado);
                }
                else if(tipoVehiculo == 2)
                {
                    Camioneta vehiculoCreado = new Camioneta();
                    vehiculoCreado.NumeroPlaca = numeroPlaca;
                    vehiculoCreado.Marca = marca;
                    vehiculoCreado.Modelo = modelo;
                    vehiculoCreado.AñoFabricacion = anioFabricacion;
                    vehiculoCreado.Color = color;
                    vehiculoCreado.Es4x4 = es4x4 ?? false;
                    vehiculos.Add(vehiculoCreado);
                }
                else
                {
                    return new Resultado { Success = false, Message = "No se ha ingresado un tipo de vehiculo de los especificados." };
                }

                return new Resultado { Success = true, Message = "Vehiculo añadido correctamente." };
            }
        }
        public Resultado ReservarTurno(DateTime fechaInicio, string numeroPlaca, TipoServicio servicioTrabajo)
        {
            if (!Enum.IsDefined(typeof(TipoServicio), servicioTrabajo))
            {
                return new Resultado { Success = false, Message = "No se ha podido añadir, ingrese un tipo de servicio del 1 al 3." };
            }
            if (vehiculos != null && vehiculos.Any(v => v.NumeroPlaca == numeroPlaca))
            {
                Turno turno = new Turno();
                contador++;
                turno.NumIdentificador = contador;
                turno.FechaTurno = fechaInicio;
                turno.NumeroPlaca = numeroPlaca;
                turno.ServicioTrabajo = servicioTrabajo;
                turnos.Add(turno);
                return new Resultado { Success = true, Message = "Turno añadido correctamente." };
            }
            else
            {
                return new Resultado { Success = false, Message = "No existe un auto con esa patente en el taller." };
            }
        }
        public List<TurnoDescripcion> ListadoTrabajosRealizados(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<TurnoDescripcion> trabajosRealizados = new List<TurnoDescripcion>();
            foreach (Turno turno in turnos) 
            {
                if (turno.FechaFinalizacion.HasValue && turno.FechaFinalizacion.Value >= fechaDesde && turno.FechaFinalizacion.Value <= fechaHasta)
                {
                    Vehiculo vehiculo = vehiculos.Find(v => v.NumeroPlaca == turno.NumeroPlaca);
                    TurnoDescripcion trabajoRealizado = new TurnoDescripcion();
                    trabajoRealizado.NroTrabajo = turno.NumIdentificador;
                    trabajoRealizado.FechaFinalizacion = turno.FechaFinalizacion.Value;
                    trabajoRealizado.ServicioTrabajo = turno.ServicioTrabajo;
                    trabajoRealizado.DetalleVehiculo = vehiculo.ObtenerDescripcion();
                    trabajosRealizados.Add(trabajoRealizado);
                }
            }
            trabajosRealizados = trabajosRealizados.OrderBy(t => t.FechaFinalizacion).ToList();
            return trabajosRealizados;
        }
        public List<Turno> ConsultarTurnosReservados()
        {
            List<Turno> turnosReservados = turnos.Where(t => t.FechaFinalizacion == null).ToList();
            turnosReservados = turnosReservados.OrderBy(t => t.FechaTurno).ToList();
            return turnosReservados;
        }
        public Resultado FinalizarTrabajo(int numIdentificador)
        {
            Turno trabajo = turnos.Find(t => t.NumIdentificador == numIdentificador);
            if (trabajo.FechaFinalizacion.HasValue)
            {
                return new Resultado { Success = false, Message = "El trabajo ya ha sido marcado como finalizado anteriormente."};
            }
            else
            {
                trabajo.FechaFinalizacion = DateTime.Now;
                return new Resultado { Success = true, Message = "El trabajo ha sido marcado como finalizado."};
            }
        }
    }
}
