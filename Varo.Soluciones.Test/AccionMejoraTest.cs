namespace Varo.Soluciones.Test
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Repositorio;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class AccionMejoraTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioAccionMejora> repositorioAccionMejora = null;
        private INegocioAccionMejora negocioAccionMejora = null;
        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioAccionMejora = new Mock<IRepositorioAccionMejora>();
            this.negocioAccionMejora =
                new NegocioAccionMejora(
                    this.repositorioBase.Object,
                    this.repositorioAccionMejora.Object);
        }
        [TestMethod]
        public void ObtenerPorMetricaAgilTest()
        {
            IList<AccionesMejora> AccionMejora = null;
            this.repositorioAccionMejora
                .Setup(it => it.ObtenerPorMetricaAgil(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(new List<AccionesMejora>());
            AccionMejora = this.negocioAccionMejora.ObtenerPorMetricaAgil(It.IsAny<int>(), It.IsAny<string>());
            Assert.IsNotNull(AccionMejora);
        }
        [TestMethod]
        public void ConsultarPorSolucionTest()
        {
            IList<AccionesMejora> AccionMejora = null;
            this.repositorioAccionMejora
                .Setup(it => it.ConsultarPorSolucion(It.IsAny<Guid>(), It.IsAny<string>()))
                .Returns(new List<AccionesMejora>());
            AccionMejora = this.negocioAccionMejora.ConsultarPorSolucion(It.IsAny<Guid>(), It.IsAny<string>());
            Assert.IsNotNull(AccionMejora);
        }

        [TestMethod]
        public void ConsultarPorParametroTest()
        {
            IList<AccionesMejora> listaAccionesMejoraActual;
            IList<AccionesMejora> listaAccionesMejoraEsperado = new List<AccionesMejora>()
            {
                new AccionesMejora
                {
                    Id = 1,
                    Accion ="prueba 1"
                }
            };

            this.repositorioAccionMejora.Setup(
                it => it
                .ConsultarPorSolucionParametroBusqueda(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(
                    new List<AccionesMejora>()
                    {
                        new AccionesMejora
                        {
                            Id = 1,
                            Accion ="prueba 1"
                        }
                    }
                );

            listaAccionesMejoraActual = this.negocioAccionMejora.ConsultarPorSolucionParametroBusqueda(Guid.NewGuid(), "prueba", "ES");

            Assert.AreEqual(listaAccionesMejoraEsperado.Count, listaAccionesMejoraActual.Count);
            Assert.AreEqual(listaAccionesMejoraEsperado[0].Id, listaAccionesMejoraActual[0].Id);
        }

        [TestMethod]
        public void CrearAccionMejoraTest()
        {
            AccionesMejora accionesMejora = new AccionesMejora
            {
                Id = 1,
                IdMetricaAgil = 1,
                Accion = "Accion",
                Responsable = new Transversales.Entidades.ItemMaestro() { Id = 1, Nombre = "wcalderon" },
                Estado = new Transversales.Entidades.ItemMaestro() { Id = 1, Nombre = "Abierto" }
            };

            this.negocioAccionMejora.Crear(accionesMejora);

            Assert.IsNotNull(accionesMejora);
        }

        [TestMethod]
        public void ActualizarAccionMejoraTest()
        {
            AccionesMejora accionesMejora = new AccionesMejora()
            {
                ListaAccionesMejora = new List<AccionesMejora>()
                {
                    new AccionesMejora
                    {
                        Id = 1,
                        IdMetricaAgil = 1,
                        Accion = "Actualización",
                        Responsable = new Transversales.Entidades.ItemMaestro() { Id = 1, Nombre = "wcalderon" },
                        Estado = new Transversales.Entidades.ItemMaestro() { Id = 2, Nombre = "Cerrado" }
                    }
                }
            };

            this.negocioAccionMejora.Editar(accionesMejora);

            Assert.IsNotNull(accionesMejora);
        }
    }
}

