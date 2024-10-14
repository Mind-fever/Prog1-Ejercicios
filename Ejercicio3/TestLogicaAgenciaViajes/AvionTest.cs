using LogicaAgenciaViajes;
using System;

namespace TestLogicaAgenciaViajes
{
    public class AvionTest
    {
        Avion avion;
        [SetUp]
        public void Setup()
        {
            avion = new Avion();
        }
        [Test]
        public void Get_DescripcionAvionMedioDeTransporte_ShouldSucceed()
        {
            avion = new Avion()
            {
                Marca = "a",
                Modelo = "b",
                Año = 1974,
                CapacidadPasajeros = 6,
                NumeroMotores = 4,
                CantidadMaletas = 10,
                AltitudMaxima = 15000,
            };

            string res = avion.DevolverDescripcion();

            Assert.That(res, Is.EqualTo("El medio de transporte es de marca: a, modelo: b, del año 1974. Este avion tiene 4 motores y puede llevar hasta 10 maletas, llegando hasta 15000.00 metros sobre el nivel del mar"));
        }
        [Test]
        public void Get_DemoraViajeEnMinutosAvionMañana_ShouldNotBeZero()
        {
            double res = avion.DevolverDemoraViajeEnMinutos(500, 2, Enums.MomentoDelDia.Mañana);

            Assert.That(res, Is.EqualTo(2.5));
        }
        [Test]
        public void Get_DemoraViajeEnMinutosAvionTarde_ShouldNotBeZero()
        {
            double res = avion.DevolverDemoraViajeEnMinutos(500, 2, Enums.MomentoDelDia.Tarde);

            Assert.That(res, Is.EqualTo(2.7000000000000002));
        }
        [Test]
        public void Get_DemoraViajeEnMinutosAvionNoche_ShouldNotBeZero()
        {
            double res = avion.DevolverDemoraViajeEnMinutos(500, 2, Enums.MomentoDelDia.Noche);

            Assert.That(res, Is.EqualTo(2.7000000000000002));
        }
    }
}