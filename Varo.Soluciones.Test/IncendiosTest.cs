namespace Varo.Soluciones.Test
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Repositorio;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class IncendiosTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioIncendio> repositorioIncendio = null;
        private INegocioIncendio negocioIncendio = null;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioIncendio = new Mock<IRepositorioIncendio>();
            this.negocioIncendio =
                new NegocioIncendio(
                    this.repositorioBase.Object,
                    this.repositorioIncendio.Object);
        }

        [TestMethod]
        public void ObtenerPorMetricaAgilTest()
        {
            Incendios incendios = null;
            this.repositorioIncendio
                .Setup(it => it.ObtenerPorMetricaAgil(It.IsAny<int>()))
                .Returns(new Incendios());
            incendios = this.negocioIncendio.ObtenerPorMetricaAgil(It.IsAny<int>());
            Assert.IsNotNull(incendios);
        }

        [TestMethod]
        public void CrearIncendioTest()
        {
            Incendios incendios = new Incendios
            {
                Id = 1,
                IdMetricaAgil = 1,
                Reportados = 1,
                Solucionados = 1
            };

            this.negocioIncendio.Crear(incendios);

            Assert.IsNotNull(incendios);
        }
    }
}

