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
    public class TecnologiaSolucionTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioTecnologiaSolucion> repositorioTecnologiaSolucion = null;
        private INegocioTecnologiaSolucion negocioTecnologiaSolucion = null;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioTecnologiaSolucion = new Mock<IRepositorioTecnologiaSolucion>();


            this.negocioTecnologiaSolucion =
                new NegocioTecnologiaSolucion(
                    this.repositorioBase.Object,
                    this.repositorioTecnologiaSolucion.Object);
        }

        [TestMethod]
        public void CrearTecnologiaPorSolucionTest()
        {
            this.repositorioTecnologiaSolucion.Setup(
                it => it.Crear(
                    It.IsAny<TecnologiaSolucion>()));

            this.negocioTecnologiaSolucion.Crear(
                 It.IsAny<TecnologiaSolucion>());
        }

        [TestMethod]
        public void EliminarTecnologiaPorSolucionPorIdSolucionTest()
        {
            this.repositorioTecnologiaSolucion.Setup(
                it => it.EliminarPorIdSolucion(
                    It.IsAny<Guid>()));

            this.negocioTecnologiaSolucion.EliminarPorIdSolucion(
                It.IsAny<Guid>());
        }

        [TestMethod]
        public void ConsultarTecnologiasPorIdSolucionTest()
        {
            Guid idTecnologia = Guid.NewGuid();
            IList<TecnologiaSolucion> tecnologiActual;
            IList<TecnologiaSolucion> tecnologiEsperado = new List<TecnologiaSolucion>
            {
                new TecnologiaSolucion
                {
                    Id = idTecnologia,
                    Nombre = "Azure"
                }
            };

            this.repositorioTecnologiaSolucion.Setup(
                it => it
                .ConsultarPorIdSolucion(It.IsAny<Guid>(), It.IsAny<string>()))
                .Returns(
                    new List<TecnologiaSolucion>
                    {
                        new TecnologiaSolucion
                        {
                            Id = idTecnologia,
                            Nombre = "Azure"
                        }
                    }
                );

            tecnologiActual = this.negocioTecnologiaSolucion.ConsultarPorIdSolucion(It.IsAny<Guid>(), It.IsAny<string>());

            Assert.AreEqual(tecnologiEsperado.Count, tecnologiActual.Count);
            Assert.AreEqual(tecnologiEsperado[0].Id, tecnologiActual[0].Id);
        }

        [TestMethod]
        public void ConsultarTecnologiasPorIdSolucionSinResultadoTest()
        {
            Guid idTecnologia = Guid.NewGuid();
            IList<TecnologiaSolucion> tecnologiActual;
            IList<TecnologiaSolucion> tecnologiEsperado = new List<TecnologiaSolucion>();

            this.repositorioTecnologiaSolucion.Setup(
                it => it
                .ConsultarPorIdSolucion(It.IsAny<Guid>(), It.IsAny<string>()))
                .Returns(
                    new List<TecnologiaSolucion>()
                );

            tecnologiActual = this.negocioTecnologiaSolucion.ConsultarPorIdSolucion(It.IsAny<Guid>(), It.IsAny<string>());

            Assert.AreEqual(tecnologiEsperado.Count, tecnologiActual.Count);
        }

    }
}

