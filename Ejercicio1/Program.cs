using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using static Taller.Turno;
using System.Threading.Tasks;
using static Taller.Vehiculo;
using System.Security.Cryptography;

namespace Taller
{
    class Program
    {
        public static void Main(string[] args)
        {   Taller taller = new Taller();
            bool continuar=true;
            while (continuar)
            {
                Console.WriteLine("Bienvenido, seleccione la accion a realizar:");
                Console.WriteLine(@"
                    1- Agregar vehiculo 
                    2- Reservar un turno
                    3- Consultar un trabajo realizado
                    4- Consultar turnos ya reservados
                    5- Marcar un trabajo como finalizado
                    0- Salir
                    ");
                int opt = Convert.ToInt32(Console.ReadLine());
                switch (opt) {
                    case 1:
                        {
                            Console.WriteLine("Desea ingresar un auto, o una camioneta? 1=Auto; 2=Camioneta");
                            int tipoVehiculo = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingresar numero de placa:");
                            string numeroPlaca = Console.ReadLine();
                            Console.WriteLine("Ingresar Marca:");
                            string marca = Console.ReadLine();
                            Console.WriteLine("Ingresar Modelo:");
                            string modelo = Console.ReadLine();
                            Console.WriteLine("Ingresar año de fabricacion:");
                            int añoFabricacion = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingresar color(1=Rojo, 2=Negro, 3=Blanco, 4=Gris):");
                            ColorEnum color = (ColorEnum)Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingresar cantidad de puertas:");
                            int cantidadPuertas = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingresar capacidad del tanque de combustible:");
                            int capacidadTanque = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingresar si es 4x4(true, false):");
                            bool es4x4 = bool.Parse(Console.ReadLine());
                            Resultado Mensaje = taller.RegistrarVehiculo(tipoVehiculo, numeroPlaca, marca, modelo, añoFabricacion, color, cantidadPuertas, capacidadTanque, es4x4);
                            Console.WriteLine(Mensaje.Message);
                            Console.WriteLine("Pulse enter para continuar.");
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Ingrese la patente del vehiculo:");
                            string numeroPlaca = Console.ReadLine();
                            Console.WriteLine("Ingrese el tipo de trabajo a realizar(1=Service completo, 2=Revision de aire acondicionado, 3=Cambio de cubiertas):");
                            TipoServicio servicioTrabajo = (TipoServicio)Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingrese la fecha y hora de comienzo del trabajo (dia/mes/año 00:00):");
                            DateTime fechaHoraInicio = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                            Resultado Mensaje = taller.ReservarTurno(fechaHoraInicio, numeroPlaca, servicioTrabajo);
                            Console.WriteLine(Mensaje.Message);
                            Console.WriteLine("Pulse enter para continuar.");
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Ingrese la primera fecha desde donde empezara el listado (dia/mes/año 00:00):");
                            DateTime fechaDesde= DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                            Console.WriteLine("Ingrese la fecha final (dia/mes/año 00:00):");
                            DateTime fechaHasta = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                            List<TurnoDescripcion> listadoTrabajos = taller.ListadoTrabajosRealizados(fechaDesde, fechaHasta);
                            foreach (TurnoDescripcion trabajo in listadoTrabajos)
                            {
                                Console.WriteLine($"Nro de reparacion: {trabajo.NroTrabajo}");
                                Console.WriteLine($"Fecha de finalizacion: {trabajo.FechaFinalizacion.ToString("dd/MM/yyyy HH:mm")}");
                                Console.WriteLine($"Trabajo realizado: {trabajo.ServicioTrabajo.ToString()}");
                                Console.WriteLine($"Detalle del vehículo: {trabajo.DetalleVehiculo}");
                                Console.WriteLine("-----------------------------------------");
                            }
                            Console.WriteLine("Pulse enter para continuar.");
                            Console.ReadKey();
                            break;
                        }
                    case 4:
                        {
                            List<Turno> turnosSinFinalizar = taller.ConsultarTurnosReservados();
                            foreach (Turno turno in turnosSinFinalizar)
                            {
                                Console.WriteLine($"Nro de reparacion: {turno.NumIdentificador}");
                                Console.WriteLine($"Fecha y Hora de Reserva: {turno.FechaTurno}");
                                Console.WriteLine($"Patente del Vehiculo: {turno.NumeroPlaca}");
                                Console.WriteLine($"Trabajo por realizar: {turno.ServicioTrabajo.ToString()}");
                                Console.WriteLine("-----------------------------------------");
                            }
                            Console.WriteLine("Pulse enter para continuar.");
                            Console.ReadKey();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Ingrese el numero del trabajo que desea marcar como finalizado:");
                            int numTrabajo = Convert.ToInt32(Console.ReadLine());
                            Resultado mensaje = taller.FinalizarTrabajo(numTrabajo);
                            Console.WriteLine(mensaje.Message);
                            Console.WriteLine("Pulse enter para continuar.");
                            Console.ReadKey();
                            break;
                        }
                    case 00:
                        {
                            continuar = false;
                            break;
                        }
                }
            }
        }
    }
}
