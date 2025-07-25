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
    public class EstimacionHorasSolucionTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioEstimacionHoras> repositorioEstimacionHorasSolucion = null;
        private INegocioEstimacionHoras negocioEstimacionHorasSolucion = null;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioEstimacionHorasSolucion = new Mock<IRepositorioEstimacionHoras>();

            this.negocioEstimacionHorasSolucion =
                new NegocioEstimacionHoras(
                    this.repositorioBase.Object,
                    this.repositorioEstimacionHorasSolucion.Object);
        }

        [TestMethod]
        public void CrearEstimacionHorasSolucionTest()
        {
            Guid idSolucion = Guid.NewGuid();

            EstimacionHorasSolucion estimacionHoras = new EstimacionHorasSolucion()
            {
                IdSolucion = idSolucion,
                ListaEstimacionHorasSolucion = new List<EstimacionHorasSolucion>()
                {
                    new EstimacionHorasSolucion
                    {
                        Concepto = "test",
                        HorasEstimadas = 10,
                        HorasEjecutadas = 10

                    }
                }
            };

            this.repositorioEstimacionHorasSolucion.Setup(
                it => it.Eliminar(
                   It.IsAny<Guid>()));

            this.repositorioEstimacionHorasSolucion.Setup(
                it => it.Crear(
                   It.IsAny<EstimacionHorasSolucion>()));

            this.negocioEstimacionHorasSolucion.Crear(estimacionHoras);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ConsultarHorasEstimacionSolucionPorIdSolucionTest()
        {
            Guid idEstimacionHoras = Guid.NewGuid();
            IList<EstimacionHorasSolucion> horasEstimacionActual;
            IList<EstimacionHorasSolucion> horasEstimacionEsperado = new List<EstimacionHorasSolucion>
            {
                new EstimacionHorasSolucion
                {
                    Id = idEstimacionHoras,
                    Concepto = "test",
                    HorasEstimadas = 10,
                    HorasEjecutadas = 10
                }
            };

            this.repositorioEstimacionHorasSolucion.Setup(
                it => it
                .Consultar(It.IsAny<Guid>()))
                .Returns(
                   new List<EstimacionHorasSolucion>
                   {
                       new EstimacionHorasSolucion
                       {
                           Id = idEstimacionHoras,
                            Concepto = "test",
                            HorasEstimadas = 10,
                            HorasEjecutadas = 10
                       }
                   }
                );

            horasEstimacionActual = this.negocioEstimacionHorasSolucion.Consultar(It.IsAny<Guid>());

            Assert.AreEqual(horasEstimacionEsperado.Count, horasEstimacionActual.Count);
            Assert.AreEqual(horasEstimacionEsperado[0].Id, horasEstimacionActual[0].Id);
        }

        [TestMethod]
        public void ConsultarHorasEstimacionSolucionPorIdSolucionSinResultadoTest()
        {
            Guid idEstimacionHoras = Guid.NewGuid();
            IList<EstimacionHorasSolucion> horasEstimacionActual;
            IList<EstimacionHorasSolucion> horasEstimacionEsperado = new List<EstimacionHorasSolucion>();

            this.repositorioEstimacionHorasSolucion.Setup(
                it => it
                .Consultar(It.IsAny<Guid>()))
                .Returns(
                   new List<EstimacionHorasSolucion>()
                );

            horasEstimacionActual = this.negocioEstimacionHorasSolucion.Consultar(It.IsAny<Guid>());

            Assert.AreEqual(horasEstimacionEsperado.Count, horasEstimacionActual.Count);
        }
    }
}

