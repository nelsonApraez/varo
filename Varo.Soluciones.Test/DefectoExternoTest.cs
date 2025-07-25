namespace Varo.Soluciones.Test
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Repositorio;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class DefectoExternoTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioDefectoExterno> repositorioDefectoExterno = null;
        private INegocioDefectoExterno negocioDefectoExterno = null;
        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioDefectoExterno = new Mock<IRepositorioDefectoExterno>();
            this.negocioDefectoExterno =
                new NegocioDefectoExterno(
                    this.repositorioBase.Object,
                    this.repositorioDefectoExterno.Object);
        }
        [TestMethod]
        public void ObtenerPorMetricaAgilTest()
        {
            DefectosExternos defectosExternos = null;
            this.repositorioDefectoExterno
                .Setup(it => it.ObtenerPorMetricaAgil(It.IsAny<int>()))
                .Returns(new DefectosExternos());
            defectosExternos = this.negocioDefectoExterno.ObtenerPorMetricaAgil(It.IsAny<int>());
            Assert.IsNotNull(defectosExternos);
        }
        [TestMethod]
        public void CrearDefectoExternoTest()
        {
            DefectosExternos defectosExternos = new DefectosExternos
            {
                Id = 1,
                IdMetricaAgil = 1,
                Reportados = 1,
                Cerrados = 1,
                Actuales = 1,
                Abiertos = 1,
                Densidad = 1
            };

            this.negocioDefectoExterno.Crear(defectosExternos);

            Assert.IsNotNull(defectosExternos);
        }
    }
}

