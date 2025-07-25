namespace Varo.Soluciones.Test
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Soluciones.SistemasExternos;
    using Varo.Transversales.Repositorio;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class InspeccionesContinuasTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IAdaptadorInspeccionTecnica> adaptadorInspeccionTecnica = null;
        private INegocioInspeccionContinua negocioInspeccionContinua = null;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.adaptadorInspeccionTecnica = new Mock<IAdaptadorInspeccionTecnica>();


            this.negocioInspeccionContinua =
                new NegocioInspeccionContinua(
                    this.repositorioBase.Object,
                    this.adaptadorInspeccionTecnica.Object);
        }



        [TestMethod]
        public void ConsultarInspeccionesContinuasTest()
        {
            int id = 1;
            IList<InspeccionesContinuas> inspeccionesContinuosActual;
            IList<InspeccionesContinuas> inspeccionesContinuosEsperado = new List<InspeccionesContinuas>()
            {
                new InspeccionesContinuas
                {
                    Id = id,
                    Nombre = "Inspeccion continua test"
                }
            };

            this.adaptadorInspeccionTecnica.Setup(
                it => it
                .ConsultarProyectos())
                .Returns(
                    new List<InspeccionesContinuas>()
                    {
                        new InspeccionesContinuas
                        {
                            Id = id,
                            Nombre = "Inspeccion continua test"
                        }
                    }
                );

            inspeccionesContinuosActual = this.negocioInspeccionContinua.Consultar();

            Assert.AreEqual(inspeccionesContinuosEsperado.Count, inspeccionesContinuosActual.Count);
            Assert.AreEqual(inspeccionesContinuosEsperado[0].Id, inspeccionesContinuosActual[0].Id);
        }

        [TestMethod]
        public void ConsultarInspeccionesContinuasSinResultadoTest()
        {
            IList<InspeccionesContinuas> inspeccionesContinuosActual;
            IList<InspeccionesContinuas> inspeccionesContinuosEsperado = new List<InspeccionesContinuas>();

            this.adaptadorInspeccionTecnica.Setup(
                it => it
                .ConsultarProyectos())
                .Returns(
                    new List<InspeccionesContinuas>()
                );

            inspeccionesContinuosActual = this.negocioInspeccionContinua.Consultar();

            Assert.AreEqual(inspeccionesContinuosEsperado.Count, inspeccionesContinuosActual.Count);
        }

        [TestMethod]
        public void ConsultarValorMetricaPorSolucionTest()
        {
            Guid id = new Guid();
            ValorMetricaSolucion valorMetricaActual;
            ValorMetricaSolucion valorMetricaEsperada = new ValorMetricaSolucion
            {
                Bugs = 3,
                Cobertura = 100,
                CodeSmell = 1000,
                Lineas = 12634
            };

            this.adaptadorInspeccionTecnica.Setup(
                it => it
                .ConsultarValorMetricaPorSolucion(It.IsAny<Guid>()))
                .Returns(
                    new ValorMetricaSolucion
                    {
                        Bugs = 3,
                        Cobertura = 100,
                        CodeSmell = 1000,
                        Lineas = 12634
                    }
                );

            valorMetricaActual = this.negocioInspeccionContinua.ConsultarValorMetricaPorSolucion(id);

            Assert.AreEqual(valorMetricaEsperada.Bugs, valorMetricaActual.Bugs);
            Assert.AreEqual(valorMetricaEsperada.Lineas, valorMetricaActual.Lineas);
        }

        [TestMethod]
        public void ConsultarValorMetricaPorSolucionSinResultadoTest()
        {
            Guid id = new Guid();
            ValorMetricaSolucion valorMetricaActual;
            ValorMetricaSolucion valorMetricaEsperada = new ValorMetricaSolucion();

            this.adaptadorInspeccionTecnica.Setup(
                it => it
                .ConsultarValorMetricaPorSolucion(It.IsAny<Guid>()))
                .Returns(
                    new ValorMetricaSolucion()
                );

            valorMetricaActual = this.negocioInspeccionContinua.ConsultarValorMetricaPorSolucion(id);

            Assert.IsNotNull(valorMetricaActual);
        }
    }
}

