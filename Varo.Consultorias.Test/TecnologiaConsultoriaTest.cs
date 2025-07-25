namespace Varo.Consultorias.Test
{
    using Varo.Consultorias.Entidades;
    using Varo.Consultorias.Negocio;
    using Varo.Consultorias.Repositorio;
    using Varo.Maestros.Entidades;
    using Varo.Transversales.Repositorio;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class TecnologiaConsultoriaTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioTecnologiaConsultoria> repositorioTecnologiaConsultoria = null;
        private INegocioTecnologiaConsultoria negocioTecnologiaConsultoria = null;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioTecnologiaConsultoria = new Mock<IRepositorioTecnologiaConsultoria>();


            this.negocioTecnologiaConsultoria =
                new NegocioTecnologiaConsultoria(
                    this.repositorioBase.Object,
                    this.repositorioTecnologiaConsultoria.Object);
        }

        [TestMethod]
        public void CrearTecnologiaPorConsultoriaTest()
        {
            this.repositorioTecnologiaConsultoria.Setup(
                it => it.Crear(
                    It.IsAny<TecnologiaConsultoria>()));

            this.negocioTecnologiaConsultoria.Crear(
                 It.IsAny<TecnologiaConsultoria>());
        }

        [TestMethod]
        public void EliminarTecnologiaPorConsultoriaPorIdConsultoriaTest()
        {
            this.repositorioTecnologiaConsultoria.Setup(
                it => it.EliminarPorIdConsultoria(
                    It.IsAny<Guid>()));

            this.negocioTecnologiaConsultoria.EliminarPorIdConsultoria(
                It.IsAny<Guid>());
        }

        [TestMethod]
        public void ConsultarTecnologiasPorIdConsultoriaTest()
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

            this.repositorioTecnologiaConsultoria.Setup(
                it => it
                .ConsultarPorIdConsultoria(It.IsAny<Guid>()))
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

            tecnologiActual = this.negocioTecnologiaConsultoria.ConsultarPorIdConsultoria(It.IsAny<Guid>());

            Assert.AreEqual(tecnologiEsperado.Count, tecnologiActual.Count);
            Assert.AreEqual(tecnologiEsperado[0].Id, tecnologiActual[0].Id);
        }

        [TestMethod]
        public void ConsultarTecnologiasPorIdConsultoriaSinResultadoTest()
        {
            Guid idTecnologia = Guid.NewGuid();
            IList<Tecnologia> tecnologiActual;
            IList<Tecnologia> tecnologiEsperado = new List<Tecnologia>();

            this.repositorioTecnologiaConsultoria.Setup(
                it => it
                .ConsultarPorIdConsultoria(It.IsAny<Guid>()))
                .Returns(
                    new List<Tecnologia>()
                );

            tecnologiActual = this.negocioTecnologiaConsultoria.ConsultarPorIdConsultoria(It.IsAny<Guid>());

            Assert.AreEqual(tecnologiEsperado.Count, tecnologiActual.Count);
        }

    }
}

