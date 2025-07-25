
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
    public class EquipoSolucionTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioEquipoSolucion> repositorioEquipoSolucion = null;
        private INegocioEquipoSolucion negocioEquipoSolucion = null;

        [TestInitialize]
        public void InicializarEquipoSolucion()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioEquipoSolucion = new Mock<IRepositorioEquipoSolucion>();

            this.negocioEquipoSolucion =
                new NegocioEquipoSolucion(
                    this.repositorioBase.Object,
                    this.repositorioEquipoSolucion.Object);
        }

        [TestMethod]
        public void CrearEquipoSolucionTest()
        {
            this.repositorioEquipoSolucion.Setup(
                it => it.Editar(It.IsAny<EquipoSolucion>()));

            this.repositorioEquipoSolucion.Setup(
               it => it.Eliminar(It.IsAny<Guid>()));

            this.repositorioEquipoSolucion.Setup(
               it => it
               .ConsultarMetricaPorIdEquipo(
                   It.IsAny<Guid>()))
               .Returns(
                   new List<MetricasAgiles>()
                   {
                        new MetricasAgiles
                        {
                            Id = 1,
                            Sprint = "Prueba"
                        }
                   }
               );

            this.repositorioEquipoSolucion.Setup(
               it => it
               .Consultar(
                   It.IsAny<Guid>()))
               .Returns(
                   new List<EquipoSolucion>()
                   {
                        new EquipoSolucion
                        {
                            Id = new Guid(),
                            Nombre = "Equipo 1"
                        }
                   }
               );


            this.repositorioEquipoSolucion.Setup(
                it => it.Crear(
                   It.IsAny<EquipoSolucion>()));

            this.negocioEquipoSolucion.Crear(
                new EquipoSolucion
                {
                    IdSolucion = new Guid(),
                    ListaEquipoSolucion = new List<EquipoSolucion>
                    {
                        new EquipoSolucion
                        {
                            Id = new Guid(),
                            Nombre = "prueba"
                        }
                    }
                });
        }

        [TestMethod]
        public void EliminarEquipoSolucionPorIdSolucionTest()
        {
            this.repositorioEquipoSolucion.Setup(
                it => it.EliminarPorIdSolucion(
                    It.IsAny<Guid>()));

            this.negocioEquipoSolucion.Eliminar(
                It.IsAny<Guid>());
        }

        [TestMethod]
        public void ConsultarEquipoSolucionTest()
        {
            Guid id = Guid.NewGuid();
            IList<EquipoSolucion> EquipoSolucionActual;
            IList<EquipoSolucion> EquipoSolucionEsperado = new List<EquipoSolucion>()
            {
                new EquipoSolucion
                {
                    Id = id,
                    Nombre = "Equipo 1"
                }
            };

            this.repositorioEquipoSolucion.Setup(
                it => it
                .Consultar(
                    It.IsAny<Guid>()))
                .Returns(
                    new List<EquipoSolucion>()
                    {
                        new EquipoSolucion
                        {
                            Id = id,
                            Nombre = "Equipo 1"
                        }
                    }
                );

            EquipoSolucionActual = this.negocioEquipoSolucion.Consultar(
                It.IsAny<Guid>());

            Assert.AreEqual(EquipoSolucionEsperado.Count, EquipoSolucionActual.Count);
            Assert.AreEqual(EquipoSolucionEsperado[0].Id, EquipoSolucionActual[0].Id);
        }

        [TestMethod]
        public void ConsultarEquipoSolucionSinResultadoTest()
        {
            IList<EquipoSolucion> equipoSolucionActual;
            IList<EquipoSolucion> equipoSolucionEsperado = new List<EquipoSolucion>();

            this.repositorioEquipoSolucion.Setup(
                it => it
                .Consultar(
                    It.IsAny<Guid>()))
                .Returns(
                    new List<EquipoSolucion>()
                );

            equipoSolucionActual = this.negocioEquipoSolucion.Consultar(
                It.IsAny<Guid>());

            Assert.AreEqual(equipoSolucionEsperado.Count, equipoSolucionActual.Count);
        }
    }
}

