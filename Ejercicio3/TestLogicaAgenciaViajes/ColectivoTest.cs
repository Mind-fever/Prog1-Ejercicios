using LogicaAgenciaViajes;
using System;

namespace TestLogicaAgenciaViajes
{
    public class ColectivoTest
    {
        Colectivo colectivo;
        [SetUp]
        public void Setup()
        {
            colectivo = new Colectivo();
        }
        [Test]
        public void Get_DescripcionColectivoMedioDeTransporte_ShouldSucceed()
        {
            colectivo = new Colectivo()
            {
                Marca = "a",
                Modelo = "b",
                Año = 1974,
                CapacidadPasajeros = 6,
                EsCocheCama = true,
                CantidadBaños = 1,
            };

            string res = colectivo.DevolverDescripcion();

            Assert.That(res, Is.EqualTo("El medio de transporte es de marca: a, modelo: b, del año 1974. Este colectivo es coche cama y tiene 1 baños."));
        }
        [Test]
        public void Get_DemoraViajeEnMinutosColectivoMañana_ShouldNotBeZero()
        {
            double res = colectivo.DevolverDemoraViajeEnMinutos(500, 2, Enums.MomentoDelDia.Mañana);

            Assert.That(res, Is.EqualTo(87.75));
        }
        [Test]
        public void Get_DemoraViajeEnMinutosColectivoTarde_ShouldNotBeZero()
        {
            double res = colectivo.DevolverDemoraViajeEnMinutos(500, 2, Enums.MomentoDelDia.Tarde);

            Assert.That(res, Is.EqualTo(94.25));
        }
        [Test]
        public void Get_DemoraViajeEnMinutosColectivoNoche_ShouldNotBeZero()
        {
            double res = colectivo.DevolverDemoraViajeEnMinutos(500, 2, Enums.MomentoDelDia.Noche);

            Assert.That(res, Is.EqualTo(100.75));
        }
    }
}