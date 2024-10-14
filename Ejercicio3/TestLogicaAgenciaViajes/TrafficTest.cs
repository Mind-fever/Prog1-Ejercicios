using LogicaAgenciaViajes;
using System;

namespace TestLogicaAgenciaViajes
{
    public class TrafficTest
    {
        Traffic traffic;
        [SetUp]
        public void Setup()
        {
            traffic = new Traffic();
        }

//COMENTARIO: EL METODO PARA OBTENER DESCRIPCIÓN DE LA TRAFFIC TAMBIEN DEBE TESTEARSE

        [Test]
        public void Get_DemoraViajeEnMinutosTrafficMañana_ShouldNotBeZero()
        {
            double res = traffic.DevolverDemoraViajeEnMinutos(500, 2, Enums.MomentoDelDia.Mañana);

            Assert.That(res, Is.EqualTo(43.75));
        }
        [Test]
        public void Get_DemoraViajeEnMinutosTrafficTarde_ShouldNotBeZero()
        {
            double res = traffic.DevolverDemoraViajeEnMinutos(500, 2, Enums.MomentoDelDia.Tarde);

            Assert.That(res, Is.EqualTo(47.25));
        }
        [Test]
        public void Get_DemoraViajeEnMinutosTrafficNoche_ShouldNotBeZero()
        {
            double res = traffic.DevolverDemoraViajeEnMinutos(500, 2, Enums.MomentoDelDia.Noche);

            Assert.That(res, Is.EqualTo(40.25));
        }
    }
}