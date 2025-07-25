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
    public class LocalizacionCiudadTest
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
        public void ConsultarCiudadesPorIdDepartamentoTest()
        {
            int idDepartamento = 1;
            IList<Ciudad> ciudadActual;
            IList<Ciudad> ciudadEsperado = new List<Ciudad>()
            {
                new Ciudad
                {
                    Id = 1,
                    Id_State = 1,
                    Name = "Medellin"
                },
                new Ciudad
                {
                    Id = 2,
                    Id_State = 1,
                    Name = "Sabaneta"
                }
            };

            this.adaptadorLocalizacion.Setup(
                it => it
                .ConsultarCiudadesPorIdDepartamento(idDepartamento))
                .Returns(
                    new List<Ciudad>()
                    {
                        new Ciudad
                        {
                            Id = 1,
                            Id_State = 1,
                            Name = "Medellin"
                        },
                        new Ciudad
                        {
                            Id = 2,
                            Id_State = 1,
                            Name = "Sabaneta"
                        }
                    }
                );

            ciudadActual = this.negocioLocalizacion.ConsultarCiudadesPorIdDepartamento(idDepartamento);

            Assert.AreEqual(ciudadEsperado.Count, ciudadActual.Count);
            Assert.AreEqual(ciudadEsperado[0].Id, ciudadActual[0].Id);
        }

        [TestMethod]
        public void ConsultarCiudadesPorIdDepartamentoSinResultadoTest()
        {
            int idDepartamento = 2;
            IList<Ciudad> ciudadActual;
            IList<Ciudad> ciudadEsperado = new List<Ciudad>();

            this.adaptadorLocalizacion.Setup(
                it => it
                .ConsultarCiudadesPorIdDepartamento(idDepartamento))
                .Returns(
                    new List<Ciudad>()
                    {
                    }
                );

            ciudadActual = this.negocioLocalizacion.ConsultarCiudadesPorIdDepartamento(idDepartamento);

            Assert.AreEqual(ciudadEsperado.Count, ciudadActual.Count);
        }

        [TestMethod]
        public void ObtenerCiudadPorIdTest()
        {
            int idCiudad = 1;
            Ciudad ciudadActual;
            Ciudad ciudadEsperado = new Ciudad
            {
                Id = 1,
                Id_State = 1,
                Name = "Medellin"
            };

            this.adaptadorLocalizacion.Setup(
                it => it
                .ConsultarCiudades())
                .Returns(
                    new List<Ciudad>()
                    {
                        new Ciudad
                        {
                            Id = 1,
                            Id_State = 1,
                            Name = "Medellin"
                        },
                        new Ciudad
                        {
                            Id = 2,
                            Id_State = 1,
                            Name = "Sabaneta"
                        },
                    }
                );

            ciudadActual = this.negocioLocalizacion.ObtenerCiudadPorId(idCiudad);

            Assert.AreEqual(ciudadEsperado.Id, ciudadActual.Id);
        }

        [TestMethod]
        public void ObtenerCiudadPorIdSinCiudadTest()
        {
            int idCiudad = 3;
            Ciudad ciudadActual;

            this.adaptadorLocalizacion.Setup(
                it => it
                .ConsultarCiudades())
                .Returns(
                    new List<Ciudad>()
                    {
                        new Ciudad
                        {
                            Id = 1,
                            Id_State = 1,
                            Name = "Medellin"
                        },
                        new Ciudad
                        {
                            Id = 2,
                            Id_State = 1,
                            Name = "Sabaneta"
                        },
                    }
                );

            ciudadActual = this.negocioLocalizacion.ObtenerCiudadPorId(idCiudad);

            Assert.IsNull(ciudadActual);
        }
        [TestMethod]
        public void ObtenerCiudadPorNombreTest()
        {
            string nombreCiudad = "Medellin";
            IList<string> ciudadActual;
            IList<string> ciudadEsperado = new List<string> { "1" };

            this.adaptadorLocalizacion.Setup(
                it => it
                .ConsultarCiudades())
                .Returns(
                    new List<Ciudad>()
                    {
                        new Ciudad
                        {
                            Id = 1,
                            Id_State = 1,
                            Name = "Medellin"
                        },
                        new Ciudad
                        {
                            Id = 2,
                            Id_State = 1,
                            Name = "Sabaneta"
                        },
                    }
                );

            ciudadActual = this.negocioLocalizacion.ObtenerIdCiudadPorNombre(nombreCiudad);

            Assert.AreEqual(ciudadEsperado.Count, ciudadActual.Count);
            Assert.AreEqual(ciudadEsperado[0], ciudadActual[0]);
        }

        [TestMethod]
        public void ObtenerCiudadPorNombreSinCiudadTest()
        {
            string nombreCiudad = "Bogota";
            IList<string> ciudadActual;
            IList<string> ciudadEsperado = new List<string>();

            this.adaptadorLocalizacion.Setup(
                it => it
                .ConsultarCiudades())
                .Returns(
                    new List<Ciudad>()
                    {
                        new Ciudad
                        {
                            Id = 1,
                            Id_State = 1,
                            Name = "Medellin"
                        },
                        new Ciudad
                        {
                            Id = 2,
                            Id_State = 1,
                            Name = "Sabaneta"
                        },
                    }
                );

            ciudadActual = this.negocioLocalizacion.ObtenerIdCiudadPorNombre(nombreCiudad);

            Assert.AreEqual(ciudadEsperado.Count, ciudadActual.Count);
        }
    }
}

