namespace Varo.Maestros.Test
{
    using Varo.Maestros.Negocio;
    using Varo.Maestros.Repositorio;
    using Varo.Transversales.Entidades;
    using Varo.Transversales.Repositorio;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Collections.Generic;

    [TestClass]
    public class OficinaTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioOficinas> repositorioOficina = null;
        private INegocioOficinas negocioOficina = null;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioOficina = new Mock<IRepositorioOficinas>();


            this.negocioOficina =
                new NegocioOficinas(
                    this.repositorioBase.Object,
                    this.repositorioOficina.Object);
        }


        [TestMethod]
        public void ConsultarOficinasPorIdGsdcConResultadoTest()
        {
            IList<ItemMaestro> oficinasActual;
            IList<ItemMaestro> oficinasEsperada = new List<ItemMaestro> {
                            new ItemMaestro
                            {
                                Id = 1,
                                Nombre = "Barranquilla"
                            },
                            new ItemMaestro
                            {
                                Id = 2,
                                Nombre = "Bogotá"
                            }
                 };

            this.repositorioOficina
              .Setup(
                  it => it.ConsultarOficinaPorIdGsdc(It.IsAny<byte>()))
                  .Returns(
                 new List<ItemMaestro> {
                            new ItemMaestro
                            {
                                Id = 1,
                                Nombre = "Barranquilla"
                            },
                            new ItemMaestro
                            {
                                Id = 2,
                                Nombre = "Bogotá"
                            }
                 });

            oficinasActual = this.negocioOficina.ConsultarOficinaPorIdGsdc(1);

            Assert.AreEqual(oficinasEsperada.Count, oficinasActual.Count);
        }

        [TestMethod]
        public void ConsultarOficinasPorIdGsdcSinResultadoTest()
        {
            IList<ItemMaestro> oficinasActual;
            IList<ItemMaestro> oficinasEsperada = new List<ItemMaestro>();

            this.repositorioOficina
              .Setup(
                  it => it.ConsultarOficinaPorIdGsdc(It.IsAny<byte>()))
                  .Returns(
                 new List<ItemMaestro>());

            oficinasActual = this.negocioOficina.ConsultarOficinaPorIdGsdc(1);

            Assert.AreEqual(oficinasEsperada.Count, oficinasActual.Count);
        }
    }
}

