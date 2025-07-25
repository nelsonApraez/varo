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
    public class EstimacionHorasConsultoriaTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioEstimacionHoras> repositorioEstimacionHorasConsultoria = null;
        private INegocioEstimacionHoras negocioEstimacionHorasConsultoria = null;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioEstimacionHorasConsultoria = new Mock<IRepositorioEstimacionHoras>();

            this.negocioEstimacionHorasConsultoria =
                new NegocioEstimacionHoras(
                    this.repositorioBase.Object,
                    this.repositorioEstimacionHorasConsultoria.Object);
        }

        [TestMethod]
        public void CrearEstimacionHorasConsultoriaTest()
        {
            Guid idConsultoria = Guid.NewGuid();

            EstimacionHorasConsultoria estimacionHoras = new EstimacionHorasConsultoria()
            {
                IdConsultoria = idConsultoria,
                ListaEstimacionHorasConsultoria = new List<EstimacionHorasConsultoria>()
                {
                    new EstimacionHorasConsultoria
                    {
                        Concepto = "test",
                        HorasEstimadas = 10,
                        HorasEjecutadas = 10

                    }
                }
            };

            this.repositorioEstimacionHorasConsultoria.Setup(
                it => it.Eliminar(
                   It.IsAny<Guid>()));

            this.repositorioEstimacionHorasConsultoria.Setup(
                it => it.Crear(
                   It.IsAny<EstimacionHorasConsultoria>()));

            this.negocioEstimacionHorasConsultoria.Crear(estimacionHoras);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ConsultarHorasEstimacionConsultoriaPorIdConsultoriaTest()
        {
            Guid idEstimacionHoras = Guid.NewGuid();
            IList<EstimacionHorasConsultoria> horasEstimacionActual;
            IList<EstimacionHorasConsultoria> horasEstimacionEsperado = new List<EstimacionHorasConsultoria>
            {
                new EstimacionHorasConsultoria
                {
                    Id = idEstimacionHoras,
                    Concepto = "test",
                    HorasEstimadas = 10,
                    HorasEjecutadas = 10
                }
            };

            this.repositorioEstimacionHorasConsultoria.Setup(
                it => it
                .Consultar(It.IsAny<Guid>()))
                .Returns(
                   new List<EstimacionHorasConsultoria>
                   {
                       new EstimacionHorasConsultoria
                       {
                           Id = idEstimacionHoras,
                            Concepto = "test",
                            HorasEstimadas = 10,
                            HorasEjecutadas = 10
                       }
                   }
                );

            horasEstimacionActual = this.negocioEstimacionHorasConsultoria.Consultar(It.IsAny<Guid>());

            Assert.AreEqual(horasEstimacionEsperado.Count, horasEstimacionActual.Count);
            Assert.AreEqual(horasEstimacionEsperado[0].Id, horasEstimacionActual[0].Id);
        }

        [TestMethod]
        public void ConsultarHorasEstimacionConsultoriaPorIdConsultoriaSinResultadoTest()
        {
            Guid idEstimacionHoras = Guid.NewGuid();
            IList<EstimacionHorasConsultoria> horasEstimacionActual;
            IList<EstimacionHorasConsultoria> horasEstimacionEsperado = new List<EstimacionHorasConsultoria>();

            this.repositorioEstimacionHorasConsultoria.Setup(
                it => it
                .Consultar(It.IsAny<Guid>()))
                .Returns(
                   new List<EstimacionHorasConsultoria>()
                );

            horasEstimacionActual = this.negocioEstimacionHorasConsultoria.Consultar(It.IsAny<Guid>());

            Assert.AreEqual(horasEstimacionEsperado.Count, horasEstimacionActual.Count);
        }
    }
}

