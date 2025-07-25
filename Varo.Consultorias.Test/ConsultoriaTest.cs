namespace Varo.Consultorias.Test
{
    using Varo.Consultorias.Entidades;
    using Varo.Consultorias.Negocio;
    using Varo.Consultorias.Repositorio;
    using Varo.Maestros.Entidades;
    using Varo.Maestros.Negocio;
    using Varo.Transversales.Entidades;
    using Varo.Transversales.Repositorio;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class ConsultoriaTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioConsultoria> repositorioConsultoria = null;
        private Mock<IRepositorioTecnologiaConsultoria> repositorioTecnologiaConsultoria = null;
        private Mock<INegocioUsuarios> negocioUsuarios = null;
        private Mock<INegocioClientes> negocioClientes = null;
        private Mock<INegocioLocalizacion> negocioLocalizacion = null;
        private INegocioConsultoria negocioConsultoria = null;
        private Guid idConsultoria;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioConsultoria = new Mock<IRepositorioConsultoria>();
            this.repositorioTecnologiaConsultoria = new Mock<IRepositorioTecnologiaConsultoria>();
            this.negocioUsuarios = new Mock<INegocioUsuarios>();
            this.negocioClientes = new Mock<INegocioClientes>();
            this.negocioLocalizacion = new Mock<INegocioLocalizacion>();
            this.idConsultoria = Guid.NewGuid();

            this.negocioConsultoria =
                new NegocioConsultoria(
                    this.repositorioBase.Object,
                    this.repositorioConsultoria.Object,
                    this.negocioUsuarios.Object,
                    this.negocioClientes.Object,
                    this.negocioLocalizacion.Object,
                    this.repositorioTecnologiaConsultoria.Object);
        }

        [TestMethod]
        public void ConsultarConsutoriaTest()
        {
            IList<ConsultoriaInformacionBasica> consultoriaActual;
            IList<ConsultoriaInformacionBasica> consultoriaEsperada = new List<ConsultoriaInformacionBasica>()
            {
                new ConsultoriaInformacionBasica
                {
                    Id = this.idConsultoria,
                    Nombre = "Consultoria"
                }
            };

            this.InicializarAdapatador();
            this.repositorioConsultoria
                .Setup(
                    it => it.Consultar(
                        It.IsAny<int>(),
                        It.IsAny<int>(),
                        It.IsAny<string>()))
                .Returns(
                    new List<ConsultoriaInformacionBasica>()
                    {
                        new ConsultoriaInformacionBasica
                        {
                            Id = this.idConsultoria,
                            Nombre = "Consultoria",
                            UsuarioRedGerente = "JBuendia",
                            UsuarioRedConsultor = "UIguaran",
                        }
                    }
                );

            consultoriaActual = this.negocioConsultoria.Consultar(It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>());

            Assert.AreEqual(consultoriaEsperada.Count, consultoriaActual.Count);
            Assert.AreEqual(consultoriaEsperada[0].Id, consultoriaActual[0].Id);
        }

        [TestMethod]
        public void ConsultarConsutoriaSinResultadosTest()
        {
            IList<ConsultoriaInformacionBasica> consultoriaActual;
            IList<ConsultoriaInformacionBasica> consultoriaEsperada = new List<ConsultoriaInformacionBasica>();

            this.repositorioConsultoria
                .Setup(
                    it => it.Consultar(
                        It.IsAny<int>(),
                        It.IsAny<int>(),
                        It.IsAny<string>()))
                .Returns(
                    new List<ConsultoriaInformacionBasica>()
                );

            consultoriaActual = this.negocioConsultoria.Consultar(It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>());

            Assert.AreEqual(consultoriaEsperada.Count, consultoriaActual.Count);
        }

        [TestMethod]
        public void ConsultarConsutoriaPaginadasPorParametrosTest()
        {
            IList<ConsultoriaInformacionBasica> consultoriaActual;
            IList<ConsultoriaInformacionBasica> consultoriaEsperada = new List<ConsultoriaInformacionBasica>()
            {
                new ConsultoriaInformacionBasica
                {
                    Id = this.idConsultoria,
                    Nombre = "Consultoria"
                }
            };

            this.InicializarAdapatador();
            this.repositorioConsultoria
                .Setup(
                    it => it.ConsultarPorParametro(
                        It.IsAny<int>(),
                        It.IsAny<int>(),
                        It.IsAny<string[]>(),
                        It.IsAny<string>()))
                .Returns(
                    new List<ConsultoriaInformacionBasica> {
                            new ConsultoriaInformacionBasica
                            {
                                Id = this.idConsultoria,
                                Nombre = "Consultoria",
                                UsuarioRedGerente = "lbolano",
                                UsuarioRedConsultor = "dospina",
                                Cliente = new Cliente
                                {
                                    Id = 1
                                }
                            }
                    }
                );

            consultoriaActual = this.negocioConsultoria.ConsultarPorParametro(It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>());

            Assert.AreEqual(consultoriaEsperada.Count, consultoriaActual.Count);
            Assert.AreEqual(consultoriaEsperada[0].Id, consultoriaActual[0].Id);
        }

        [TestMethod]
        public void ConsultarConsutoriaPaginadasPorParametrosSinResultadosTest()
        {
            IList<ConsultoriaInformacionBasica> consultoriaActual;
            IList<ConsultoriaInformacionBasica> consultoriaEsperada = new List<ConsultoriaInformacionBasica>();

            this.InicializarAdapatador();
            this.repositorioConsultoria
                .Setup(
                    it => it.ConsultarPorParametro(
                        It.IsAny<int>(),
                        It.IsAny<int>(),
                        It.IsAny<string[]>(),
                        It.IsAny<string>()))
                .Returns(
                    new List<ConsultoriaInformacionBasica>()
                );

            consultoriaActual = this.negocioConsultoria.ConsultarPorParametro(It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>());

            Assert.AreEqual(consultoriaEsperada.Count, consultoriaActual.Count);
        }

        [TestMethod]
        public void CrearConsultoriaTest()
        {

            this.repositorioConsultoria
                .Setup(
                    it => it.Crear(It.IsAny<Consultoria>()));

            this.repositorioTecnologiaConsultoria
                .Setup(
                 it => it.Crear(It.IsAny<TecnologiaConsultoria>()));

            Consultoria consultoria = new Consultoria
            {
                Nombre = "Varo"
            };

            TecnologiaConsultoria tecnologia = new TecnologiaConsultoria
            {
                Tecnologias = new List<Tecnologia>()
               {
                   new Tecnologia
                   {
                       Nombre = "C#"
                   }
               }
            };

            this.negocioConsultoria.Crear(
                consultoria,
                tecnologia);

        }

        [TestMethod]
        public void CrearConsultoriaConParametrosNulosTest()
        {
            this.repositorioConsultoria
               .Setup(
                   it => it.Crear(It.IsAny<Consultoria>()))
               .Returns(idConsultoria);

            Consultoria consultoria = new Consultoria
            {
                Nombre = "Varo"
            };

            TecnologiaConsultoria tecnologia = null;

            this.negocioConsultoria.Crear(
                consultoria,
                tecnologia);

            Assert.IsNull(tecnologia);

        }

        [TestMethod]
        public void EditarConsultoriaEstadoEnEjecucionTest()
        {

            this.repositorioConsultoria
                .Setup(
                    it => it.Obtener(It.IsAny<Guid>()))
                .Returns(new Consultoria
                {
                    Nombre = "Varo",
                    Estado = new ItemMaestro
                    {
                        Id = 1
                    }
                });


            this.repositorioConsultoria
                .Setup(
                    it => it.Editar(It.IsAny<Consultoria>()));

            this.repositorioTecnologiaConsultoria
                .Setup(
                 it => it.Crear(It.IsAny<TecnologiaConsultoria>()));

            this.repositorioTecnologiaConsultoria
               .Setup(
                it => it.EliminarPorIdConsultoria(It.IsAny<Guid>()));

            Consultoria consultoria = new Consultoria
            {
                Nombre = "Varo",
                FechaCreacion = new DateTime(2021, 11, 11),
                FechaCierre = new DateTime(2022, 11, 11),
                Estado = new Transversales.Entidades.ItemMaestro
                {
                    Id = 1
                }
            };

            TecnologiaConsultoria tecnologia = new TecnologiaConsultoria
            {
                Tecnologias = new List<Tecnologia>()
               {
                   new Tecnologia
                   {
                       Nombre = "C#"
                   }
               }
            };

            this.negocioConsultoria.Editar(
                consultoria,
                tecnologia);

            Assert.IsNotNull(consultoria.FechaCierre);

        }

        [TestMethod]
        public void EditarConsultoriaEstadoCerradoTest()
        {

            this.repositorioConsultoria
                .Setup(
                    it => it.Obtener(It.IsAny<Guid>()))
                .Returns(new Consultoria
                {
                    Nombre = "Varo",
                    Estado = new ItemMaestro
                    {
                        Id = 1
                    }
                });

            this.repositorioConsultoria
                .Setup(
                    it => it.Editar(It.IsAny<Consultoria>()));

            this.repositorioTecnologiaConsultoria
                .Setup(
                 it => it.Crear(It.IsAny<TecnologiaConsultoria>()));

            this.repositorioTecnologiaConsultoria
               .Setup(
                it => it.EliminarPorIdConsultoria(It.IsAny<Guid>()));

            Consultoria consultoria = new Consultoria
            {
                Nombre = "Varo",
                Estado = new Transversales.Entidades.ItemMaestro
                {
                    Id = 2
                }
            };

            TecnologiaConsultoria tecnologia = new TecnologiaConsultoria
            {
                Tecnologias = new List<Tecnologia>()
               {
                   new Tecnologia
                   {
                       Nombre = "C#"
                   }
               }
            };

            this.negocioConsultoria.Editar(
                consultoria,
                tecnologia);

            Assert.IsNotNull(consultoria.Nombre);

        }

        [TestMethod]
        public void EliminarConsultoriaTest()
        {

            this.repositorioConsultoria
                .Setup(
                    it => it.Eliminar(It.IsAny<Guid>()));

            this.repositorioTecnologiaConsultoria
               .Setup(
                it => it.EliminarPorIdConsultoria(It.IsAny<Guid>()));

            this.negocioConsultoria.Eliminar(idConsultoria);

        }

        [TestMethod]
        public void ObtenerConsultoriaTest()
        {
            Consultoria consultoriaEsperada = new Consultoria
            {
                Nombre = "Prueba",
                Id = idConsultoria,
            };

            this.repositorioConsultoria
                .Setup(
                    it => it.Obtener(It.IsAny<Guid>()))
                .Returns(new Consultoria
                {
                    Nombre = "Prueba",
                    Id = idConsultoria
                });

            this.InicializarAdapatador();

            this.repositorioTecnologiaConsultoria
               .Setup(
                it => it.EliminarPorIdConsultoria(It.IsAny<Guid>()));

            Consultoria consultoriaObtenida = this.negocioConsultoria.Obtener(idConsultoria);

            Assert.AreEqual(consultoriaEsperada.Id, consultoriaObtenida.Id);

        }

        [TestMethod]
        public void ObtenerConsultoriaNulaTest()
        {
            Consultoria consultoriaActual;
            Consultoria consultoriaEsperada = new Consultoria();


            this.repositorioConsultoria
                  .Setup(
                      it => it.Obtener(It.IsAny<Guid>()))
                  .Returns(new Consultoria());

            consultoriaActual = this.negocioConsultoria.Obtener(It.IsAny<Guid>());

            Assert.AreEqual(consultoriaEsperada.Id, consultoriaActual.Id);
        }

        [TestMethod]
        public void ListarConsutoriaTest()
        {
            IList<Consultoria> consultoriaActual;
            IList<Consultoria> consultoriaEsperada = new List<Consultoria>()
            {
                new Consultoria
                {
                    Id = this.idConsultoria,
                    Nombre = "Consultoria"
                }
            };

            this.InicializarAdapatador();
            this.repositorioConsultoria
                .Setup(
                    it => it.Listar())
                .Returns(
                    new List<Consultoria>()
                    {
                        new Consultoria
                        {
                            Id = this.idConsultoria,
                            Nombre = "Consultoria",
                        }
                    }
                );

            consultoriaActual = this.negocioConsultoria.Listar();

            Assert.AreEqual(consultoriaEsperada.Count, consultoriaActual.Count);
            Assert.AreEqual(consultoriaEsperada[0].Id, consultoriaActual[0].Id);
        }

        [TestMethod]
        public void ListarConsutoriaSinResultadosTest()
        {
            IList<Consultoria> consultoriaActual;
            IList<Consultoria> consultoriaEsperada = new List<Consultoria>();

            this.repositorioConsultoria
                .Setup(
                    it => it.Listar())
                .Returns(
                    new List<Consultoria>()
                );

            consultoriaActual = this.negocioConsultoria.Listar();

            Assert.AreEqual(consultoriaEsperada.Count, consultoriaActual.Count);
        }

        private void InicializarAdapatador()
        {
            this.negocioUsuarios
                .Setup(
                    it => it.ObtenerInformacionUsuario(It.Is<string>(usuario => usuario.Contains("JBuendia"))))
                .Returns(
                    new Usuario
                    {
                        DisplayName = "Jose Arcadio Buendia"
                    }
                );

            this.negocioUsuarios
                .Setup(
                    it => it.ObtenerInformacionUsuario(It.Is<string>(usuario => usuario.Contains("UIguaran"))))
                .Returns(
                    new Usuario
                    {
                        DisplayName = "Ursula Iguaran"
                    }
                );

            this.negocioUsuarios
                .Setup(
                    it => it.ObtenerInformacionUsuario(It.IsNotIn<string>("JBuendia", "UIguaran")))
                .Returns(
                    new Usuario
                    {
                        DisplayName = "Usuario"
                    }
                );

            this.negocioClientes
                .Setup(
                    it => it.ObtenerClientePorId(It.IsAny<int>()))
                .Returns(
                    new Cliente
                    {
                        Id = 1,
                        Name = "Cliente 1"
                    }
                );

            this.negocioClientes
                .Setup(
                    it => it.ObtenerIdClientePorNombre(It.IsAny<string>()))
                .Returns(
                    new List<string> { "1" }
                );

            this.negocioLocalizacion.Setup(
                it => it
                .ObtenerPaisPorId(It.IsAny<byte>()))
                .Returns(
                    new Pais
                    {
                        Id = 1,
                        Name = "Colombia"
                    }
                );

            this.negocioLocalizacion.Setup(
                it => it
                .ObtenerIdPaisPorNombre(It.IsAny<string>()))
                .Returns(
                     new List<string> { "1" }
                );

            this.negocioLocalizacion.Setup(
               it => it
               .ObtenerDepartamentoPorId(It.IsAny<int>()))
               .Returns(
                    new Departamento
                    {
                        Id = 1,
                        Name = "Antioquia",
                        Id_Country = 1
                    }
               );

            this.negocioLocalizacion.Setup(
                it => it
                .ObtenerCiudadPorId(It.IsAny<int>()))
                .Returns(
                    new Ciudad
                    {
                        Id = 1,
                        Id_State = 1,
                        Name = "Medellin"
                    }
                );

            this.negocioLocalizacion.Setup(
                it => it
                .ObtenerIdCiudadPorNombre(It.IsAny<string>()))
                .Returns(
                     new List<string> { "1" }
                );
        }
    }
}

