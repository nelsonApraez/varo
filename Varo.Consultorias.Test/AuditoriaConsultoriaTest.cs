namespace Varo.Consultorias.Test
{
    using Varo.Consultorias.Entidades;
    using Varo.Consultorias.Negocio;
    using Varo.Consultorias.Repositorio;
    using Varo.Transversales.Repositorio;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class AuditoriaConsultoriaTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioAuditoria> repositorioAuditoriaConsultoria = null;
        private INegocioAuditoria negocioAuditoriaConsultoria = null;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioAuditoriaConsultoria = new Mock<IRepositorioAuditoria>();

            this.negocioAuditoriaConsultoria =
                new NegocioAuditoria(
                    this.repositorioBase.Object,
                    this.repositorioAuditoriaConsultoria.Object);
        }

        [TestMethod]
        public void ObtenerCalificacionAuditoriaPorIdConsultoriaTest()
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

            this.repositorioAuditoriaConsultoria.Setup(
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

            auditoriaActual = this.negocioAuditoriaConsultoria.Obtener(
                It.IsAny<Guid>());

            Assert.AreEqual(auditoriaEsperado.Count, auditoriaActual.Count);
            Assert.AreEqual(auditoriaEsperado[0].Id, auditoriaActual[0].Id);
        }

        [TestMethod]
        public void ObtenerCalificacionAuditoriaPorIdConsultoriaSinResultadoTest()
        {
            Guid id = Guid.NewGuid();
            IList<CalificacionAuditoria> auditoriaActual;
            IList<CalificacionAuditoria> auditoriaEsperado = new List<CalificacionAuditoria>();

            this.repositorioAuditoriaConsultoria.Setup(
                it => it
                .Obtener(
                    It.IsAny<Guid>()))
                .Returns(
                    new List<CalificacionAuditoria>()
                );

            auditoriaActual = this.negocioAuditoriaConsultoria.Obtener(
                It.IsAny<Guid>());

            Assert.AreEqual(auditoriaEsperado.Count, auditoriaActual.Count);
        }

        [TestMethod]
        public void ObtenerUltimaCalificacionAuditoriaPorIdConsultoriaTest()
        {
            Guid id = Guid.NewGuid();
            CalificacionAuditoria auditoriaActual;
            CalificacionAuditoria auditoriaEsperado = new CalificacionAuditoria
            {
                Id = id,
                Calificacion = 0.78M,
                Fecha = new DateTime(2020, 02, 02)
            };

            this.repositorioAuditoriaConsultoria.Setup(
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

            auditoriaActual = this.negocioAuditoriaConsultoria.ObtenerUltimaCalificacion(
                It.IsAny<Guid>());

            Assert.AreEqual(auditoriaEsperado.Id, auditoriaActual.Id);
        }

        [TestMethod]
        public void ObtenerUltimaCalificacionAuditoriaPorIdConsultoriaSinResultadoTest()
        {
            Guid id = Guid.NewGuid();
            CalificacionAuditoria auditoriaActual;
            CalificacionAuditoria auditoriaEsperado = new CalificacionAuditoria();

            this.repositorioAuditoriaConsultoria.Setup(
                it => it
                .ObtenerUltimaCalificacion(
                    It.IsAny<Guid>()))
                .Returns(
                        new CalificacionAuditoria()
                    );

            auditoriaActual = this.negocioAuditoriaConsultoria.ObtenerUltimaCalificacion(
                It.IsAny<Guid>());

            Assert.AreEqual(auditoriaEsperado.Id, auditoriaActual.Id);
        }

        [TestMethod]
        public void CrearAuditoriaConsultoriaConCalificacionTest()
        {
            Guid idConsultoria = Guid.NewGuid();

            CalificacionAuditoria auditoriaActual = new CalificacionAuditoria()
            {
                IdConsultoria = idConsultoria,
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
                IdConsultoria = idConsultoria,
                ListaCalificacionAuditorias = new List<CalificacionAuditoria>()
                {
                    new CalificacionAuditoria
                    {
                        IdConsultoria = idConsultoria,
                        Calificacion = 0.78M,
                        Fecha = new DateTime(2020,02,02)
                    }
                }
            };

            this.repositorioAuditoriaConsultoria.Setup(
                it => it.Eliminar(
                   It.IsAny<Guid>()));

            this.repositorioAuditoriaConsultoria.Setup(
                it => it.Crear(
                   It.IsAny<CalificacionAuditoria>()));

            this.negocioAuditoriaConsultoria.Crear(auditoriaActual);

            Assert.AreEqual(auditoriaEsperado.Id, auditoriaActual.Id);
            Assert.AreEqual(
                auditoriaEsperado.ListaCalificacionAuditorias[0].IdConsultoria,
                auditoriaActual.ListaCalificacionAuditorias[0].IdConsultoria);
        }

        [TestMethod]
        public void CrearAuditoriaSinCalificacionTest()
        {
            CalificacionAuditoria auditoriaActual = null;

            this.repositorioAuditoriaConsultoria.Setup(
                it => it.Eliminar(
                   It.IsAny<Guid>()));

            this.repositorioAuditoriaConsultoria.Setup(
                it => it.Crear(
                   It.IsAny<CalificacionAuditoria>()));

            this.negocioAuditoriaConsultoria.Crear(auditoriaActual);

            Assert.IsNull(auditoriaActual);
        }

        [TestMethod]
        public void EditarAuditoria()
        {
            this.repositorioAuditoriaConsultoria.Setup(
                it => it.Editar(
                    It.IsAny<CalificacionAuditoria>()));

            this.negocioAuditoriaConsultoria.Editar(
                It.IsAny<CalificacionAuditoria>());
        }

        [TestMethod]
        public void EliminarAuditoriaPorIdConsultoriaTest()
        {
            this.repositorioAuditoriaConsultoria.Setup(
                it => it.Eliminar(
                    It.IsAny<Guid>()));

            this.negocioAuditoriaConsultoria.Eliminar(
                It.IsAny<Guid>());
        }
    }
}

