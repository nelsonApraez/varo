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
    public class MetricaSistemicaTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IAdaptadorSombreroBlanco> adaptadorSombreroBlanco = null;
        private INegocioMetricaSistemica negocioMetricaSistemica = null;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.adaptadorSombreroBlanco = new Mock<IAdaptadorSombreroBlanco>();
            this.negocioMetricaSistemica =
                new NegocioMetricaSistemica(
                    this.repositorioBase.Object,
                    this.adaptadorSombreroBlanco.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ObtenerUltimaCalificacionDesempeñoTest()
        {
            this.negocioMetricaSistemica.ObtenerUltimaCalificacionDesempeño(It.IsAny<Guid>());
        }


        [TestMethod]
        public void ObtenerUltimaCalificacionSeguridadTest()
        {
            CalificacionSeguridad calificacionSeguridadActual;
            CalificacionSeguridad calificacionSeguridadEsperada = new CalificacionSeguridad
            {
                Calificacion = 90
            };

            this.adaptadorSombreroBlanco.Setup(
                it => it
                .ObtenerCalificacionSeguridad(It.IsAny<Guid>()))
                .Returns(
                    new List<CalificacionSeguridad>()
                    {
                        new CalificacionSeguridad
                        {
                            Calificacion = 90
                        }
                    }
                );

            calificacionSeguridadActual = this.negocioMetricaSistemica.ObtenerUltimaCalificacionSeguridad(It.IsAny<Guid>());

            Assert.AreEqual(calificacionSeguridadEsperada.Calificacion, calificacionSeguridadActual.Calificacion);
        }

        [TestMethod]
        public void ObtenerUltimaCalificacionSeguridadCeroTest()
        {
            CalificacionSeguridad calificacionSeguridadEsperada = null;
            CalificacionSeguridad calificacionSeguridadActual;

            this.adaptadorSombreroBlanco.Setup(
                it => it
                .ObtenerCalificacionSeguridad(It.IsAny<Guid>()))
                .Returns(new List<CalificacionSeguridad>());

            calificacionSeguridadActual = this.negocioMetricaSistemica.ObtenerUltimaCalificacionSeguridad(It.IsAny<Guid>());

            Assert.AreEqual(calificacionSeguridadEsperada, calificacionSeguridadActual);
        }
    }
}

