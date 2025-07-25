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
    public class HitosTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioHito> repositorioHito = null;
        private Mock<INegocioUsuarios> negocioUsuarios = null;
        private Mock<INegocioEmail365> negocioEmail365 = null;

        private INegocioHito negocioHito = null;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioHito = new Mock<IRepositorioHito>();
            this.negocioUsuarios = new Mock<INegocioUsuarios>();
            this.negocioEmail365 = new Mock<INegocioEmail365>();

            this.negocioHito =
                new NegocioHito(
                    this.repositorioBase.Object,
                    this.repositorioHito.Object,
                    this.negocioUsuarios.Object,
                    this.negocioEmail365.Object);
        }

        [TestMethod]
        public void CrearHitoTest()
        {
            Guid id = Guid.NewGuid();
            Guid idSolucion = Guid.NewGuid();

            Hito hito = new Hito()
            {
                IdSolucion = idSolucion,
                ListaHitos = new List<Hito>()
                {
                    new Hito()
                    {
                        Id = id,
                        IdSolucion = idSolucion,
                        Descripcion = "AAA",
                        FechaCierre = new DateTime(2020, 02, 02)
                    }
                }
            };

            this.repositorioHito.Setup(
                it => it.Crear(
                   It.IsAny<Hito>()));

            this.negocioHito.Crear(hito);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void CrearHitoNullTest()
        {
            Guid id = Guid.NewGuid();
            Guid idSolucion = Guid.NewGuid();

            Hito hito = null;

            this.repositorioHito.Setup(
                it => it.Crear(
                   It.IsAny<Hito>()));

            this.negocioHito.Crear(hito);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ObtenerHitosPorIdSolucionTest()
        {
            Guid id = Guid.NewGuid();
            IList<Hito> hitoActual;
            IList<Hito> hitoEsperado = new List<Hito>()
            {
                new Hito
                {
                    Id = id,
                    Descripcion = "AAA",
                    FechaCierre = new DateTime(2020,02,02),
                    Tipo = new Transversales.Entidades.ItemMaestro() {Id = 1, Nombre = "Definición de arquitectura"},
                }
            };

            this.repositorioHito.Setup(
                it => it
                .Obtener(
                    It.IsAny<Guid>(), It.IsAny<string>()))
                .Returns(
                    new List<Hito>()
                    {
                        new Hito
                        {
                            Id = id,
                            Descripcion = "AAA",
                            FechaCierre = new DateTime(2020,02,02),
                            Tipo = new Transversales.Entidades.ItemMaestro() {Id = 1, Nombre = "Definición de arquitectura"}

                        }
                    }
                );

            hitoActual = this.negocioHito.Obtener(It.IsAny<Guid>(), It.IsAny<string>());

            Assert.AreEqual(hitoEsperado.Count, hitoActual.Count);
            Assert.AreEqual(hitoEsperado[0].Id, hitoActual[0].Id);
        }

        [TestMethod]
        public void ObtenerHitosPorIdSolucionSinResultadoTest()
        {
            Guid id = Guid.NewGuid();
            IList<Hito> hitoActual;
            IList<Hito> hitoEsperado = new List<Hito>();

            this.repositorioHito.Setup(
                it => it
                .Obtener(
                    It.IsAny<Guid>(), It.IsAny<string>()))
                .Returns(
                    new List<Hito>()
                );

            hitoActual = this.negocioHito.Obtener(
                It.IsAny<Guid>(), It.IsAny<string>());

            Assert.AreEqual(hitoEsperado.Count, hitoEsperado.Count);
        }

        [TestMethod]
        public void EnviarCorreoTest()
        {
            Guid id = Guid.NewGuid();

            this.negocioUsuarios
                .Setup(it => it.ObtenerInformacionUsuario(It.IsAny<string>()))
                .Returns(
                    new Usuario
                    {
                        Mail = "prueba@company.com",
                        DisplayName = "Aureliano Buendia"
                    }
                );

            this.negocioEmail365
                .Setup(it => it.EnviarCorreo(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<MailAddress>>()));

            this.repositorioHito.Setup(
                it => it
                .Obtener(
                    It.IsAny<Guid>(), It.IsAny<string>()))
                .Returns(
                    new List<Hito>()
                    {
                        new Hito
                        {
                            Id = id,
                            Descripcion = "Lorem ipsum",
                            FechaCierre = new DateTime(2020,02,02),
                            Estado = new ItemMaestro
                            {
                                Id = 1,
                                Nombre = "Abierto"
                            },
                            Tipo = new ItemMaestro
                            {
                                Id = 1,
                                Nombre = "Definición de arquitectura"
                            }

                        }
                    }
                );

            Solucion solucion = new Solucion
            {
                Nombre = "Varo",
                UsuarioRedGerente = "prueba",
                UsuarioRedResponsable = "prueba",
                UsuarioRedScrumMaster = "prueba",
                Cliente = new Cliente
                {
                    Name = "Cliente 1"
                }
            };
            string emailArquitecto = "";
            string emailAdicionales = "";
            string lenguaje = "ES";

            this.negocioHito.EnviarCorreo(solucion, emailArquitecto, emailAdicionales, lenguaje);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void EnviarCorreoSinHitosTest()
        {
            Guid id = Guid.NewGuid();

            this.negocioUsuarios
                .Setup(it => it.ObtenerInformacionUsuario(It.IsAny<string>()))
                .Returns(
                    new Usuario
                    {
                        Mail = "prueba@company.com",
                        DisplayName = "Aureliano Buendia"
                    }
                );

            this.negocioEmail365
                .Setup(it => it.EnviarCorreo(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<MailAddress>>()));

            this.repositorioHito.Setup(
                it => it
                .Obtener(
                    It.IsAny<Guid>(), It.IsAny<string>()))
                .Returns(
                    new List<Hito>()
                );


            Solucion solucion = new Solucion
            {
                Nombre = "Varo",
                UsuarioRedGerente = "prueba",
                UsuarioRedResponsable = "prueba",
                UsuarioRedScrumMaster = "prueba",
                Cliente = new Cliente
                {
                    Name = "Cliente 1"
                }
            };
            string emailArquitecto = "";
            string emailAdicionales = "";
            string lenguaje = "ES";

            this.negocioHito.EnviarCorreo(solucion, emailArquitecto, emailAdicionales, lenguaje);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void EnviarCorreoSinHitosAbiertosTest()
        {
            Guid id = Guid.NewGuid();

            this.negocioUsuarios
                .Setup(it => it.ObtenerInformacionUsuario(It.IsAny<string>()))
                .Returns(
                    new Usuario
                    {
                        Mail = "prueba@company.com",
                        DisplayName = "Aureliano Buendia"
                    }
                );

            this.negocioEmail365
                .Setup(it => it.EnviarCorreo(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<MailAddress>>()));

            this.repositorioHito.Setup(
                it => it
                .Obtener(
                    It.IsAny<Guid>(), It.IsAny<string>()))
                .Returns(
                    new List<Hito>()
                    {
                        new Hito
                        {
                            Id = id,
                            Descripcion = "Lorem ipsum",
                            FechaCierre = new DateTime(2020,02,02),
                            Estado = new ItemMaestro
                            {
                                Id = 3,
                                Nombre = "Cerrado"
                            },
                            Tipo = new ItemMaestro
                            {
                                Id = 1,
                                Nombre = "Definición de arquitectura"
                            }

                        }
                    }
                );

            Solucion solucion = new Solucion
            {
                Nombre = "Varo",
                UsuarioRedGerente = "prueba",
                UsuarioRedResponsable = "prueba",
                UsuarioRedScrumMaster = "prueba",
                Cliente = new Cliente
                {
                    Name = "Cliente 1"
                }
            };
            string emailArquitecto = "";
            string emailAdicionales = "";
            string lenguaje = "ES";

            this.negocioHito.EnviarCorreo(solucion, emailArquitecto, emailAdicionales, lenguaje);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void EnviarCorreoSinScrumMasterTest()
        {
            Guid id = Guid.NewGuid();

            this.negocioUsuarios
                .Setup(it => it.ObtenerInformacionUsuario(It.IsAny<string>()))
                .Returns(
                    new Usuario
                    {
                        Mail = "prueba@company.com",
                        DisplayName = "Aureliano Buendia"
                    }
                );

            this.negocioEmail365
                .Setup(it => it.EnviarCorreo(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<MailAddress>>()));

            this.repositorioHito.Setup(
                it => it
                .Obtener(
                    It.IsAny<Guid>(), It.IsAny<string>()))
                .Returns(
                    new List<Hito>()
                    {
                        new Hito
                        {
                            Id = id,
                            Descripcion = "Lorem ipsum",
                            FechaCierre = new DateTime(2020,02,02),
                            Estado = new ItemMaestro
                            {
                                Id = 1,
                                Nombre = "Abierto"
                            },
                            Tipo = new ItemMaestro
                            {
                                Id = 1,
                                Nombre = "Definición de arquitectura"
                            }

                        }
                    }
                );


            Solucion solucion = new Solucion
            {
                Nombre = "Varo",
                UsuarioRedGerente = "prueba",
                UsuarioRedResponsable = "prueba",
                Cliente = new Cliente
                {
                    Name = "Cliente 1"
                }
            };
            string emailArquitecto = "";
            string emailAdicionales = "";
            string lenguaje = "ES";

            this.negocioHito.EnviarCorreo(solucion, emailArquitecto, emailAdicionales, lenguaje);

            Assert.IsTrue(true);
        }
    }
}

