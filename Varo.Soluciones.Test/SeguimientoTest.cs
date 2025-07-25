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
    public class SeguimientoTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioSeguimiento> repositorioSeguimiento = null;
        private INegocioSeguimiento negocioSeguimiento = null;
        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioSeguimiento = new Mock<IRepositorioSeguimiento>();
            this.negocioSeguimiento =
                new NegocioSeguimiento(
                    this.repositorioBase.Object,
                    this.repositorioSeguimiento.Object);
        }
        [TestMethod]
        public void ObtenerPorMetricaAgilTest()
        {
            IList<Seguimiento> Seguimiento = null;
            this.repositorioSeguimiento
                .Setup(it => it.Consultar(It.IsAny<int>()))
                .Returns(new List<Seguimiento>());
            Seguimiento = this.negocioSeguimiento.Consultar(It.IsAny<int>());
            Assert.IsNotNull(Seguimiento);
        }
        [TestMethod]
        public void CrearSeguimientoTestValorNull()
        {
            Seguimiento seguimiento = null;
            this.repositorioSeguimiento
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioSeguimiento
                .Setup(it => it.Crear(It.IsAny<Seguimiento>()));
            this.negocioSeguimiento.Crear(seguimiento);
            Assert.IsNull(seguimiento);
        }

        [TestMethod]
        public void CrearSeguimientoTest()
        {
            Seguimiento seguimiento = new Seguimiento()
            {
                ListaSeguimiento = new List<Seguimiento>()
                {
                    new Seguimiento()
                    {
                        Id = 1,
                        IdAccionesMejora = 1,
                        Observacion = "Prueba seguimiento",
                        Usuario = "wcalderon"
                    }
                }
            };

            this.negocioSeguimiento.Crear(seguimiento);

            Assert.IsNotNull(seguimiento);
        }
    }
}

