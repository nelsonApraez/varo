namespace Varo.Soluciones.Test
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Soluciones.SistemasExternos;
    using Varo.Transversales.Repositorio;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Collections.Generic;

    [TestClass]
    public class ProyectoExternoTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IAdaptadorSonarExterno> adaptadorExterno = null;
        private INegocioProyectoExterno negocioProyectoExterno = null;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.adaptadorExterno = new Mock<IAdaptadorSonarExterno>();

            this.negocioProyectoExterno =
                new NegocioProyectoExterno(this.repositorioBase.Object,
                    this.adaptadorExterno.Object);
        }

        [TestMethod]
        public void ConsultarProyectos()
        {
            IList<Proyecto> listadoProyectoActual;
            IList<Proyecto> listadoProyectoEsperado = new List<Proyecto>()
            {
                new Proyecto
                {
                    Id = 1,
                    Nombre = "prueba",
                    IdTipoOrigen = 3,
                    Activo = false,
                    ConteoTotalFilas = 7,
                    IdOrigen = "prueba"
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
                            Id = 1,
                            Nombre = "prueba",
                            IdTipoOrigen = 3,
                            Activo = false,
                            ConteoTotalFilas = 7,
                            IdOrigen = "prueba"
                        }
                    }
                );

            listadoProyectoActual = this.negocioProyectoExterno.ConsultarProyectos();

            Assert.AreEqual(listadoProyectoEsperado.Count, listadoProyectoActual.Count);
            Assert.AreEqual(listadoProyectoEsperado[0].Id, listadoProyectoActual[0].Id);
        }

        [TestMethod]
        public void CrearProyecto()
        {
            Proyecto proyectoExterno = new Proyecto()
            {
                Id = 1,
                Nombre = "prueba",
                IdTipoOrigen = 3,
                Activo = false,
                ConteoTotalFilas = 7,
                IdOrigen = "prueba"
            };

            this.adaptadorExterno.Setup(
                it => it
                .CrearProyecto(It.IsAny<Proyecto>()));

            this.negocioProyectoExterno.CrearProyecto(proyectoExterno);
        }

        [TestMethod]
        public void ActualizarProyectos()
        {
            Proyecto proyectoExterno = new Proyecto()
            {
                Id = 1,
                Nombre = "prueba cambio",
                IdTipoOrigen = 3,
                Activo = false,
                ConteoTotalFilas = 7,
                IdOrigen = "prueba"
            };

            this.adaptadorExterno.Setup(
                it => it
                .ActualizarProyecto(It.IsAny<Proyecto>()));

            this.negocioProyectoExterno.EditarProyecto(proyectoExterno);


        }

        [TestMethod]
        public void InactivarProyecto()
        {
            Proyecto proyectoExterno = new Proyecto()
            {
                Id = 1,
                Nombre = "prueba cambio",
                IdTipoOrigen = 3,
                Activo = false,
                ConteoTotalFilas = 7,
                IdOrigen = "prueba"
            };

            this.adaptadorExterno.Setup(
                it => it
                .ActualizarProyecto(It.IsAny<Proyecto>()));

            this.negocioProyectoExterno.InactivarProyecto(proyectoExterno);
        }

        [TestMethod]
        public void ConsultarProyectosPorParametro()
        {
            IList<Proyecto> listadoProyectoActual;
            IList<Proyecto> listadoProyectoEsperado = new List<Proyecto>()
            {
                new Proyecto
                {
                    Id = 1,
                    Nombre = "prueba",
                    IdTipoOrigen = 3,
                    Activo = false,
                    ConteoTotalFilas = 7,
                    IdOrigen = "prueba"
                }
            };

            this.adaptadorExterno.Setup(
                it => it
                .ConsultarProyectoPorParametro(It.IsAny<FiltroProyecto>()))
                .Returns(
                    new List<Proyecto>()
                    {
                        new Proyecto
                        {
                            Id = 1,
                            Nombre = "prueba",
                            IdTipoOrigen = 3,
                            Activo = false,
                            ConteoTotalFilas = 7,
                            IdOrigen = "prueba"
                        }
                    }
                );

            listadoProyectoActual = this.negocioProyectoExterno.ConsultarProyectosPorParametro(new FiltroProyecto
            {
                Activo = 0,
                Parametro = "",
                NumeroPagina = 1,
                TamanoPagina = 15
            });

            Assert.AreEqual(listadoProyectoEsperado.Count, listadoProyectoActual.Count);
            Assert.AreEqual(listadoProyectoEsperado[0].Id, listadoProyectoActual[0].Id);
        }
    }
}

