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
    public class MetricaExternoTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IAdaptadorSonarExterno> adaptadorExterno = null;
        private INegocioMetricaExterna negocioMetricaExterno = null;
        private INegocioProyectoExterno negocioProyectoExterno = null;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.adaptadorExterno = new Mock<IAdaptadorSonarExterno>();

            this.negocioMetricaExterno =
                new NegocioMetricaExterna(
                    this.repositorioBase.Object,
                    this.adaptadorExterno.Object);

            this.negocioProyectoExterno =
                new NegocioProyectoExterno(this.repositorioBase.Object,
                    this.adaptadorExterno.Object);
        }

        [TestMethod]
        public void ConsultarMetricas()
        {
            IList<Metrica> listadoMetricaActual;
            IList<Metrica> listadoMetricaEsperado = new List<Metrica>()
            {
                new Metrica
                {
                    Id = 1,
                    Nombre = "Bugs",
                }
            };

            this.adaptadorExterno.Setup(
                it => it
                .ConsultarMetricas())
                .Returns(
                    new List<Metrica>()
                    {
                        new Metrica
                        {
                            Id = 1,
                            Nombre = "Bugs"
                        }
                    }
                );

            listadoMetricaActual = this.negocioMetricaExterno.ConsultarMetricas();

            Assert.AreEqual(listadoMetricaEsperado.Count, listadoMetricaActual.Count);
            Assert.AreEqual(listadoMetricaEsperado[0].Id, listadoMetricaActual[0].Id);
        }

        [TestMethod]
        public void ConsultarProyectos()
        {
            IList<Proyecto> listadoProyectoActual;
            IList<Proyecto> listadoProyectoEsperado = new List<Proyecto>()
            {
                new Proyecto
                {
                    Id = 737,
                    Nombre = "Epm.MiBitacoraExpres.iOS",
                }
            };

            this.adaptadorExterno.Setup(
                it => it
                .ConsultarProyectos())
                .Returns(
                    new List<Proyecto>()
                    {
                        new Proyecto
                        {
                            Id = 737,
                            Nombre = "Epm.MiBitacoraExpres.iOS",
                        }
                    }
                );

            listadoProyectoActual = this.negocioProyectoExterno.ConsultarProyectos();

            Assert.AreEqual(listadoProyectoEsperado.Count, listadoProyectoActual.Count);
            Assert.AreEqual(listadoProyectoEsperado[0].Id, listadoProyectoActual[0].Id);
        }

        [TestMethod]
        public void CrearRegistro()
        {
            ValorMetricaProyecto valorMetricaExterno = new ValorMetricaProyecto()
            {
                Ano = 2021,
                Mes = 1,
                FechaAnalisis = DateTime.Now,
                Proyecto = new Proyecto
                {
                    Id = 737,
                    Nombre = "Epm.MiBitacoraExpres.iOS",
                },
                ListadoValorMetrica = new List<ValorMetricaExterna>(){
                    new ValorMetricaExterna()
                    {
                        Valor= 5,
                        NombreMetrica = "Bugs"
                    }
                }
            };

            this.adaptadorExterno.Setup(
                it => it
                .CrearValorMetrica(It.IsAny<ValorMetricaProyecto>()));

            this.negocioMetricaExterno.CrearValorMetrica(valorMetricaExterno);


        }

        [TestMethod]
        public void ConsultarValorMetricaPorProyectoConResultadoTest()
        {
            IList<ValorMetrica> listadoValorMetricaActual;
            IList<ValorMetrica> listadoValorMetricaEsperado = new List<ValorMetrica>()
                    {
                        new ValorMetrica
                        {
                            Valor = 2,
                            Metrica = new Metrica{ Nombre= "Bugs" },
                            Mes = 1,
                            Ano = 2021
                        }
                    };

            this.adaptadorExterno.Setup(
                it => it
                .ConsultarValorMetricas(It.IsAny<int>()))
                .Returns(
                    new List<ValorMetrica>()
                    {
                        new ValorMetrica
                        {
                            Valor = 2,
                            Metrica = new Metrica{ Nombre= "Bugs" },
                            Mes = 1,
                            Ano = 2021
                        }
                    }
                );

            listadoValorMetricaActual = this.negocioMetricaExterno.ConsultarValorMetricaPorProyecto(456);

            Assert.AreEqual(listadoValorMetricaEsperado.Count, listadoValorMetricaActual.Count);
            Assert.AreEqual(listadoValorMetricaEsperado[0].Valor, listadoValorMetricaActual[0].Valor);
        }

        [TestMethod]
        public void ConsultarValorMetricaPorProyectoSiResultadoTest()
        {
            IList<ValorMetrica> listadoValorMetricaActual;
            IList<ValorMetrica> listadoValorMetricaEsperado = new List<ValorMetrica>();

            this.adaptadorExterno.Setup(
                it => it
                .ConsultarValorMetricas(It.IsAny<int>()))
                .Returns(
                    new List<ValorMetrica>());

            listadoValorMetricaActual = this.negocioMetricaExterno.ConsultarValorMetricaPorProyecto(458);

            Assert.AreEqual(listadoValorMetricaEsperado.Count, listadoValorMetricaActual.Count);

        }

    }
}

