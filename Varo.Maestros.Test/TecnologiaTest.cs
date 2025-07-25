namespace Varo.Maestros.Test
{
    using Varo.Maestros.Entidades;
    using Varo.Maestros.Negocio;
    using Varo.Maestros.Repositorio;
    using Varo.Transversales.Repositorio;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class TecnologiaTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioTecnologia> repositorioTecnologia = null;
        private INegocioTecnologia negocioTecnologia = null;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioTecnologia = new Mock<IRepositorioTecnologia>();


            this.negocioTecnologia =
                new NegocioTecnologia(
                    this.repositorioBase.Object,
                    this.repositorioTecnologia.Object);
        }


        [TestMethod]
        public void ConsultarTecnologiasPorTipoDeTecnologiaTest()
        {

            Guid idTecnologia = Guid.NewGuid();
            IList<Tecnologia> tecnologiActual;
            IList<Tecnologia> tecnologiEsperado = new List<Tecnologia>
            {
                new Tecnologia
                {
                    Id = idTecnologia,
                    Nombre = "Azure"
                }
            };

            this.repositorioTecnologia.Setup(
                it => it
                .ConsultarPorTipoDeTecnologia(It.IsAny<byte>()))
                .Returns(
                    new List<Tecnologia>
                    {
                        new Tecnologia
                        {
                            Id = idTecnologia,
                            Nombre = "Azure"
                        }
                    }
                );

            tecnologiActual = this.negocioTecnologia.ConsultarPorTipoDeTecnologia(It.IsAny<byte>());

            Assert.AreEqual(tecnologiEsperado.Count, tecnologiActual.Count);
            Assert.AreEqual(tecnologiEsperado[0].Id, tecnologiActual[0].Id);
        }

        [TestMethod]
        public void ConsultarTecnologiasPorTipoDeTecnologiaSinResultadoTest()
        {
            Guid idTecnologia = Guid.NewGuid();
            IList<Tecnologia> tecnologiActual;
            IList<Tecnologia> tecnologiEsperado = new List<Tecnologia>();

            this.repositorioTecnologia.Setup(
                it => it
                .ConsultarPorTipoDeTecnologia(It.IsAny<byte>()))
                .Returns(
                    new List<Tecnologia>()
                );

            tecnologiActual = this.negocioTecnologia.ConsultarPorTipoDeTecnologia(It.IsAny<byte>());

            Assert.AreEqual(tecnologiEsperado.Count, tecnologiActual.Count);
        }
    }
}

