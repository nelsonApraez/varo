using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varo.Soluciones.Test
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Soluciones.Repositorio;
    using Varo.Soluciones.SistemasExternos;
    using Varo.Transversales.Repositorio;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class SolucionesConsultarPorParametroSolucionTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;

        private Mock<IRepositorioSolucion> repositorioSolucion = null;

        private Mock<IArgusAdaptador> adaptadorArgus = null;

        private INegocioSoluciones negocioSoluciones = null;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioSolucion = new Mock<IRepositorioSolucion>();
            this.adaptadorArgus = new Mock<IArgusAdaptador>();

            this.negocioSoluciones =
                new NegocioSoluciones(
                    this.repositorioBase.Object,
                    this.repositorioSolucion.Object,
                    this.adaptadorArgus.Object);
        }

        [TestMethod]
        public void ConsultarPorParametroSolucionTest()
        {
            Solucion solucion = new Solucion();

            this.repositorioSolucion.Setup(
                it => it.ConsultarPorParametro(
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<string>())).Returns(
                It.IsAny<List<Solucion>>());

            this.negocioSoluciones.ConsultarPorParametro(
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>());
        }
    }
}

