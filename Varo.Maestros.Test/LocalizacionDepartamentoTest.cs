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
    public class LocalizacionDepartamentoTest
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
        public void ConsultarDepartamentoPorIdPaisTest()
        {
            byte idPais = 82;
            IList<Departamento> departamentoActual;
            IList<Departamento> departamentoEsperado = new List<Departamento>
            {
                new Departamento
                {
                    Id = 1699,
                    Name = "Amazonas",
                    Id_Country = 82
                },
                new Departamento
                {
                    Id = 1700,
                    Name = "Antioquia",
                    Id_Country = 82
                }
            };


            this.adaptadorLocalizacion.Setup(
                it => it
                .ConsultarDepartamentosPorIdPais(idPais))
                .Returns(
                    new List<Departamento>
                    {
                        new Departamento
                        {
                            Id = 1699,
                            Name = "Amazonas",
                            Id_Country = 82
                        },
                        new Departamento
                        {
                            Id = 1700,
                            Name = "Antioquia",
                            Id_Country = 82
                        }
                    }
                );

            departamentoActual = this.negocioLocalizacion.ConsultarDepartamentosPorIdPais(idPais);

            Assert.AreEqual(departamentoEsperado.Count, departamentoActual.Count);
            Assert.AreEqual(departamentoEsperado[0].Id, departamentoActual[0].Id);
        }

        [TestMethod]
        public void ConsultarDepartamentosPorIdPaisSinResultadoTest()
        {
            byte idPais = 2;
            IList<Departamento> departamentoActual;
            IList<Departamento> departamentoEsperado = new List<Departamento>();

            this.adaptadorLocalizacion.Setup(
                it => it
                .ConsultarDepartamentosPorIdPais(idPais))
                .Returns(new List<Departamento>
                {
                }
                );

            departamentoActual = this.negocioLocalizacion.ConsultarDepartamentosPorIdPais(idPais);

            Assert.AreEqual(departamentoEsperado.Count, departamentoActual.Count);
        }

        [TestMethod]
        public void ConsultarDepartamentosTest()
        {
            IList<Departamento> departamentoActual;
            IList<Departamento> departamentoEsperado = new List<Departamento>
            {
                new Departamento
                {
                    Id = 1699,
                    Name = "Amazonas",
                    Id_Country = 82
                },
                new Departamento
                {
                    Id = 1700,
                    Name = "Antioquia",
                    Id_Country = 82
                }
            };

            this.adaptadorLocalizacion.Setup(
                it => it
                .ConsultarDepartamentos())
                .Returns(new List<Departamento>
                {
                     new Departamento
                        {
                            Id = 1699,
                            Name = "Amazonas",
                            Id_Country = 82
                        },
                        new Departamento
                        {
                            Id = 1700,
                            Name = "Antioquia",
                            Id_Country = 82
                        }
                }
                );

            departamentoActual = this.negocioLocalizacion.ConsultarDepartamentos();

            Assert.AreEqual(departamentoEsperado.Count, departamentoActual.Count);
        }

        [TestMethod]
        public void ObtenerDepartamentoPorIdTest()
        {
            int idDepartamento = 1;
            Departamento departamentoActual;
            Departamento departamentoEsperado = new Departamento
            {
                Id = 1,
                Name = "Amazonas",
                Id_Country = 1
            };

            this.adaptadorLocalizacion.Setup(
                it => it
                .ConsultarDepartamentos())
                .Returns(
                    new List<Departamento>
                    {
                        new Departamento
                        {
                            Id = 1,
                            Name = "Amazonas",
                            Id_Country = 1
                        },
                        new Departamento
                        {
                            Id = 2,
                            Name = "Antioquia",
                            Id_Country = 1
                        }
                    }
                );

            departamentoActual = this.negocioLocalizacion.ObtenerDepartamentoPorId(idDepartamento);

            Assert.AreEqual(departamentoEsperado.Id, departamentoActual.Id);
        }

        [TestMethod]
        public void ObtenerDepartamentoPorIdSinDepartamentoTest()
        {
            int idDepartamento = 3;
            Departamento departamentoActual;

            this.adaptadorLocalizacion.Setup(
                it => it
                .ConsultarDepartamentos())
                .Returns(
                    new List<Departamento>
                    {
                        new Departamento
                        {
                            Id = 1,
                            Name = "Amazonas",
                            Id_Country = 1
                        },
                        new Departamento
                        {
                            Id = 2,
                            Name = "Antioquia",
                            Id_Country = 1
                        }
                    }
                );

            departamentoActual = this.negocioLocalizacion.ObtenerDepartamentoPorId(idDepartamento);

            Assert.IsNull(departamentoActual);
        }
    }
}

