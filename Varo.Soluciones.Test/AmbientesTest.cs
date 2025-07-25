
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
    public class AmbientesTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioAmbientes> repositorioAmbientes = null;
        private INegocioAmbientes negocioAmbientes = null;

        [TestInitialize]
        public void InicializarEquipoSolucion()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioAmbientes = new Mock<IRepositorioAmbientes>();

            this.negocioAmbientes =
                new NegocioAmbientes(
                    this.repositorioBase.Object,
                    this.repositorioAmbientes.Object);
        }

        [TestMethod]
        public void CrearAmbientesTest()
        {
            Ambientes ambiente = new Ambientes
            {
                IdSolucion = new Guid(),
                ListaAmbientes = new List<Ambientes>
                    {
                        new Ambientes
                        {
                            Id = new Guid(),
                            Responsable = "Aureliano Buendia",
                            Ubicacion = "https://prueba"
                        }
                    }
            };

            this.repositorioAmbientes.Setup(
               it => it.Eliminar(It.IsAny<Guid>()));

            this.repositorioAmbientes.Setup(
                it => it.Crear(It.IsAny<Ambientes>()));

            this.negocioAmbientes.Crear(ambiente);
        }

        [TestMethod]
        public void CrearAmbientesNullTest()
        {
            Ambientes ambiente = null;

            this.repositorioAmbientes.Setup(
               it => it.Eliminar(It.IsAny<Guid>()));

            this.repositorioAmbientes.Setup(
                it => it.Crear(It.IsAny<Ambientes>()));

            this.negocioAmbientes.Crear(ambiente);
        }

        [TestMethod]
        public void ConsultarAmbientesTest()
        {
            Guid id = Guid.NewGuid();
            IList<Ambientes> ambientesActual;
            IList<Ambientes> ambientesEsperado = new List<Ambientes>()
            {
                new Ambientes
                {
                    Id = id,
                    Responsable = "Aureliano Buendia",
                    Ubicacion = "https://prueba"
                }
            };

            this.repositorioAmbientes.Setup(
                it => it
                .Consultar(
                    It.IsAny<Guid>(), It.IsAny<string>()))
                .Returns(
                    new List<Ambientes>()
                    {
                        new Ambientes
                        {
                            Id = id,
                            Responsable = "Aureliano Buendia",
                            Ubicacion = "https://prueba"
                        }
                    }
                );

            ambientesActual = this.negocioAmbientes.Consultar(
                It.IsAny<Guid>(), It.IsAny<string>());

            Assert.AreEqual(ambientesEsperado.Count, ambientesActual.Count);
            Assert.AreEqual(ambientesEsperado[0].Id, ambientesActual[0].Id);
        }

        [TestMethod]
        public void ConsultarAmbientesSinResultadoTest()
        {
            Guid id = Guid.NewGuid();
            IList<Ambientes> ambientesActual;
            IList<Ambientes> ambientesEsperado = new List<Ambientes>();

            this.repositorioAmbientes.Setup(
                it => it
                .Consultar(
                    It.IsAny<Guid>(), It.IsAny<string>()))
                .Returns(new List<Ambientes>());

            ambientesActual = this.negocioAmbientes.Consultar(
                It.IsAny<Guid>(), It.IsAny<string>());

            Assert.AreEqual(ambientesEsperado.Count, ambientesActual.Count);
        }
    }
}

