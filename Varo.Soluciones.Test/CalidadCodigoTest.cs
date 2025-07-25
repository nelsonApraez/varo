namespace Varo.Soluciones.Test
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Repositorio;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class CalidadCodigoTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioCalidadCodigo> repositorioCalidadCodigo = null;
        private INegocioCalidadCodigo negocioCalidadCodigo = null;
        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioCalidadCodigo = new Mock<IRepositorioCalidadCodigo>();
            this.negocioCalidadCodigo =
                new NegocioCalidadCodigo(
                    this.repositorioBase.Object,
                    this.repositorioCalidadCodigo.Object);
        }
        [TestMethod]
        public void ObtenerPorMetricaAgilTest()
        {
            CalidadCodigo calidadCodigo = null;
            this.repositorioCalidadCodigo
                .Setup(it => it.ObtenerPorMetricaAgil(It.IsAny<int>()))
                .Returns(new CalidadCodigo());
            calidadCodigo = this.negocioCalidadCodigo.ObtenerPorMetricaAgil(It.IsAny<int>());
            Assert.IsNotNull(calidadCodigo);
        }
        [TestMethod]
        public void CrearCalidadCodigoTest()
        {
            CalidadCodigo calidadCodigo = new CalidadCodigo
            {
                Id = 1,
                IdMetricaAgil = 1,
                Bugs = 1,
                Vulnerabilidades = 1,
                DeudaTecnica = 1,
                Cobertura = 1,
                Duplicado = 1
            };

            this.negocioCalidadCodigo.Crear(calidadCodigo);

            Assert.IsNotNull(calidadCodigo);
        }
    }
}

