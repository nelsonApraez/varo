namespace Varo.Soluciones.Test
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Repositorio;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class HitoriayEsfuerzoTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioHistoriayEsfuerzo> repositorioHistoriayEsfuerzo = null;
        private INegocioHistoriayEsfuerzo negocioHistoriasyEsfuerzo = null;
        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioHistoriayEsfuerzo = new Mock<IRepositorioHistoriayEsfuerzo>();
            this.negocioHistoriasyEsfuerzo =
                new NegocioHistoriayEsfuerzo(
                    this.repositorioBase.Object,
                    this.repositorioHistoriayEsfuerzo.Object);
        }
        [TestMethod]
        public void ObtenerPorMetricaAgilTest()
        {
            HistoriasyEsfuerzos historiasyEsfuerzos = null;
            this.repositorioHistoriayEsfuerzo
                .Setup(it => it.ObtenerPorMetricaAgil(It.IsAny<int>()))
                .Returns(new HistoriasyEsfuerzos());
            historiasyEsfuerzos = this.negocioHistoriasyEsfuerzo.ObtenerPorMetricaAgil(It.IsAny<int>());
            Assert.IsNotNull(historiasyEsfuerzos);
        }
        [TestMethod]
        public void CrearHistoriayEsfuerzoTest()
        {
            HistoriasyEsfuerzos historiasyEsfuerzos = new HistoriasyEsfuerzos
            {
                Id = 1,
                IdMetricaAgil = 1,
                HistoriasEstimadas = 1,
                HistoriasLogradas = 1,
                EsfuerzoEstimado = 1,
                EsfuerzoLogrado = 1
            };

            this.negocioHistoriasyEsfuerzo.Crear(historiasyEsfuerzos);
        }
    }
}

