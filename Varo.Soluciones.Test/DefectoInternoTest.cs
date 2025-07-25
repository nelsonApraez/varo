namespace Varo.Soluciones.Test
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Repositorio;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class DefectoInternoTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioDefectoInterno> repositorioDefectoInterno = null;
        private INegocioDefectoInterno negocioDefectoInterno = null;
        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioDefectoInterno = new Mock<IRepositorioDefectoInterno>();
            this.negocioDefectoInterno =
                new NegocioDefectoInterno(
                    this.repositorioBase.Object,
                    this.repositorioDefectoInterno.Object);
        }
        [TestMethod]
        public void ObtenerPorMetricaAgilTest()
        {
            DefectosInternos defectosInternos = null;
            this.repositorioDefectoInterno
                .Setup(it => it.ObtenerPorMetricaAgil(It.IsAny<int>()))
                .Returns(new DefectosInternos());
            defectosInternos = this.negocioDefectoInterno.ObtenerPorMetricaAgil(It.IsAny<int>());
            Assert.IsNotNull(defectosInternos);
        }
        [TestMethod]
        public void CrearDefectoInternoTest()
        {
            DefectosInternos defectosInternos = new DefectosInternos
            {
                Id = 1,
                IdMetricaAgil = 1,
                Reportados = 1,
                Cerrados = 1,
                Actuales = 1,
                Abiertos = 1
            };

            this.negocioDefectoInterno.Crear(defectosInternos);

            Assert.IsNotNull(defectosInternos);
        }
    }
}

