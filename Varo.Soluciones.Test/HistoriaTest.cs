namespace Varo.Soluciones.Test
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Repositorio;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Collections.Generic;

    [TestClass]
    public class HitoriaTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioHistoria> repositorioHistoria = null;
        private INegocioHistoria negocioHistorias = null;
        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioHistoria = new Mock<IRepositorioHistoria>();
            this.negocioHistorias =
                new NegocioHistoria(
                    this.repositorioBase.Object,
                    this.repositorioHistoria.Object);
        }
        [TestMethod]
        public void ObtenerPorMetricaAgilTest()
        {
            IList<Historias> historias = null;
            this.repositorioHistoria
                .Setup(it => it.ObtenerPorMetricaAgil(It.IsAny<int>()))
                .Returns(new List<Historias>());
            historias = this.negocioHistorias.ObtenerPorMetricaAgil(It.IsAny<int>());
            Assert.IsNotNull(historias);
        }
        [TestMethod]
        public void CrearHistoriaTest()
        {
            Historias historias = new Historias
            {
                Id = 1,
                IdMetricaAgil = 1,
                Numero = "1",
                Nombre = "HU 1",
                EsfuerzoEstimado = 1,
                EsfuerzoReal = 1
            };

            this.negocioHistorias.Crear(historias);
        }
    }
}

