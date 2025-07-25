namespace Varo.Soluciones.Test
{
    using Varo.Maestros.Entidades;
    using Varo.Maestros.Negocio;
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Entidades;
    using Varo.Transversales.Repositorio;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Net.Mail;

    [TestClass]
    public class SolucionesTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioSolucion> repositorioSolucion = null;
        private Mock<IRepositorioIntegracionContinua> repositorioIntegracionContinua = null;
        private Mock<IRepositorioDespliegueContinuo> repositorioDespliegueContinuo = null;
        private Mock<IRepositorioMonitoreoContinuo> repositorioMonitoreoContinuo = null;
        private Mock<IRepositorioPracticaCalidad> repositorioPracticaCalidad = null;
        private Mock<IRepositorioTecnologiaSolucion> repositorioTecnologiaSolucion = null;
        private Mock<INegocioUsuarios> negocioUsuarios = null;
        private Mock<INegocioClientes> negocioClientes = null;
        private Mock<INegocioLocalizacion> negocioLocalizacion = null;
        private INegocioSoluciones negocioSoluciones = null;
        private Mock<INegocioHito> negocioHito = null;
        private Mock<INegocioPrueba> negocioPrueba = null;
        private Mock<INegocioAuditoria> negocioAuditoria = null;
        private Mock<INegocioMetricaAgil> negocioMetricaAgil = null;
        private Mock<INegocioNotificaciones> negocioNotificaciones = null;
        private Mock<INegocioEmail365> negocioEmail365 = null;
        private Guid idSolucion;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioSolucion = new Mock<IRepositorioSolucion>();
            this.repositorioIntegracionContinua = new Mock<IRepositorioIntegracionContinua>();
            this.repositorioDespliegueContinuo = new Mock<IRepositorioDespliegueContinuo>();
            this.repositorioMonitoreoContinuo = new Mock<IRepositorioMonitoreoContinuo>();
            this.repositorioPracticaCalidad = new Mock<IRepositorioPracticaCalidad>();
            this.repositorioTecnologiaSolucion = new Mock<IRepositorioTecnologiaSolucion>();
            this.negocioUsuarios = new Mock<INegocioUsuarios>();
            this.negocioClientes = new Mock<INegocioClientes>();
            this.negocioLocalizacion = new Mock<INegocioLocalizacion>();
            this.idSolucion = Guid.NewGuid();

            this.negocioHito = new Mock<INegocioHito>();
            this.negocioPrueba = new Mock<INegocioPrueba>();
            this.negocioAuditoria = new Mock<INegocioAuditoria>();
            this.negocioMetricaAgil = new Mock<INegocioMetricaAgil>();
            this.negocioNotificaciones = new Mock<INegocioNotificaciones>();
            this.negocioEmail365 = new Mock<INegocioEmail365>();

            this.negocioSoluciones =
                new NegocioSoluciones(
                    this.repositorioBase.Object,
                    this.repositorioSolucion.Object,
                    this.repositorioDespliegueContinuo.Object,
                    this.repositorioMonitoreoContinuo.Object,
                    this.repositorioIntegracionContinua.Object,
                    this.repositorioPracticaCalidad.Object,
                    this.repositorioTecnologiaSolucion.Object,
                    this.negocioUsuarios.Object,
                    this.negocioClientes.Object,
                    this.negocioLocalizacion.Object,
                    this.negocioHito.Object,
                    this.negocioPrueba.Object,
                    this.negocioAuditoria.Object,
                    this.negocioMetricaAgil.Object,
                    this.negocioNotificaciones.Object,
                    this.negocioEmail365.Object);
        }

        private void InicializarRepositorioSoluciones()
        {
            this.repositorioSolucion
                .Setup(
                    it => it.Consultar(
                        It.IsAny<int>(),
                        It.IsAny<int>(),
                        It.IsAny<string>()))
                .Returns(
                    new List<SolucionInformacionBasica> {
                            new SolucionInformacionBasica
                            {
                                Id = this.idSolucion,
                                Nombre = "Varo",
                                UsuarioRedGerente = "JBuendia",
                                UsuarioRedResponsable = "UIguaran",
                                UsuarioRedScrumMaster = "wcalderon",
                                Cliente = new Cliente
                                {
                                    Id = 1
                                }
                            }
                    }
                );

            this.repositorioSolucion
                .Setup(
                    it => it.ConsultarPorParametro(
                        It.IsAny<int>(),
                        It.IsAny<int>(),
                        It.IsAny<string[]>(),
                        It.IsAny<string>()))
                .Returns(
                    new List<SolucionInformacionBasica> {
                            new SolucionInformacionBasica
                            {
                                Id = this.idSolucion,
                                Nombre = "Varo",
                                UsuarioRedGerente = "JBuendia",
                                UsuarioRedResponsable = "UIguaran",
                                UsuarioRedScrumMaster = "wcalderon",
                                Cliente = new Cliente
                                {
                                    Id = 1
                                }
                            }
                    }
                );

            this.repositorioSolucion
               .Setup(
                   it => it.Consultar())
               .Returns(
                   new List<Solucion> {
                            new Solucion
                            {
                                Id = this.idSolucion,
                                Nombre = "Varo"
                            }
                   }
               );

            this.repositorioSolucion
                .Setup(
                    it => it.Obtener(It.IsAny<Guid>()))
                .Returns(
                    new Solucion
                    {
                        Id = this.idSolucion,
                        Nombre = "Varo",
                        UsuarioRedGerente = "JBuendia",
                        UsuarioRedResponsable = "UIguaran",
                        Cliente = new Cliente
                        {
                            Id = 1,
                            Name = "Cliente 1"
                        },
                        Estado = new ItemMaestro
                        {
                            Id = 1,
                            Nombre = "En Ejecución"
                        }
                    }
                );

            this.repositorioSolucion
                .Setup(
                    it => it.Crear(It.IsAny<Solucion>()));

            this.repositorioSolucion
                .Setup(
                    it => it.Editar(It.IsAny<Solucion>()));

            this.repositorioSolucion
                .Setup(
                    it => it.Eliminar(It.IsAny<Guid>()));


            this.repositorioTecnologiaSolucion
                .Setup(
                    it => it.Crear(It.IsAny<TecnologiaSolucion>()));

            this.repositorioTecnologiaSolucion
                .Setup(
                    it => it.EliminarPorIdSolucion(It.IsAny<Guid>()));


            this.repositorioIntegracionContinua
                .Setup(
                    it => it.EliminarPorIdSolucion(It.IsAny<Guid>()));

            this.repositorioDespliegueContinuo
                .Setup(
                    it => it.EliminarPorIdSolucion(It.IsAny<Guid>()));

            this.repositorioPracticaCalidad
                .Setup(
                    it => it.EliminarPorIdSolucion(It.IsAny<Guid>()));
        }

        private void InicializarNegocios()
        {
            this.negocioHito.Setup(
                    it => it.Obtener(It.IsAny<Guid>(), It.IsAny<string>()))
                .Returns(
                    new List<Hito>()
                );

            this.negocioPrueba.Setup(
                    it => it.ConsultarPorIdSolucion(It.IsAny<Guid>()))
                .Returns(
                    new Prueba()
                );

            this.negocioAuditoria.Setup(
                    it => it.Obtener(It.IsAny<Guid>()))
                .Returns(
                    new List<CalificacionAuditoria>()
                );

            this.negocioMetricaAgil.Setup(
                    it => it.Consultar(It.IsAny<Guid>()))
                .Returns(
                    new List<MetricasAgiles>()
                );
        }

        private void InicializarAdapatadorClientes()
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

        private void InicializarMarcoTrabajo()
        {
            this.repositorioSolucion
                .Setup(
                    it => it.Obtener(It.IsAny<Guid>()))
                .Returns(
                    new Solucion
                    {
                        Id = this.idSolucion,
                        MarcoTrabajo = new Transversales.Entidades.ItemMaestro() { Id = 3, Nombre = "Scrumban" }
                    }
                );
        }

        [TestMethod]
        public void ConsultarSolucionesPaginadasTest()
        {
            IList<SolucionInformacionBasica> solucionesActual;
            IList<SolucionInformacionBasica> solucionesEsperada = new List<SolucionInformacionBasica>()
            {
                new SolucionInformacionBasica
                {
                    Id = this.idSolucion,
                    Nombre = "Varo"
                }
            };

            this.InicializarAdapatadorClientes();
            this.InicializarRepositorioSoluciones();

            solucionesActual = this.negocioSoluciones.Consultar(It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>());

            Assert.AreEqual(solucionesEsperada.Count, solucionesActual.Count);
            Assert.AreEqual(solucionesEsperada[0].Id, solucionesActual[0].Id);
        }

        [TestMethod]
        public void ConsultarSolucionesPaginadasConUsuarioRedGerenteNuloTest()
        {
            IList<SolucionInformacionBasica> solucionesActual;
            IList<SolucionInformacionBasica> solucionesEsperada = new List<SolucionInformacionBasica>()
            {
                new SolucionInformacionBasica
                {
                    Id = this.idSolucion,
                    Nombre = "Varo"
                }
            };

            this.InicializarAdapatadorClientes();
            this.InicializarRepositorioSoluciones();

            this.repositorioSolucion
                .Setup(
                    it => it.Consultar(
                        It.IsAny<int>(),
                        It.IsAny<int>(),
                        It.IsAny<string>()))
                .Returns(
                    new List<SolucionInformacionBasica> {
                            new SolucionInformacionBasica
                            {
                                Id = this.idSolucion,
                                Nombre = "Varo",
                                Cliente = new Cliente
                                {
                                    Id = 1
                                }
                            }
                    }
                );

            solucionesActual = this.negocioSoluciones.Consultar(It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>());

            Assert.AreEqual(solucionesEsperada.Count, solucionesActual.Count);
            Assert.AreEqual(solucionesEsperada[0].Id, solucionesActual[0].Id);
            Assert.IsNull(solucionesActual[0].NombreGerente);
            Assert.IsNull(solucionesActual[0].NombreResponsable);
        }

        [TestMethod]
        public void ConsultarSolucionesPaginadasSinResultadoTest()
        {
            IList<SolucionInformacionBasica> solucionesActual;
            IList<SolucionInformacionBasica> solucionesEsperada = new List<SolucionInformacionBasica>();

            this.InicializarAdapatadorClientes();
            this.InicializarRepositorioSoluciones();

            this.repositorioSolucion
                .Setup(
                    it => it.Consultar(
                        It.IsAny<int>(),
                        It.IsAny<int>(),
                        It.IsAny<string>()))
                .Returns(
                    new List<SolucionInformacionBasica>()
                );

            solucionesActual = this.negocioSoluciones.Consultar(It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>());

            Assert.AreEqual(solucionesEsperada.Count, solucionesActual.Count);
        }

        [TestMethod]
        public void ConsultarSolucionesPaginadasPorParametrosTest()
        {
            IList<SolucionInformacionBasica> solucionesActual;
            IList<SolucionInformacionBasica> solucionesEsperada = new List<SolucionInformacionBasica>()
            {
                new SolucionInformacionBasica
                {
                    Id = this.idSolucion,
                    Nombre = "Varo"
                }
            };

            this.InicializarAdapatadorClientes();
            this.InicializarRepositorioSoluciones();

            solucionesActual = this.negocioSoluciones.ConsultarPorParametro(It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>());

            Assert.AreEqual(solucionesEsperada.Count, solucionesActual.Count);
            Assert.AreEqual(solucionesEsperada[0].Id, solucionesActual[0].Id);
        }

        [TestMethod]
        public void ConsultarSolucionesPaginadasPorParametrosConUsuarioRedGerenteNuloTest()
        {
            IList<SolucionInformacionBasica> solucionesActual;
            IList<SolucionInformacionBasica> solucionesEsperada = new List<SolucionInformacionBasica>()
            {
                new SolucionInformacionBasica
                {
                    Id = this.idSolucion,
                    Nombre = "Varo"
                }
            };

            this.InicializarAdapatadorClientes();
            this.InicializarRepositorioSoluciones();

            this.repositorioSolucion
                .Setup(
                    it => it.ConsultarPorParametro(
                        It.IsAny<int>(),
                        It.IsAny<int>(),
                        It.IsAny<string[]>(),
                        It.IsAny<string>()))
                .Returns(
                    new List<SolucionInformacionBasica> {
                            new SolucionInformacionBasica
                            {
                                Id = this.idSolucion,
                                Nombre = "Varo",
                                Cliente = new Cliente
                                {
                                    Id = 1
                                }
                            }
                    }
                );

            solucionesActual = this.negocioSoluciones.ConsultarPorParametro(It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>());

            Assert.AreEqual(solucionesEsperada.Count, solucionesActual.Count);
            Assert.AreEqual(solucionesEsperada[0].Id, solucionesActual[0].Id);
            Assert.IsNull(solucionesActual[0].NombreGerente);
            Assert.IsNull(solucionesActual[0].NombreResponsable);
        }

        [TestMethod]
        public void ConsultarSolucionesPaginadasPorParametrosSinResultadoTest()
        {
            IList<SolucionInformacionBasica> solucionesActual;
            IList<SolucionInformacionBasica> solucionesEsperada = new List<SolucionInformacionBasica>();

            this.InicializarAdapatadorClientes();
            this.InicializarRepositorioSoluciones();

            this.repositorioSolucion
                .Setup(
                    it => it.ConsultarPorParametro(
                        It.IsAny<int>(),
                        It.IsAny<int>(),
                        It.IsAny<string[]>(),
                        It.IsAny<string>()))
                .Returns(
                    new List<SolucionInformacionBasica>()
                );

            solucionesActual = this.negocioSoluciones.ConsultarPorParametro(It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>());

            Assert.AreEqual(solucionesEsperada.Count, solucionesActual.Count);
        }

        [TestMethod]
        public void ConsultarSolucionesTest()
        {
            IList<Solucion> solucionesActual;
            IList<Solucion> solucionesEsperada = new List<Solucion>()
            {
                new Solucion
                {
                    Id = this.idSolucion,
                    Nombre = "Varo"
                }
            };

            this.InicializarRepositorioSoluciones();
            this.InicializarAdapatadorClientes();

            solucionesActual = this.negocioSoluciones.Consultar();

            Assert.AreEqual(solucionesEsperada.Count, solucionesActual.Count);
            Assert.AreEqual(solucionesEsperada[0].Id, solucionesActual[0].Id);
        }

        [TestMethod]
        public void ConsultarSolucionesSinResultadoTest()
        {
            IList<Solucion> solucionesActual;
            IList<Solucion> solucionesEsperada = new List<Solucion>();

            this.InicializarRepositorioSoluciones();

            this.repositorioSolucion
                .Setup(
                    it => it.Consultar())
                .Returns(
                    new List<Solucion>()
                );

            solucionesActual = this.negocioSoluciones.Consultar();

            Assert.AreEqual(solucionesEsperada.Count, solucionesActual.Count);
        }

        [TestMethod]
        public void ObtenerSolucionTest()
        {
            Solucion solucionesActual;
            Solucion solucionesEsperada = new Solucion
            {
                Id = this.idSolucion,
                Nombre = "Varo"
            };

            this.InicializarAdapatadorClientes();
            this.InicializarRepositorioSoluciones();

            solucionesActual = this.negocioSoluciones.Obtener(It.IsAny<Guid>());

            Assert.AreEqual(solucionesEsperada.Id, solucionesActual.Id);
        }

        [TestMethod]
        public void ObtenerSolucionNulaTest()
        {
            Solucion solucionesActual;
            Solucion solucionesEsperada = new Solucion();

            this.InicializarAdapatadorClientes();
            this.InicializarRepositorioSoluciones();

            this.repositorioSolucion
                .Setup(
                    it => it.Obtener(It.IsAny<Guid>()))
                .Returns(
                    new Solucion()
                );

            solucionesActual = this.negocioSoluciones.Obtener(It.IsAny<Guid>());

            Assert.AreEqual(solucionesEsperada.Id, solucionesActual.Id);
        }

        [TestMethod]
        public void ObtenerIdSolucionTest()
        {
            this.InicializarAdapatadorClientes();
            this.InicializarRepositorioSoluciones();

            Guid IdSolucion = this.negocioSoluciones.ObtenerIdSolucion(1);

            Assert.IsNotNull(IdSolucion);
        }

        [TestMethod]
        public void CrearSolucionTest()
        {
            this.InicializarRepositorioSoluciones();

            Solucion solucion = new Solucion
            {
                Nombre = "Varo"
            };

            TecnologiaSolucion tecnologia = new TecnologiaSolucion
            {
                Tecnologias = new List<TecnologiaSolucion>()
               {
                   new TecnologiaSolucion
                   {
                       Nombre = "C#"
                   }
               }
            };

            IntegracionesContinuas integracionesContinuas = new IntegracionesContinuas
            {
                ListaIntegracionesContinuas = new List<IntegracionesContinuas>()
                {
                    new IntegracionesContinuas
                    {
                        Nombre = "Varo-CI"
                    }
                }
            };

            DesplieguesContinuos desplieguesContinuos = new DesplieguesContinuos
            {
                ListaDeplieguesContinuos = new List<DesplieguesContinuos>()
                {
                    new DesplieguesContinuos
                    {
                        Nombre = "Varo-CD"
                    }
                }
            };
            MonitoreosContinuos monitoreosContinuos = new MonitoreosContinuos
            {
                ListaMonitoreosContinuos = new List<MonitoreosContinuos>()
                {
                    new MonitoreosContinuos
                    {
                        Nombre = "Varo-CD"
                    }
                }
            };
            PracticasCalidad practicasCalidad = new PracticasCalidad();

            this.negocioSoluciones.Crear(
                solucion,
                tecnologia,
                desplieguesContinuos,
                monitoreosContinuos,
                integracionesContinuas,
                practicasCalidad);

            Assert.AreEqual(tecnologia.Tecnologias[0].IdSolucion, solucion.Id);
            Assert.AreEqual(desplieguesContinuos.ListaDeplieguesContinuos[0].IdSolucion, solucion.Id);
            Assert.AreEqual(monitoreosContinuos.ListaMonitoreosContinuos[0].IdSolucion, solucion.Id);
            Assert.AreEqual(integracionesContinuas.ListaIntegracionesContinuas[0].IdSolucion, solucion.Id);
            Assert.AreEqual(practicasCalidad.id, solucion.Id);
        }

        [TestMethod]
        public void CrearSolucionConParametrosNulosTest()
        {
            this.InicializarRepositorioSoluciones();

            Solucion solucion = new Solucion
            {
                Nombre = "Varo"
            };

            TecnologiaSolucion tecnologia = null;
            IntegracionesContinuas integracionesContinuas = null;
            DesplieguesContinuos desplieguesContinuos = null;
            MonitoreosContinuos monitoreoContinuo = null;
            PracticasCalidad practicasCalidad = null;

            this.negocioSoluciones.Crear(
                solucion,
                tecnologia,
                desplieguesContinuos,
                monitoreoContinuo,
                integracionesContinuas,
                practicasCalidad);

            Assert.IsNull(tecnologia);
            Assert.IsNull(desplieguesContinuos);
            Assert.IsNull(monitoreoContinuo);
            Assert.IsNull(integracionesContinuas);
            Assert.IsNull(practicasCalidad);
        }

        [TestMethod]
        public void EditarSolucionTest()
        {
            this.InicializarRepositorioSoluciones();
            this.InicializarAdapatadorClientes();

            Solucion solucion = new Solucion
            {
                Id = Guid.NewGuid(),
                Nombre = "Varo"
            };

            TecnologiaSolucion tecnologia = new TecnologiaSolucion
            {
                Tecnologias = new List<TecnologiaSolucion>()
               {
                   new TecnologiaSolucion
                   {
                       Nombre = "C#"
                   }
               }
            };

            IntegracionesContinuas integracionesContinuas = new IntegracionesContinuas
            {
                ListaIntegracionesContinuas = new List<IntegracionesContinuas>()
                {
                    new IntegracionesContinuas
                    {
                        Nombre = "Varo-CI"
                    }
                }
            };

            DesplieguesContinuos desplieguesContinuos = new DesplieguesContinuos
            {
                ListaDeplieguesContinuos = new List<DesplieguesContinuos>()
                {
                    new DesplieguesContinuos
                    {
                        Nombre = "Varo-CD"
                    }
                }
            };
            MonitoreosContinuos monitoreosContinuos = new MonitoreosContinuos
            {
                ListaMonitoreosContinuos = new List<MonitoreosContinuos>()
                {
                    new MonitoreosContinuos
                    {
                        Nombre = "Varo-CD"
                    }
                }
            };

            PracticasCalidad practicasCalidad = new PracticasCalidad();

            this.negocioSoluciones.Editar(
                solucion,
                tecnologia,
                desplieguesContinuos,
                monitoreosContinuos,
                integracionesContinuas,
                practicasCalidad);

            Assert.AreEqual(tecnologia.Tecnologias[0].IdSolucion, solucion.Id);
            Assert.AreEqual(desplieguesContinuos.ListaDeplieguesContinuos[0].IdSolucion, solucion.Id);
            Assert.AreEqual(monitoreosContinuos.ListaMonitoreosContinuos[0].IdSolucion, solucion.Id);
            Assert.AreEqual(integracionesContinuas.ListaIntegracionesContinuas[0].IdSolucion, solucion.Id);
            Assert.AreEqual(practicasCalidad.id, solucion.Id);
        }

        [TestMethod]
        public void EditarSolucionConParametrosNulosTest()
        {
            this.InicializarRepositorioSoluciones();
            this.InicializarAdapatadorClientes();

            Solucion solucion = new Solucion
            {
                Id = Guid.NewGuid(),
                Nombre = "Varo"
            };

            TecnologiaSolucion tecnologia = null;
            IntegracionesContinuas integracionesContinuas = null;
            DesplieguesContinuos desplieguesContinuos = null;
            MonitoreosContinuos monitoreosContinuos = null;
            PracticasCalidad practicasCalidad = null;

            this.negocioSoluciones.Crear(
                solucion,
                tecnologia,
                desplieguesContinuos,
                monitoreosContinuos,
                integracionesContinuas,
                practicasCalidad);

            Assert.IsNull(tecnologia);
            Assert.IsNull(desplieguesContinuos);
            Assert.IsNull(monitoreosContinuos);
            Assert.IsNull(integracionesContinuas);
            Assert.IsNull(practicasCalidad);
        }

        [TestMethod]
        public void EditarSolucionConCambioEstadoTest()
        {
            this.InicializarRepositorioSoluciones();
            this.InicializarAdapatadorClientes();

            this.repositorioSolucion
                .Setup(
                    it => it.Obtener(It.IsAny<Guid>()))
                .Returns(
                    new Solucion
                    {
                        Id = this.idSolucion,
                        Nombre = "Varo",
                        UsuarioRedGerente = "JBuendia",
                        UsuarioRedResponsable = "UIguaran",
                        Cliente = new Cliente
                        {
                            Id = 1,
                            Name = "Cliente 1"
                        },
                        Estado = new ItemMaestro
                        {
                            Id = 1
                        }
                    }
                );

            this.negocioNotificaciones
                .Setup(
                    it => it.ConsultarPorId(It.IsAny<int>()))
                .Returns(
                    "prueba@prueba.com"
                );

            this.negocioEmail365
                .Setup(
                    it => it.EnviarCorreo(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<MailAddress>>()));

            Solucion solucion = new Solucion
            {
                Id = Guid.NewGuid(),
                Nombre = "Varo",
                Estado = new ItemMaestro
                {
                    Id = 3
                }
            };

            TecnologiaSolucion tecnologia = new TecnologiaSolucion
            {
                Tecnologias = new List<TecnologiaSolucion>()
               {
                   new TecnologiaSolucion
                   {
                       Nombre = "C#"
                   }
               }
            };

            IntegracionesContinuas integracionesContinuas = new IntegracionesContinuas
            {
                ListaIntegracionesContinuas = new List<IntegracionesContinuas>()
                {
                    new IntegracionesContinuas
                    {
                        Nombre = "Varo-CI"
                    }
                }
            };

            DesplieguesContinuos desplieguesContinuos = new DesplieguesContinuos
            {
                ListaDeplieguesContinuos = new List<DesplieguesContinuos>()
                {
                    new DesplieguesContinuos
                    {
                        Nombre = "Varo-CD"
                    }
                }
            };

            MonitoreosContinuos monitoreosContinuos = new MonitoreosContinuos
            {
                ListaMonitoreosContinuos = new List<MonitoreosContinuos>()
                {
                    new MonitoreosContinuos
                    {
                        Nombre = "Varo-CD"
                    }
                }
            };

            PracticasCalidad practicasCalidad = new PracticasCalidad();

            this.negocioSoluciones.Editar(
                solucion,
                tecnologia,
                desplieguesContinuos,
                monitoreosContinuos,
                integracionesContinuas,
                practicasCalidad);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void EditarSolucionSinCambioEstadoTest()
        {
            this.InicializarRepositorioSoluciones();
            this.InicializarAdapatadorClientes();

            this.repositorioSolucion
                .Setup(
                    it => it.Obtener(It.IsAny<Guid>()))
                .Returns(
                    new Solucion
                    {
                        Id = this.idSolucion,
                        Nombre = "Varo",
                        UsuarioRedGerente = "JBuendia",
                        UsuarioRedResponsable = "UIguaran",
                        Cliente = new Cliente
                        {
                            Id = 1,
                            Name = "Cliente 1"
                        },
                        Estado = new ItemMaestro
                        {
                            Id = 1
                        }
                    }
                );

            this.negocioNotificaciones
                .Setup(
                    it => it.ConsultarPorId(It.IsAny<int>()))
                .Returns(
                    "prueba@prueba.com"
                );

            this.negocioEmail365
                .Setup(
                    it => it.EnviarCorreo(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<MailAddress>>()));

            Solucion solucion = new Solucion
            {
                Id = Guid.NewGuid(),
                Nombre = "Varo",
                Estado = new ItemMaestro
                {
                    Id = 1
                }
            };

            TecnologiaSolucion tecnologia = new TecnologiaSolucion
            {
                Tecnologias = new List<TecnologiaSolucion>()
               {
                   new TecnologiaSolucion
                   {
                       Nombre = "C#"
                   }
               }
            };

            IntegracionesContinuas integracionesContinuas = new IntegracionesContinuas
            {
                ListaIntegracionesContinuas = new List<IntegracionesContinuas>()
                {
                    new IntegracionesContinuas
                    {
                        Nombre = "Varo-CI"
                    }
                }
            };

            DesplieguesContinuos desplieguesContinuos = new DesplieguesContinuos
            {
                ListaDeplieguesContinuos = new List<DesplieguesContinuos>()
                {
                    new DesplieguesContinuos
                    {
                        Nombre = "Varo-CD"
                    }
                }
            };

            MonitoreosContinuos monitoreosContinuos = new MonitoreosContinuos
            {
                ListaMonitoreosContinuos = new List<MonitoreosContinuos>()
                {
                    new MonitoreosContinuos
                    {
                        Nombre = "Varo-CD"
                    }
                }
            };

            PracticasCalidad practicasCalidad = new PracticasCalidad();

            this.negocioSoluciones.Editar(
                solucion,
                tecnologia,
                desplieguesContinuos,
                monitoreosContinuos,
                integracionesContinuas,
                practicasCalidad);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void EliminarSolucionTest()
        {
            this.InicializarNegocios();
            this.InicializarRepositorioSoluciones();

            this.negocioSoluciones.Eliminar(It.IsAny<Guid>());
        }

        [TestMethod]
        public void EsSolucionScrumbanTest()
        {
            this.InicializarRepositorioSoluciones();
            this.InicializarMarcoTrabajo();

            bool mostrarIncendios = this.negocioSoluciones.EsSolucionScrumban(It.IsAny<Guid>());

            Assert.AreEqual(false, mostrarIncendios);
        }

        [TestMethod]
        public void NoEsSolucionScrumbanTest()
        {
            this.InicializarRepositorioSoluciones();

            bool mostrarIncendios = this.negocioSoluciones.EsSolucionScrumban(It.IsAny<Guid>());

            Assert.AreEqual(true, mostrarIncendios);
        }
    }
}

