namespace Varo.Maestros.Test
{
    using Varo.Maestros.Entidades;
    using Varo.Maestros.Negocio;
    using Varo.Maestros.SistemasExternos;
    using Varo.Transversales.Repositorio;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Collections.Generic;

    [TestClass]
    public class LocalizacionPaisTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IAdaptadorLocalizacion> adaptadorLocalizacion = null;
        private INegocioLocalizacion negocioLocalizacion = null;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.adaptadorLocalizacion = new Mock<IAdaptadorLocalizacion>();

            this.negocioLocalizacion =
                new NegocioLocalizacion(
                    this.repositorioBase.Object,
                    this.adaptadorLocalizacion.Object);
        }

        [TestMethod]
        public void ConsultarPaisesTest()
        {
            IList<Pais> paisesActual;
            IList<Pais> paisesEsperado = new List<Pais>
            {
                new Pais
                {
                    Id = 1,
                    Name = "Colombia"
                },
                new Pais
                {
                    Id = 2,
                    Name = "Ecuador"
                }
            };


            this.adaptadorLocalizacion.Setup(
                it => it
                .ConsultarPaises())
                .Returns(
                    new List<Pais>
                    {
                        new Pais
                        {
                            Id = 1,
                            Name = "Colombia"
                        },
                        new Pais
                        {
                            Id = 2,
                            Name = "Ecuador"
                        }
                    }
                );

            paisesActual = this.negocioLocalizacion.ConsultarPaises();

            Assert.AreEqual(paisesEsperado.Count, paisesActual.Count);
            Assert.AreEqual(paisesEsperado[0].Id, paisesActual[0].Id);
        }

        [TestMethod]
        public void ConsultarPaisesSinResultadoTest()
        {
            IList<Pais> paisesActual;
            IList<Pais> paisesEsperado = new List<Pais>();

            this.adaptadorLocalizacion.Setup(
                it => it
                .ConsultarPaises())
                .Returns(
                    new List<Pais>()
                );

            paisesActual = this.negocioLocalizacion.ConsultarPaises();

            Assert.AreEqual(paisesEsperado.Count, paisesActual.Count);
        }

        [TestMethod]
        public void ObtenerPaisPorIdTest()
        {
            byte idPais = 1;
            Pais paisActual;
            Pais paisEsperado = new Pais
            {
                Id = 1,
                Name = "Colombia"
            };

            this.adaptadorLocalizacion.Setup(
                it => it
                .ConsultarPaises())
                .Returns(
                    new List<Pais>
                    {
                        new Pais
                        {
                            Id = 1,
                            Name = "Colombia"
                        },
                        new Pais
                        {
                            Id = 2,
                            Name = "Ecuador"
                        }
                    }
                );

            paisActual = this.negocioLocalizacion.ObtenerPaisPorId(idPais);

            Assert.AreEqual(paisEsperado.Id, paisActual.Id);
        }

        [TestMethod]
        public void ObtenerPaisPorIdSinPaisTest()
        {
            byte idPais = 3;
            Pais paisActual;

            this.adaptadorLocalizacion.Setup(
                it => it
                .ConsultarPaises())
                .Returns(
                    new List<Pais>
                    {
                        new Pais
                        {
                            Id = 1,
                            Name = "Colombia"
                        },
                        new Pais
                        {
                            Id = 2,
                            Name = "Ecuador"
                        }
                    }
                );

            paisActual = this.negocioLocalizacion.ObtenerPaisPorId(idPais);

            Assert.IsNull(paisActual);
        }

        [TestMethod]
        public void ObtenerPaisPorNombreTest()
        {
            string nombrePais = "Colombia";
            IList<string> paisActual;
            IList<string> paisEsperado = new List<string> { "1" };

            this.adaptadorLocalizacion.Setup(
                it => it
                .ConsultarPaises())
                .Returns(
                    new List<Pais>()
                    {
                        new Pais
                        {
                            Id = 1,
                            Name = "Colombia"
                        },
                        new Pais
                        {
                            Id = 2,
                            Name = "Ecuador"
                        }
                    }
                );

            paisActual = this.negocioLocalizacion.ObtenerIdPaisPorNombre(nombrePais);

            Assert.AreEqual(paisEsperado.Count, paisActual.Count);
            Assert.AreEqual(paisEsperado[0], paisActual[0]);
        }

        [TestMethod]
        public void ObtenerPaisPorNombreSinPaisesTest()
        {
            string nombrePais = "Peru";
            IList<string> paisActual;
            IList<string> paisEsperado = new List<string>();

            this.adaptadorLocalizacion.Setup(
                it => it
                .ConsultarPaises())
                .Returns(
                    new List<Pais>()
                    {
                        new Pais
                        {
                            Id = 1,
                            Name = "Colombia"
                        },
                        new Pais
                        {
                            Id = 2,
                            Name = "Ecuador"
                        }
                    }
                );

            paisActual = this.negocioLocalizacion.ObtenerIdPaisPorNombre(nombrePais);

            Assert.AreEqual(paisEsperado.Count, paisActual.Count);
        }
    }
}

