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
    public class DesplieguesContinuosTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioDespliegueContinuo> repositorioDespliegueContinuo = null;
        private INegocioDespliegueContinuo negocioDespliegueContinuo = null;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioDespliegueContinuo = new Mock<IRepositorioDespliegueContinuo>();

            this.negocioDespliegueContinuo =
                new NegocioDespliegueContinuo(
                    this.repositorioBase.Object,
                    this.repositorioDespliegueContinuo.Object);
        }

        [TestMethod]
        public void CrearDesplieguesContinuosTest()
        {
            this.repositorioDespliegueContinuo.Setup(
                it => it.Crear(
                   It.IsAny<DesplieguesContinuos>()));

            this.negocioDespliegueContinuo.Crear(
                It.IsAny<DesplieguesContinuos>());
        }

        [TestMethod]
        public void EliminarDesplieguesContinuosPorIdSolucionTest()
        {
            this.repositorioDespliegueContinuo.Setup(
                it => it.EliminarPorIdSolucion(
                    It.IsAny<Guid>()));

            this.negocioDespliegueContinuo.EliminarPorIdSolucion(
                It.IsAny<Guid>());
        }

        [TestMethod]
        public void ConsultarDesplieguesContinuosTest()
        {
            Guid id = Guid.NewGuid();
            IList<DesplieguesContinuos> desplieguesContinuosActual;
            IList<DesplieguesContinuos> desplieguesContinuosEsperado = new List<DesplieguesContinuos>()
            {
                new DesplieguesContinuos
                {
                    Id = id,
                    Nombre = "Despliegue continuo test"
                }
            };

            this.repositorioDespliegueContinuo.Setup(
                it => it
                .ConsultarPorIdSolucion(
                    It.IsAny<Guid>()))
                .Returns(
                    new List<DesplieguesContinuos>()
                    {
                        new DesplieguesContinuos
                        {
                            Id = id,
                            Nombre = "Despliegue continuo test"
                        }
                    }
                );

            desplieguesContinuosActual = this.negocioDespliegueContinuo.ConsultarPorIdSolucion(
                It.IsAny<Guid>());

            Assert.AreEqual(desplieguesContinuosEsperado.Count, desplieguesContinuosActual.Count);
            Assert.AreEqual(desplieguesContinuosEsperado[0].Id, desplieguesContinuosActual[0].Id);
        }

        [TestMethod]
        public void ConsultarDesplieguesContinuosSinResultadoTest()
        {
            Guid id = Guid.NewGuid();
            IList<DesplieguesContinuos> desplieguesContinuosActual;
            IList<DesplieguesContinuos> desplieguesContinuosEsperado = new List<DesplieguesContinuos>();

            this.repositorioDespliegueContinuo.Setup(
                it => it
                .ConsultarPorIdSolucion(
                    It.IsAny<Guid>()))
                .Returns(
                    new List<DesplieguesContinuos>()
                );

            desplieguesContinuosActual = this.negocioDespliegueContinuo.ConsultarPorIdSolucion(
                It.IsAny<Guid>());

            Assert.AreEqual(desplieguesContinuosEsperado.Count, desplieguesContinuosActual.Count);
        }
    }
}

