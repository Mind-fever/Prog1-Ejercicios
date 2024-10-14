using LogicaAgenciaViajes;
using System;

namespace TestLogicaAgenciaViajes
{
    public class PrincipalTest
    {
        Principal principal;
        [SetUp]
        public void Setup()
        {
            principal = new Principal();
        }

        [Test]
        public void Add_TrafficMedioDeTransporte_ShouldBeTrue()
        {
            Traffic trafficparam = new Traffic() { 
                Marca="a",
                Modelo="b",
                Año=1974,
                CapacidadPasajeros=8,
                NumeroPuertas=6,
                };

            ResultadoValidacion res = principal.CrearMedioDeTransporte(trafficparam);
            List<MedioDeTransporte> listaMediosDeTransporte= principal.DevolverListaMediosDeTransporte();
            Traffic traffic = (Traffic)listaMediosDeTransporte[0];

            Assert.That(res.Success, Is.True);
            Assert.That(res.Detail.Count(), Is.EqualTo(0));
            Assert.That(listaMediosDeTransporte.Count(), Is.EqualTo(1));
            Assert.That(traffic.Id, Is.EqualTo(1));
            Assert.That(traffic.Marca, Is.EqualTo("a"));
            Assert.That(traffic.Modelo, Is.EqualTo("b"));
            Assert.That(traffic.Año, Is.EqualTo(1974));
            Assert.That(traffic.CapacidadPasajeros, Is.EqualTo(8));
            Assert.That(traffic.NumeroPuertas, Is.EqualTo(6));
            Assert.That(traffic.FechaEliminacion, Is.Null);
        }
        [Test]
        public void Add_TrafficMedioDeTransporteNull_ShouldBeFalse()
        {
            Traffic trafficparam = new Traffic();

            ResultadoValidacion res = principal.CrearMedioDeTransporte(trafficparam);
            List<MedioDeTransporte> listaMediosDeTransporte = principal.DevolverListaMediosDeTransporte();

            Assert.That(res.Success, Is.False);
            Assert.That(res.Detail.Count(), Is.EqualTo(4));
            Assert.That(listaMediosDeTransporte.Count(), Is.EqualTo(0));
            Assert.That(res.Detail[0].Code, Is.EqualTo("Marca"));
            Assert.That(res.Detail[0].Message, Is.EqualTo("Marca incorrecta"));
            Assert.That(res.Detail[1].Code, Is.EqualTo("Modelo"));
            Assert.That(res.Detail[1].Message, Is.EqualTo("Modelo incorrecto"));
            Assert.That(res.Detail[2].Code, Is.EqualTo("CapacidadPasajeros"));
            Assert.That(res.Detail[2].Message, Is.EqualTo("Se debe colocar la cantidad de pasajeros posibles"));
            Assert.That(res.Detail[3].Code, Is.EqualTo("NumeroPuertas"));
            Assert.That(res.Detail[3].Message, Is.EqualTo("Colocar la número de puertas"));
        }
        [Test]
        public void Add_TrafficMedioDeTransporteMarcaNull_ShouldBeFalse()
        {
            Traffic avionparam = new Traffic() {
                Modelo = "b",
                Año = 1974,
                CapacidadPasajeros = 8,
                NumeroPuertas = 6,
            };

            ResultadoValidacion res = principal.CrearMedioDeTransporte(avionparam);
            List<MedioDeTransporte> listaMediosDeTransporte = principal.DevolverListaMediosDeTransporte();

            Assert.That(res.Success, Is.False);
            Assert.That(res.Detail.Count(), Is.EqualTo(1));
            Assert.That(listaMediosDeTransporte.Count(), Is.EqualTo(0));
            Assert.That(res.Detail[0].Code, Is.EqualTo("Marca"));
            Assert.That(res.Detail[0].Message, Is.EqualTo("Marca incorrecta"));
        }
        [Test]
        public void Add_TrafficMedioDeTransporteModeloNull_ShouldBeFalse()
        {
            Traffic trafficparam = new Traffic()
            {
                Marca = "a",
                Año = 1974,
                CapacidadPasajeros = 8,
                NumeroPuertas = 6,
            };

            ResultadoValidacion res = principal.CrearMedioDeTransporte(trafficparam);
            List<MedioDeTransporte> listaMediosDeTransporte = principal.DevolverListaMediosDeTransporte();

            Assert.That(res.Success, Is.False);
            Assert.That(res.Detail.Count(), Is.EqualTo(1));
            Assert.That(listaMediosDeTransporte.Count(), Is.EqualTo(0));
            Assert.That(res.Detail[0].Code, Is.EqualTo("Modelo"));
            Assert.That(res.Detail[0].Message, Is.EqualTo("Modelo incorrecto"));
        }
        [Test]
        public void Add_TrafficMedioDeTransporteCapacidadaPasajerosNull_ShouldBeFalse()
        {
            Traffic trafficparam = new Traffic()
            {
                Marca = "a",
                Modelo = "b",
                Año = 1974,
                NumeroPuertas = 6,
            };

            ResultadoValidacion res = principal.CrearMedioDeTransporte(trafficparam);
            List<MedioDeTransporte> listaMediosDeTransporte = principal.DevolverListaMediosDeTransporte();

            Assert.That(res.Success, Is.False);
            Assert.That(res.Detail.Count(), Is.EqualTo(1));
            Assert.That(listaMediosDeTransporte.Count(), Is.EqualTo(0));
            Assert.That(res.Detail[0].Code, Is.EqualTo("CapacidadPasajeros"));
            Assert.That(res.Detail[0].Message, Is.EqualTo("Se debe colocar la cantidad de pasajeros posibles"));
        }
        [Test]
        public void Add_TrafficMedioDeTransporteNumeroPuertasNull_ShouldBeFalse()
        {
            Traffic trafficparam = new Traffic()
            {
                Marca = "a",
                Modelo = "b",
                Año = 1974,
                CapacidadPasajeros = 8,
            };

            ResultadoValidacion res = principal.CrearMedioDeTransporte(trafficparam);
            List<MedioDeTransporte> listaMediosDeTransporte = principal.DevolverListaMediosDeTransporte();

            Assert.That(res.Success, Is.False);
            Assert.That(res.Detail.Count(), Is.EqualTo(1));
            Assert.That(listaMediosDeTransporte.Count(), Is.EqualTo(0));
            Assert.That(res.Detail[0].Code, Is.EqualTo("NumeroPuertas"));
            Assert.That(res.Detail[0].Message, Is.EqualTo("Colocar la número de puertas"));
        }
        [Test]
        public void Add_AvionMedioDeTransporte_ShouldBeTrue()
        {
            Avion avionparam = new Avion()
            {
                Marca = "a",
                Modelo = "b",
                Año = 1974,
                CapacidadPasajeros = 6,
                NumeroMotores=4,
                CantidadMaletas=10,
                AltitudMaxima=15000,
            };

            ResultadoValidacion res = principal.CrearMedioDeTransporte(avionparam);
            List<MedioDeTransporte> listaMediosDeTransporte = principal.DevolverListaMediosDeTransporte();
            Avion avion = (Avion)listaMediosDeTransporte[0];

            Assert.That(res.Success, Is.True);
            Assert.That(res.Detail.Count(), Is.EqualTo(0));
            Assert.That(listaMediosDeTransporte.Count(), Is.EqualTo(1));
            Assert.That(avion.Id, Is.EqualTo(1));
            Assert.That(avion.Marca, Is.EqualTo("a"));
            Assert.That(avion.Modelo, Is.EqualTo("b"));
            Assert.That(avion.Año, Is.EqualTo(1974));
            Assert.That(avion.CapacidadPasajeros, Is.EqualTo(6));
            Assert.That(avion.NumeroMotores, Is.EqualTo(4));
            Assert.That(avion.CantidadMaletas, Is.EqualTo(10));
            Assert.That(avion.AltitudMaxima, Is.EqualTo(15000));
            Assert.That(avion.FechaEliminacion, Is.Null);
        }
        [Test]
        public void Add_AvionMedioDeTransporteNull_ShouldBeFalse()
        {
            Avion avionparam = new Avion();

            ResultadoValidacion res = principal.CrearMedioDeTransporte(avionparam);
            List<MedioDeTransporte> listaMediosDeTransporte = principal.DevolverListaMediosDeTransporte();

            Assert.That(res.Success, Is.False);
            Assert.That(res.Detail.Count(), Is.EqualTo(5));
            Assert.That(listaMediosDeTransporte.Count(), Is.EqualTo(0));
            Assert.That(res.Detail[0].Code, Is.EqualTo("Marca"));
            Assert.That(res.Detail[0].Message, Is.EqualTo("Marca incorrecta"));
            Assert.That(res.Detail[1].Code, Is.EqualTo("Modelo"));
            Assert.That(res.Detail[1].Message, Is.EqualTo("Modelo incorrecto"));
            Assert.That(res.Detail[2].Code, Is.EqualTo("CapacidadPasajeros"));
            Assert.That(res.Detail[2].Message, Is.EqualTo("Se debe colocar la cantidad de pasajeros posibles"));
            Assert.That(res.Detail[3].Code, Is.EqualTo("AltitudMaxima"));
            Assert.That(res.Detail[3].Message, Is.EqualTo("Colocar la altitud máxima"));
            Assert.That(res.Detail[4].Code, Is.EqualTo("CantidadMaletas"));
            Assert.That(res.Detail[4].Message, Is.EqualTo("Colocar la cantidad de maletas"));
        }
        [Test]
        public void Add_AvionMedioDeTransporteMarcaNull_ShouldBeFalse()
        {
            Avion avionparam = new Avion()
            {
                Modelo = "b",
                Año = 1974,
                CapacidadPasajeros = 6,
                NumeroMotores = 4,
                CantidadMaletas = 10,
                AltitudMaxima = 15000,
            };

            ResultadoValidacion res = principal.CrearMedioDeTransporte(avionparam);
            List<MedioDeTransporte> listaMediosDeTransporte = principal.DevolverListaMediosDeTransporte();

            Assert.That(res.Success, Is.False);
            Assert.That(res.Detail.Count(), Is.EqualTo(1));
            Assert.That(listaMediosDeTransporte.Count(), Is.EqualTo(0));
            Assert.That(res.Detail[0].Code, Is.EqualTo("Marca"));
            Assert.That(res.Detail[0].Message, Is.EqualTo("Marca incorrecta"));
        }
        [Test]
        public void Add_AvionMedioDeTransporteModeloNull_ShouldBeFalse()
        {
            Avion avionparam = new Avion()
            {
                Marca = "a",
                Año = 1974,
                CapacidadPasajeros = 6,
                NumeroMotores = 4,
                CantidadMaletas = 10,
                AltitudMaxima = 15000,
            };

            ResultadoValidacion res = principal.CrearMedioDeTransporte(avionparam);
            List<MedioDeTransporte> listaMediosDeTransporte = principal.DevolverListaMediosDeTransporte();

            Assert.That(res.Success, Is.False);
            Assert.That(res.Detail.Count(), Is.EqualTo(1));
            Assert.That(listaMediosDeTransporte.Count(), Is.EqualTo(0));
            Assert.That(res.Detail[0].Code, Is.EqualTo("Modelo"));
            Assert.That(res.Detail[0].Message, Is.EqualTo("Modelo incorrecto"));
        }
        [Test]
        public void Add_AvionMedioDeTransporteCapacidadaPasajerosNull_ShouldBeFalse()
        {
            Avion avionparam = new Avion()
            {
                Marca = "a",
                Modelo = "b",
                Año = 1974,
                NumeroMotores = 4,
                CantidadMaletas = 10,
                AltitudMaxima = 15000,
            };

            ResultadoValidacion res = principal.CrearMedioDeTransporte(avionparam);
            List<MedioDeTransporte> listaMediosDeTransporte = principal.DevolverListaMediosDeTransporte();

            Assert.That(res.Success, Is.False);
            Assert.That(res.Detail.Count(), Is.EqualTo(1));
            Assert.That(listaMediosDeTransporte.Count(), Is.EqualTo(0));
            Assert.That(res.Detail[0].Code, Is.EqualTo("CapacidadPasajeros"));
            Assert.That(res.Detail[0].Message, Is.EqualTo("Se debe colocar la cantidad de pasajeros posibles"));
        }
        [Test]
        public void Add_AvionMedioDeTransporteAltitudMaximaNull_ShouldBeFalse()
        {
            Avion avionparam = new Avion()
            {
                Marca = "a",
                Modelo = "b",
                Año = 1974,
                CapacidadPasajeros = 6,
                NumeroMotores = 4,
                CantidadMaletas = 10,
            };

            ResultadoValidacion res = principal.CrearMedioDeTransporte(avionparam);
            List<MedioDeTransporte> listaMediosDeTransporte = principal.DevolverListaMediosDeTransporte();

            Assert.That(res.Success, Is.False);
            Assert.That(res.Detail.Count(), Is.EqualTo(1));
            Assert.That(listaMediosDeTransporte.Count(), Is.EqualTo(0));
            Assert.That(res.Detail[0].Code, Is.EqualTo("AltitudMaxima"));
            Assert.That(res.Detail[0].Message, Is.EqualTo("Colocar la altitud máxima"));
        }
        [Test]
        public void Add_AvionMedioDeTransporteCantidadMaletasNull_ShouldBeFalse()
        {
            Avion avionparam = new Avion()
            {
                Marca = "a",
                Modelo = "b",
                Año = 1974,
                CapacidadPasajeros = 6,
                NumeroMotores = 4,
                AltitudMaxima = 15000,
            };

            ResultadoValidacion res = principal.CrearMedioDeTransporte(avionparam);
            List<MedioDeTransporte> listaMediosDeTransporte = principal.DevolverListaMediosDeTransporte();

            Assert.That(res.Success, Is.False);
            Assert.That(res.Detail.Count(), Is.EqualTo(1));
            Assert.That(listaMediosDeTransporte.Count(), Is.EqualTo(0));
            Assert.That(res.Detail[0].Code, Is.EqualTo("CantidadMaletas"));
            Assert.That(res.Detail[0].Message, Is.EqualTo("Colocar la cantidad de maletas"));
        }
        [Test]
        public void Add_ColectivoMedioDeTransporte_ShouldBeTrue()
        {
            Colectivo colectivoparam = new Colectivo()
            {
                Marca = "a",
                Modelo = "b",
                Año = 1974,
                CapacidadPasajeros = 6,
                EsCocheCama = true,
                CantidadBaños = 1,
            };

            ResultadoValidacion res = principal.CrearMedioDeTransporte(colectivoparam);
            List<MedioDeTransporte> listaMediosDeTransporte = principal.DevolverListaMediosDeTransporte();
            Colectivo colectivo = (Colectivo)listaMediosDeTransporte[0];

            Assert.That(res.Success , Is.True);
            Assert.That(res.Detail.Count(), Is.EqualTo(0));
            Assert.That(listaMediosDeTransporte.Count(), Is.EqualTo(1));
            Assert.That(colectivo.Id, Is.EqualTo(1));
            Assert.That(colectivo.Marca, Is.EqualTo("a"));
            Assert.That(colectivo.Modelo, Is.EqualTo("b"));
            Assert.That(colectivo.Año, Is.EqualTo(1974));
            Assert.That(colectivo.CapacidadPasajeros, Is.EqualTo(6));
            Assert.That(colectivo.EsCocheCama, Is.True);
            Assert.That(colectivo.CantidadBaños, Is.EqualTo(1));
            Assert.That(colectivo.FechaEliminacion, Is.Null);
        }
        [Test]
        public void Add_ColectivoMedioDeTransporteNull_ShouldBeFalse()
        {
            Colectivo colectivoparam = new Colectivo();

            ResultadoValidacion res = principal.CrearMedioDeTransporte(colectivoparam);
            List<MedioDeTransporte> listaMediosDeTransporte = principal.DevolverListaMediosDeTransporte();

            Assert.That(res.Success, Is.False);
            Assert.That(res.Detail.Count(), Is.EqualTo(4));
            Assert.That(listaMediosDeTransporte.Count(), Is.EqualTo(0));
            Assert.That(res.Detail[0].Code, Is.EqualTo("Marca"));
            Assert.That(res.Detail[0].Message, Is.EqualTo("Marca incorrecta"));
            Assert.That(res.Detail[1].Code, Is.EqualTo("Modelo"));
            Assert.That(res.Detail[1].Message, Is.EqualTo("Modelo incorrecto"));
            Assert.That(res.Detail[2].Code, Is.EqualTo("CapacidadPasajeros"));
            Assert.That(res.Detail[2].Message, Is.EqualTo("Se debe colocar la cantidad de pasajeros posibles"));
            Assert.That(res.Detail[3].Code, Is.EqualTo("CantidadBaños"));
            Assert.That(res.Detail[3].Message, Is.EqualTo("Colocar la cantidad de baños, al menos debe haber."));
        }
        [Test]
        public void Add_ColectivoMedioDeTransporteMarcaNull_ShouldBeFalse()
        {
            Colectivo colectivoparam = new Colectivo()
            {
                Modelo = "b",
                Año = 1974,
                CapacidadPasajeros = 6,
                EsCocheCama = true,
                CantidadBaños = 1,
            };

            ResultadoValidacion res = principal.CrearMedioDeTransporte(colectivoparam);
            List<MedioDeTransporte> listaMediosDeTransporte = principal.DevolverListaMediosDeTransporte();

            Assert.That(res.Success, Is.False);
            Assert.That(res.Detail.Count(), Is.EqualTo(1));
            Assert.That(listaMediosDeTransporte.Count(), Is.EqualTo(0));
            Assert.That(res.Detail[0].Code, Is.EqualTo("Marca"));
            Assert.That(res.Detail[0].Message, Is.EqualTo("Marca incorrecta"));
        }
        [Test]
        public void Add_ColectivoMedioDeTransporteModeloNull_ShouldBeFalse()
        {
            Colectivo colectivoparam = new Colectivo()
            {
                Marca = "a",
                Año = 1974,
                CapacidadPasajeros = 6,
                EsCocheCama = true,
                CantidadBaños = 1,
            };

            ResultadoValidacion res = principal.CrearMedioDeTransporte(colectivoparam);
            List<MedioDeTransporte> listaMediosDeTransporte = principal.DevolverListaMediosDeTransporte();

            Assert.That(res.Success, Is.False);
            Assert.That(res.Detail.Count(), Is.EqualTo(1));
            Assert.That(listaMediosDeTransporte.Count(), Is.EqualTo(0));
            Assert.That(res.Detail[0].Code, Is.EqualTo("Modelo"));
            Assert.That(res.Detail[0].Message, Is.EqualTo("Modelo incorrecto"));
        }
        [Test]
        public void Add_ColectivoMedioDeTransporteCapacidadaPasajerosNull_ShouldBeFalse()
        {
            Colectivo colectivoparam = new Colectivo()
            {
                Marca = "a",
                Modelo = "b",
                Año = 1974,
                EsCocheCama = true,
                CantidadBaños = 1,
            };

            ResultadoValidacion res = principal.CrearMedioDeTransporte(colectivoparam);
            List<MedioDeTransporte> listaMediosDeTransporte = principal.DevolverListaMediosDeTransporte();

            Assert.That(res.Success, Is.False);
            Assert.That(res.Detail.Count(), Is.EqualTo(1));
            Assert.That(listaMediosDeTransporte.Count(), Is.EqualTo(0));
            Assert.That(res.Detail[0].Code, Is.EqualTo("CapacidadPasajeros"));
            Assert.That(res.Detail[0].Message, Is.EqualTo("Se debe colocar la cantidad de pasajeros posibles"));
        }
        [Test]
        public void Add_ColectivoMedioDeTransporteCantidadBañosNull_ShouldBeFalse()
        {
            Colectivo colectivoparam = new Colectivo()
            {
                Marca = "a",
                Modelo = "b",
                Año = 1974,
                CapacidadPasajeros = 6,
                EsCocheCama = true,
            };

            ResultadoValidacion res = principal.CrearMedioDeTransporte(colectivoparam);
            List<MedioDeTransporte> listaMediosDeTransporte = principal.DevolverListaMediosDeTransporte();

            Assert.That(res.Success, Is.False);
            Assert.That(res.Detail.Count(), Is.EqualTo(1));
            Assert.That(listaMediosDeTransporte.Count(), Is.EqualTo(0));
            Assert.That(res.Detail[0].Code, Is.EqualTo("CantidadBaños"));
            Assert.That(res.Detail[0].Message, Is.EqualTo("Colocar la cantidad de baños, al menos debe haber."));
        }
        [Test]
        public void Get_MedioDeTransporte_ShouldBeTrafficAndNotNull()
        {
            Traffic trafficparam = new Traffic()
            {
                Marca = "a",
                Modelo = "b",
                Año = 1974,
                CapacidadPasajeros = 8,
                NumeroPuertas = 6,
            };

            principal.CrearMedioDeTransporte(trafficparam);
            Traffic traffic = (Traffic)principal.ObtenerMedioDeTransporte(1);

            Assert.NotNull(traffic);
            Assert.That(traffic.Id, Is.EqualTo(1));
            Assert.That(traffic.Marca, Is.EqualTo("a"));
            Assert.That(traffic.Modelo, Is.EqualTo("b"));
            Assert.That(traffic.Año, Is.EqualTo(1974));
            Assert.That(traffic.CapacidadPasajeros, Is.EqualTo(8));
            Assert.That(traffic.NumeroPuertas, Is.EqualTo(6));
            Assert.That(traffic.FechaEliminacion, Is.Null);
        }
        [Test]
        public void Get_MedioDeTransporte_ShouldBeNull()
        {
            MedioDeTransporte medioTransporte = principal.ObtenerMedioDeTransporte(1);
            Assert.Null(medioTransporte);
        }
        [Test]
        public void Update_MedioDeTransporte_ShouldBeTrue()
        {
            Traffic trafficparam = new Traffic()
            {
                Marca = "a",
                Modelo = "b",
                Año = 1974,
                CapacidadPasajeros = 8,
                NumeroPuertas = 6,
            };
            Traffic trafficactualizar = new Traffic()
            {
                Marca = "b",
                Modelo = "c",
                Año = 1975,
                CapacidadPasajeros = 9,
            };

            principal.CrearMedioDeTransporte(trafficparam);
            ResultadoValidacion res = principal.ActualizarMedioDeTransporte(1, trafficactualizar);
            Traffic traffic = (Traffic)principal.ObtenerMedioDeTransporte(1);

            Assert.That(res.Success, Is.True);
            Assert.That(traffic.Id, Is.EqualTo(1));
            Assert.That(traffic.Marca, Is.EqualTo("b"));
            Assert.That(traffic.Modelo, Is.EqualTo("c"));
            Assert.That(traffic.Año, Is.EqualTo(1975));
            Assert.That(traffic.CapacidadPasajeros, Is.EqualTo(9));
            Assert.That(traffic.FechaEliminacion, Is.Null);
        }
        [Test]
        public void Update_MedioDeTransporte_ShouldBeFalse_NotFound()
        {
            Traffic trafficactualizar = new Traffic()
            {
                Marca = "b",
                Modelo = "c",
                Año = 1975,
                CapacidadPasajeros = 9,
            };

            ResultadoValidacion res = principal.ActualizarMedioDeTransporte(1, trafficactualizar);

            Assert.That(res.Success, Is.False);
            Assert.That(res.Detail[0].Code, Is.EqualTo("NotFound"));
            Assert.That(res.Detail[0].Message, Is.EqualTo("No se encontro el medio de transporte que se quiere editar"));
            Assert.That(res.Detail.Count(), Is.EqualTo(1));
        }
        [Test]
        public void Update_MedioDeTransporteMarcaNull_ShouldBeFalse()
        {
            Traffic trafficparam = new Traffic()
            {
                Marca = "a",
                Modelo = "b",
                Año = 1974,
                CapacidadPasajeros = 8,
                NumeroPuertas = 6,
            };
            Traffic trafficactualizar = new Traffic()
            {
                Modelo = "c",
                Año = 1975,
                CapacidadPasajeros = 9,
            };

            principal.CrearMedioDeTransporte(trafficparam);
            ResultadoValidacion res = principal.ActualizarMedioDeTransporte(1, trafficactualizar);

            Assert.That(res.Success, Is.False);
            Assert.That(res.Detail[0].Code, Is.EqualTo("Marca"));
            Assert.That(res.Detail[0].Message, Is.EqualTo("Marca incorrecta"));
        }
        [Test]
        public void Delete_MedioDeTransporte_ShouldSucceed()
        {
            Traffic trafficparam = new Traffic()
            {
                Marca = "a",
                Modelo = "b",
                Año = 1974,
                CapacidadPasajeros = 8,
                NumeroPuertas = 6,
            };

            principal.CrearMedioDeTransporte(trafficparam);
            string res = principal.EliminarMedioDeTransporte(1);
            List<MedioDeTransporte> listaMediosDeTransporte = principal.DevolverListaMediosDeTransporte();
            Traffic traffic = (Traffic)listaMediosDeTransporte[0];

            Assert.That(res, Is.EqualTo("Medio de transporte eliminado con éxico."));
            Assert.NotNull(traffic.FechaEliminacion);
        }
        [Test]
        public void Delete_MedioDeTransporteNull_ShouldFail()
        {

            string res = principal.EliminarMedioDeTransporte(1);

            Assert.That(res, Is.EqualTo("No se encontró medio de transporte para eliminar"));
        }
        [Test]
        public void Get_DescripcionTrafficMedioDeTransporte_ShouldSucceed()
        {
            Traffic trafficparam = new Traffic()
            {
                Marca = "a",
                Modelo = "b",
                Año = 1974,
                CapacidadPasajeros = 8,
                NumeroPuertas = 6,
            };

            principal.CrearMedioDeTransporte(trafficparam);
            string res = principal.ObtenerDescripcionMedioDeTransporte(1);

            Assert.That(res, Is.EqualTo("El medio de transporte es de marca: a, modelo: b, del año 1974."));
        }
        [Test]
        public void Get_DescripcionAvionMedioDeTransporte_ShouldSucceed()
        {
            Avion avionparam = new Avion()
            {
                Marca = "a",
                Modelo = "b",
                Año = 1974,
                CapacidadPasajeros = 6,
                NumeroMotores = 4,
                CantidadMaletas = 10,
                AltitudMaxima = 15000,
            };

            principal.CrearMedioDeTransporte(avionparam);
            string res = principal.ObtenerDescripcionMedioDeTransporte(1);

            Assert.That(res, Is.EqualTo("El medio de transporte es de marca: a, modelo: b, del año 1974. Este avion tiene 4 motores y puede llevar hasta 10 maletas, llegando hasta 15000.00 metros sobre el nivel del mar"));
        }
        [Test]
        public void Get_DescripcionColectivoMedioDeTransporte_ShouldSucceed()
        {
            Colectivo colectivoparam = new Colectivo()
            {
                Marca = "a",
                Modelo = "b",
                Año = 1974,
                CapacidadPasajeros = 6,
                EsCocheCama = true,
                CantidadBaños = 1,
            };

            principal.CrearMedioDeTransporte(colectivoparam);
            string res = principal.ObtenerDescripcionMedioDeTransporte(1);

            Assert.That(res, Is.EqualTo("El medio de transporte es de marca: a, modelo: b, del año 1974. Este colectivo es coche cama y tiene 1 baños."));
        }
        [Test]
        public void Get_ListaMedioDeTransportePorAño_ShouldNotBeNull()
        {
            Colectivo colectivoparam = new Colectivo()
            {
                Marca = "a",
                Modelo = "b",
                Año = 1977,
                CapacidadPasajeros = 6,
                EsCocheCama = true,
                CantidadBaños = 1,
            };
            Avion avionparam = new Avion()
            {
                Marca = "a",
                Modelo = "b",
                Año = 1974,
                CapacidadPasajeros = 6,
                NumeroMotores = 4,
                CantidadMaletas = 10,
                AltitudMaxima = 15000,
            };
            Traffic trafficparam = new Traffic()
            {
                Marca = "a",
                Modelo = "b",
                Año = 1974,
                CapacidadPasajeros = 8,
                NumeroPuertas = 6,
            };

            principal.CrearMedioDeTransporte(colectivoparam);
            principal.CrearMedioDeTransporte(avionparam);
            principal.CrearMedioDeTransporte(trafficparam);
            string res = principal.ObtenerDescripcionMedioDeTransporte(1);
            List<MedioDeTransporte> mediosFiltrados = principal.FiltrarMediosDeTransportePorAño(1976);

            Assert.That(mediosFiltrados.Count(), Is.EqualTo(1));
        }
        [Test]
        public void Get_DemoraViaje_ShouldNotBeZero()
        {
            Colectivo colectivoparam = new Colectivo()
            {
                Marca = "a",
                Modelo = "b",
                Año = 1977,
                CapacidadPasajeros = 6,
                EsCocheCama = true,
                CantidadBaños = 1,
            };
 
            principal.CrearMedioDeTransporte(colectivoparam);
            double res = principal.CalcularDemoraDeViaje(1, 500, 2, Enums.MomentoDelDia.Mañana);

            Assert.That(res, Is.EqualTo(87.75));
        }
        [Test]
        public void Get_DemoraViaje_MedioNull_ShouldBeZero()
        {

            double res = principal.CalcularDemoraDeViaje(1, 500, 2, Enums.MomentoDelDia.Mañana);

            Assert.That(res, Is.EqualTo(0.0));
        }
    }
}