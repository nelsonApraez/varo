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
    public class IntegracionesContinuasTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioIntegracionContinua> repositorioIntegracionContinua = null;
        private INegocioIntegracionContinua negocioIntegracionContinua = null;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioIntegracionContinua = new Mock<IRepositorioIntegracionContinua>();

            this.negocioIntegracionContinua =
                new NegocioIntegracionContinua(
                    this.repositorioBase.Object,
                    this.repositorioIntegracionContinua.Object);
        }

        [TestMethod]
        public void CrearIntegracionesContinuasTest()
        {

            this.repositorioIntegracionContinua.Setup(
                it => it.Crear(
                   It.IsAny<IntegracionesContinuas>()));

            this.negocioIntegracionContinua.Crear(
                It.IsAny<IntegracionesContinuas>());
        }

        [TestMethod]
        public void EliminarIntegracionesContinuasPorIdSolucionTest()
        {
            this.repositorioIntegracionContinua.Setup(
                it => it.EliminarPorIdSolucion(
                    It.IsAny<Guid>()));

            this.negocioIntegracionContinua.EliminarPorIdSolucion(
                It.IsAny<Guid>());
        }

        [TestMethod]
        public void ConsultarIntegracionesContinuasTest()
        {
            Guid id = Guid.NewGuid();
            IList<IntegracionesContinuas> integracionesContinuosActual;
            IList<IntegracionesContinuas> integracionesContinuosEsperado = new List<IntegracionesContinuas>()
            {
                new IntegracionesContinuas
                {
                    Id = id,
                    Nombre = "Integracion continuo test"
                }
            };

            this.repositorioIntegracionContinua.Setup(
                it => it
                .ConsultarPorIdSolucion(
                    It.IsAny<Guid>()))
                .Returns(
                    new List<IntegracionesContinuas>()
                    {
                        new IntegracionesContinuas
                        {
                            Id = id,
                            Nombre = "Integracion continuo test"
                        }
                    }
                );

            integracionesContinuosActual = this.negocioIntegracionContinua.ConsultarPorIdSolucion(
                It.IsAny<Guid>());

            Assert.AreEqual(integracionesContinuosEsperado.Count, integracionesContinuosActual.Count);
            Assert.AreEqual(integracionesContinuosEsperado[0].Id, integracionesContinuosActual[0].Id);
        }

        [TestMethod]
        public void ConsultarIntegracionesContinuasSinResultadoTest()
        {
            IList<IntegracionesContinuas> integracionContinuosActual;
            IList<IntegracionesContinuas> integracionContinuosEsperado = new List<IntegracionesContinuas>();

            this.repositorioIntegracionContinua.Setup(
                it => it
                .ConsultarPorIdSolucion(
                    It.IsAny<Guid>()))
                .Returns(
                    new List<IntegracionesContinuas>()
                );

            integracionContinuosActual = this.negocioIntegracionContinua.ConsultarPorIdSolucion(
                It.IsAny<Guid>());

            Assert.AreEqual(integracionContinuosEsperado.Count, integracionContinuosActual.Count);
        }
    }
}

