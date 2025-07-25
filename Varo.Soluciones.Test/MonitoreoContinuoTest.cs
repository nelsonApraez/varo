namespace Varo.Soluciones.Test
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Repositorio;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class MonitoreoContinuo
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioMonitoreoContinuo> repositorioMonitoreoContinuo = null;
        private INegocioMonitoreoContinuo negocioMonitoreoContinuo = null;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioMonitoreoContinuo = new Mock<IRepositorioMonitoreoContinuo>();
            this.negocioMonitoreoContinuo = new NegocioMonitoreoContinuo(
                this.repositorioBase.Object,
                this.repositorioMonitoreoContinuo.Object);
        }

        [TestMethod]
        public void CrearMonitoreoContinuoTest()
        {
            MonitoreosContinuos monitoreosContinuos = new MonitoreosContinuos
            {
                Id = Guid.NewGuid(),
                IdSolucion = Guid.NewGuid(),
                Nombre = "Prueba monitoreo",
                UrlMonitoreo = "http://www.pruebamonitoreo.com"
            };

            this.negocioMonitoreoContinuo.Crear(monitoreosContinuos);

            Assert.IsNotNull(monitoreosContinuos);
        }

        [TestMethod]
        public void ObtenerMonitoreoContinuoPorIdSolucionTest()
        {
            Guid id = Guid.NewGuid();
            IList<MonitoreosContinuos> monitoreosContinuos = new List<MonitoreosContinuos>()
            {
                new MonitoreosContinuos
                {
                    Id = Guid.NewGuid(),
                    IdSolucion = Guid.NewGuid(),
                    Nombre = "Prueba monitoreo",
                    UrlMonitoreo = "http://www.pruebamonitoreo.com"
                }
            };

            this.repositorioMonitoreoContinuo.Setup(
                it => it
                .ConsultarPorIdSolucion(
                    It.IsAny<Guid>()))
                .Returns(
                    new List<MonitoreosContinuos>()
                    {
                        new MonitoreosContinuos
                        {
                            Id = Guid.NewGuid(),
                            IdSolucion = Guid.NewGuid(),
                            Nombre = "Prueba monitoreo",
                            UrlMonitoreo = "http://www.pruebamonitoreo.com"

                        }
                    }
                );

            monitoreosContinuos = this.negocioMonitoreoContinuo.ConsultarPorIdSolucion(It.IsAny<Guid>());

            Assert.AreEqual(monitoreosContinuos.Count, monitoreosContinuos.Count);
            Assert.AreEqual(monitoreosContinuos[0].Id, monitoreosContinuos[0].Id);
        }

        [TestMethod]
        public void EliminarMonitoreosContinuosPorIdSolucionTest()
        {
            this.repositorioMonitoreoContinuo.Setup(
                it => it.EliminarPorIdSolucion(
                    It.IsAny<Guid>()));

            this.negocioMonitoreoContinuo.EliminarPorIdSolucion(
                It.IsAny<Guid>());
        }
    }
}

