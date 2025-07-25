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

    /// <summary>
    /// Summary description for SolucionesConsultarClientesPorIdPaisTest
    /// </summary>
    [TestClass]
    public class AuditoriaTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioAuditoria> repositorioAuditoria = null;
        private INegocioAuditoria negocioAuditoria = null;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioAuditoria = new Mock<IRepositorioAuditoria>();

            this.negocioAuditoria =
                new NegocioAuditoria(
                    this.repositorioBase.Object,
                    this.repositorioAuditoria.Object);
        }

        [TestMethod]
        public void ObtenerCalificacionAuditoriaPorIdSolucionTest()
        {
            Guid id = Guid.NewGuid();
            IList<CalificacionAuditoria> auditoriaActual;
            IList<CalificacionAuditoria> auditoriaEsperado = new List<CalificacionAuditoria>()
            {
                new CalificacionAuditoria
                {
                    Id = id,
                    Calificacion = 0.78M,
                    Fecha = new DateTime(2020,02,02)
                }
            };

            this.repositorioAuditoria.Setup(
                it => it
                .Obtener(
                    It.IsAny<Guid>()))
                .Returns(
                    new List<CalificacionAuditoria>()
                    {
                        new CalificacionAuditoria
                        {
                            Id = id,
                            Calificacion = 0.78M,
                            Fecha = new DateTime(2020,02,02)
                        }
                    }
                );

            auditoriaActual = this.negocioAuditoria.Obtener(
                It.IsAny<Guid>());

            Assert.AreEqual(auditoriaEsperado.Count, auditoriaActual.Count);
            Assert.AreEqual(auditoriaEsperado[0].Id, auditoriaActual[0].Id);
        }

        [TestMethod]
        public void ObtenerCalificacionAuditoriaPorIdSolucionSinResultadoTest()
        {
            Guid id = Guid.NewGuid();
            IList<CalificacionAuditoria> auditoriaActual;
            IList<CalificacionAuditoria> auditoriaEsperado = new List<CalificacionAuditoria>();

            this.repositorioAuditoria.Setup(
                it => it
                .Obtener(
                    It.IsAny<Guid>()))
                .Returns(
                    new List<CalificacionAuditoria>()
                );

            auditoriaActual = this.negocioAuditoria.Obtener(
                It.IsAny<Guid>());

            Assert.AreEqual(auditoriaEsperado.Count, auditoriaActual.Count);
        }

        [TestMethod]
        public void ObtenerUltimaCalificacionAuditoriaPorIdSolucionTest()
        {
            Guid id = Guid.NewGuid();
            CalificacionAuditoria auditoriaActual;
            CalificacionAuditoria auditoriaEsperado = new CalificacionAuditoria
            {
                Id = id,
                Calificacion = 0.78M,
                Fecha = new DateTime(2020, 02, 02)
            };

            this.repositorioAuditoria.Setup(
                it => it
                .ObtenerUltimaCalificacion(
                    It.IsAny<Guid>()))
                .Returns(
                        new CalificacionAuditoria
                        {
                            Id = id,
                            Calificacion = 0.78M,
                            Fecha = new DateTime(2020, 02, 02)
                        }
                    );

            auditoriaActual = this.negocioAuditoria.ObtenerUltimaCalificacion(
                It.IsAny<Guid>());

            Assert.AreEqual(auditoriaEsperado.Id, auditoriaActual.Id);
        }

        [TestMethod]
        public void ObtenerUltimaCalificacionAuditoriaPorIdSolucionSinResultadoTest()
        {
            Guid id = Guid.NewGuid();
            CalificacionAuditoria auditoriaActual;
            CalificacionAuditoria auditoriaEsperado = new CalificacionAuditoria();

            this.repositorioAuditoria.Setup(
                it => it
                .ObtenerUltimaCalificacion(
                    It.IsAny<Guid>()))
                .Returns(
                        new CalificacionAuditoria()
                    );

            auditoriaActual = this.negocioAuditoria.ObtenerUltimaCalificacion(
                It.IsAny<Guid>());

            Assert.AreEqual(auditoriaEsperado.Id, auditoriaActual.Id);
        }

        [TestMethod]
        public void CrearAuditoriaConCalificacionTest()
        {
            Guid idSolucion = Guid.NewGuid();

            CalificacionAuditoria auditoriaActual = new CalificacionAuditoria()
            {
                IdSolucion = idSolucion,
                ListaCalificacionAuditorias = new List<CalificacionAuditoria>()
                {
                    new CalificacionAuditoria
                    {
                        Calificacion = 0.78M,
                        Fecha = new DateTime(2020,02,02)
                    }
                }
            };

            CalificacionAuditoria auditoriaEsperado = new CalificacionAuditoria()
            {
                IdSolucion = idSolucion,
                ListaCalificacionAuditorias = new List<CalificacionAuditoria>()
                {
                    new CalificacionAuditoria
                    {
                        IdSolucion = idSolucion,
                        Calificacion = 0.78M,
                        Fecha = new DateTime(2020,02,02)
                    }
                }
            };

            this.repositorioAuditoria.Setup(
                it => it.Eliminar(
                   It.IsAny<Guid>()));

            this.repositorioAuditoria.Setup(
                it => it.Crear(
                   It.IsAny<CalificacionAuditoria>()));

            this.negocioAuditoria.Actualizar(auditoriaActual);

            Assert.AreEqual(auditoriaEsperado.Id, auditoriaActual.Id);
            Assert.AreEqual(
                auditoriaEsperado.ListaCalificacionAuditorias[0].IdSolucion,
                auditoriaActual.ListaCalificacionAuditorias[0].IdSolucion);
        }

        [TestMethod]
        public void CrearAuditoriaSinCalificacionTest()
        {
            CalificacionAuditoria auditoriaActual = null;

            this.repositorioAuditoria.Setup(
                it => it.Eliminar(
                   It.IsAny<Guid>()));

            this.repositorioAuditoria.Setup(
                it => it.Crear(
                   It.IsAny<CalificacionAuditoria>()));

            this.negocioAuditoria.Actualizar(auditoriaActual);

            Assert.IsNull(auditoriaActual);
        }

        [TestMethod]
        public void EditarAuditoria()
        {
            this.repositorioAuditoria.Setup(
                it => it.Editar(
                    It.IsAny<CalificacionAuditoria>()));

            this.negocioAuditoria.Editar(
                It.IsAny<CalificacionAuditoria>());
        }

        [TestMethod]
        public void EliminarAuditoriaPorIdSolucionTest()
        {
            this.repositorioAuditoria.Setup(
                it => it.Eliminar(
                    It.IsAny<Guid>()));

            this.negocioAuditoria.Eliminar(
                It.IsAny<Guid>());
        }
    }
}

