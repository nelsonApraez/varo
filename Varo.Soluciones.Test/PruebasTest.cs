namespace Varo.Soluciones.Test
{
    using Varo.Maestros.Entidades;
    using Varo.Maestros.Negocio;
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Repositorio;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class PruebasTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioPrueba> repositorioPrueba = null;
        private Mock<INegocioUsuarios> negocioUsuario = null;
        private INegocioPrueba negocioPrueba = null;
        private Guid idPrueba;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioPrueba = new Mock<IRepositorioPrueba>();
            this.negocioUsuario = new Mock<INegocioUsuarios>();
            this.idPrueba = Guid.NewGuid();

            this.negocioPrueba =
                new NegocioPrueba(
                    this.repositorioBase.Object,
                    this.repositorioPrueba.Object,
                    this.negocioUsuario.Object);

        }

        private IList<Prueba> InicializarListaPrueba()
        {
            IList<Prueba> pruebaEsperada;

            pruebaEsperada = new List<Prueba>
            {
                new Prueba
                {
                    Id = this.idPrueba,
                    CasosDefinidos = 100,
                    CasosAutomatizar = 80,
                    CasosAutomatizados = 80,
                    UsuarioRedTecnico = "UIguaran"
                }
            };

            return pruebaEsperada;
        }

        private Prueba InicializarPrueba()
        {
            Prueba pruebaEsperada;

            pruebaEsperada = new Prueba
            {
                Id = this.idPrueba,
                CasosDefinidos = 100,
                CasosAutomatizar = 80,
                CasosAutomatizados = 80,
                UsuarioRedTecnico = "UIguaran",
                UrlDiseñoCasos = "https://www.prueba.com",
                UrlEvidencias = "https://www.prueba.com",
                UrlRepositorio = "https://www.prueba.com"
            };

            return pruebaEsperada;
        }

        private void InicializarRepositorioPruebas()
        {
            this.repositorioPrueba
                .Setup(
                    it => it.Consultar())
                .Returns(
                    new List<Prueba> {
                            new Prueba
                            {
                                Id = this.idPrueba,
                                CasosDefinidos = 100,
                                CasosAutomatizar = 80,
                                CasosAutomatizados = 80,
                                UsuarioRedTecnico = "UIguaran", UrlDiseñoCasos = "https://www.prueba.com",UrlEvidencias="https://www.prueba.com",UrlRepositorio="https://www.prueba.com"
                            }
                    }
                );

            this.repositorioPrueba
                .Setup(
                    it => it.ConsultarPorIdSolucion(It.IsAny<Guid>()))
                .Returns(
                    new Prueba
                    {
                        Id = this.idPrueba,
                        CasosDefinidos = 100,
                        CasosAutomatizar = 80,
                        CasosAutomatizados = 80,
                        UsuarioRedTecnico = "UIguaran",
                        UrlDiseñoCasos = "https://www.prueba.com",
                        UrlEvidencias = "https://www.prueba.com",
                        UrlRepositorio = "https://www.prueba.com"
                    }
                );

            this.repositorioPrueba
                .Setup(
                    it => it.Crear(It.IsAny<Prueba>()));

            this.repositorioPrueba
                .Setup(
                    it => it.Editar(It.IsAny<Prueba>()));

            this.repositorioPrueba
                .Setup(
                    it => it.Eliminar(It.IsAny<Guid>()));

            this.repositorioPrueba
                .Setup(
                    it => it.Obtener(It.IsAny<Guid>()))
                .Returns(
                    new Prueba
                    {
                        Id = this.idPrueba,
                        CasosDefinidos = 100,
                        CasosAutomatizar = 80,
                        CasosAutomatizados = 80,
                        UsuarioRedTecnico = "UIguaran",
                        UrlDiseñoCasos = "https://www.prueba.com",
                        UrlEvidencias = "https://www.prueba.com",
                        UrlRepositorio = "https://www.prueba.com"
                    }
                );
        }

        private void InicializarAdapatadorClientes()
        {
            this.negocioUsuario
                .Setup(
                    it => it.ObtenerInformacionUsuario(
                        It.IsAny<string>()))
                .Returns(
                    new Usuario
                    {
                        DisplayName = "Ursula Iguaran"
                    }
                );
        }

        [TestMethod]
        public void ConsultarPruebasTest()
        {
            IList<Prueba> pruebasEsperada = this.InicializarListaPrueba();
            IList<Prueba> pruebasActual;

            this.InicializarRepositorioPruebas();
            this.InicializarAdapatadorClientes();

            pruebasActual = this.negocioPrueba.Consultar();

            Assert.AreEqual(pruebasEsperada.Count, pruebasActual.Count);
        }

        [TestMethod]
        public void ConsultarPruebasCasosPendientesTest()
        {
            int casosPendientesEsperado = 20;
            int casosPendientesActual;
            IList<Prueba> pruebas;

            this.InicializarRepositorioPruebas();
            this.InicializarAdapatadorClientes();

            pruebas = this.negocioPrueba.Consultar();
            casosPendientesActual = pruebas[0].CasosPendientes;

            Assert.AreEqual(casosPendientesEsperado, casosPendientesActual);
        }

        [TestMethod]
        public void ConsultarPruebasNombreTecnicoTest()
        {
            string nombreTecnicoEsperado = "Ursula Iguaran";
            string nombreTecnicoActual;
            IList<Prueba> pruebas;

            this.InicializarRepositorioPruebas();
            this.InicializarAdapatadorClientes();

            pruebas = this.negocioPrueba.Consultar();
            nombreTecnicoActual = pruebas[0].NombreTecnico;

            Assert.AreEqual(nombreTecnicoEsperado, nombreTecnicoActual);
        }

        [TestMethod]
        public void ConsultarPruebasUsuarioRedNuloTest()
        {
            string nombreTecnicoEsperado = null;
            string nombreTecnicoActual;
            IList<Prueba> pruebas;

            this.repositorioPrueba
                .Setup(
                    it => it.Consultar())
                .Returns(
                    new List<Prueba> {
                            new Prueba
                            {
                                Id = this.idPrueba,
                                CasosDefinidos = 100,
                                CasosAutomatizar = 80,
                                CasosAutomatizados = 80,
                                UsuarioRedTecnico = null, UrlDiseñoCasos = "https://www.prueba.com",UrlEvidencias="https://www.prueba.com",UrlRepositorio="https://www.prueba.com"
                            }
                    }
                );

            this.InicializarAdapatadorClientes();

            pruebas = this.negocioPrueba.Consultar();
            nombreTecnicoActual = pruebas[0].NombreTecnico;

            Assert.AreEqual(nombreTecnicoEsperado, nombreTecnicoActual);
        }

        [TestMethod]
        public void ConsultarPruebasPorIdSolucionTest()
        {
            Prueba pruebasEsperada = this.InicializarPrueba();
            Prueba pruebasActual;

            this.InicializarRepositorioPruebas();
            this.InicializarAdapatadorClientes();

            pruebasActual = this.negocioPrueba.ConsultarPorIdSolucion(Guid.NewGuid());

            Assert.AreEqual(pruebasEsperada.Id, pruebasActual.Id);
        }

        [TestMethod]
        public void ConsultarPruebasPorIdSolucionCasosPendientesTest()
        {
            int casosPendientesEsperado = 20;
            int casosPendientesActual;
            Prueba pruebas;

            this.InicializarRepositorioPruebas();
            this.InicializarAdapatadorClientes();

            pruebas = this.negocioPrueba.ConsultarPorIdSolucion(Guid.NewGuid());
            casosPendientesActual = pruebas.CasosPendientes;

            Assert.AreEqual(casosPendientesEsperado, casosPendientesActual);
        }

        [TestMethod]
        public void ConsultarPruebasPorIdSolucionNombreTecnicoTest()
        {
            string nombreTecnicoEsperado = "Ursula Iguaran";
            string nombreTecnicoActual;
            Prueba pruebas;

            this.InicializarRepositorioPruebas();
            this.InicializarAdapatadorClientes();

            pruebas = this.negocioPrueba.ConsultarPorIdSolucion(Guid.NewGuid());
            nombreTecnicoActual = pruebas.NombreTecnico;

            Assert.AreEqual(nombreTecnicoEsperado, nombreTecnicoActual);
        }

        [TestMethod]
        public void ConsultarPruebasPorIdSolucionUsuarioRedNuloTest()
        {
            string nombreTecnicoEsperado = null;
            string nombreTecnicoActual;
            Prueba pruebas;

            this.repositorioPrueba
               .Setup(
                   it => it.ConsultarPorIdSolucion(It.IsAny<Guid>()))
               .Returns(
                   new Prueba
                   {
                       Id = this.idPrueba,
                       CasosDefinidos = 100,
                       CasosAutomatizar = 80,
                       CasosAutomatizados = 80,
                       UsuarioRedTecnico = null,
                       UrlDiseñoCasos = "https://www.prueba.com",
                       UrlEvidencias = "https://www.prueba.com",
                       UrlRepositorio = "https://www.prueba.com"
                   }
               );

            this.InicializarAdapatadorClientes();

            pruebas = this.negocioPrueba.ConsultarPorIdSolucion(Guid.NewGuid());
            nombreTecnicoActual = pruebas.NombreTecnico;

            Assert.AreEqual(nombreTecnicoEsperado, nombreTecnicoActual);
        }

        [TestMethod]
        public void CrearPruebaTest()
        {
            this.InicializarRepositorioPruebas();

            this.negocioPrueba.Crear(new Prueba());

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void EditarPruebaTest()
        {
            this.InicializarRepositorioPruebas();

            this.negocioPrueba.Editar(new Prueba { Id = Guid.NewGuid() });

            Assert.IsTrue(true);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EditarPruebaIdVacioTest()
        {
            this.InicializarRepositorioPruebas();

            this.negocioPrueba.Editar(new Prueba());
        }

        [TestMethod]
        public void EliminarPruebaTest()
        {
            this.InicializarRepositorioPruebas();

            this.negocioPrueba.Eliminar(Guid.NewGuid());

            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EliminarPruebaIdVacioTest()
        {
            this.InicializarRepositorioPruebas();

            this.negocioPrueba.Eliminar(new Guid());
        }

        [TestMethod]
        public void ObtenerPruebaTest()
        {
            Prueba pruebaEsperada = this.InicializarPrueba();
            Prueba pruebaActual;

            this.InicializarRepositorioPruebas();
            this.InicializarAdapatadorClientes();

            pruebaActual = this.negocioPrueba.Obtener(Guid.NewGuid());

            Assert.AreEqual(pruebaEsperada.Id, pruebaActual.Id);
        }

        [TestMethod]
        public void ObtenerPruebaCasosPendientesTest()
        {
            int casosPendientesEsperado = 20;
            int casosPendientesActual;
            Prueba prueba;

            this.InicializarRepositorioPruebas();
            this.InicializarAdapatadorClientes();

            prueba = this.negocioPrueba.Obtener(Guid.NewGuid());
            casosPendientesActual = prueba.CasosPendientes;

            Assert.AreEqual(casosPendientesEsperado, casosPendientesActual);
        }

        [TestMethod]
        public void ObtenerPruebaNombreTecnicoTest()
        {
            string nombreTecnicoEsperado = "Ursula Iguaran";
            string nombreTecnicoActual;
            Prueba prueba;

            this.InicializarRepositorioPruebas();
            this.InicializarAdapatadorClientes();

            prueba = this.negocioPrueba.Obtener(Guid.NewGuid());
            nombreTecnicoActual = prueba.NombreTecnico;

            Assert.AreEqual(nombreTecnicoEsperado, nombreTecnicoActual);
        }

        [TestMethod]
        public void ObtenerPruebaUsuarioRedNuloTest()
        {
            string nombreTecnicoEsperado = null;
            string nombreTecnicoActual;
            Prueba prueba;

            this.repositorioPrueba
               .Setup(
                   it => it.Obtener(It.IsAny<Guid>()))
               .Returns(
                   new Prueba
                   {
                       Id = this.idPrueba,
                       CasosDefinidos = 100,
                       CasosAutomatizar = 80,
                       CasosAutomatizados = 80,
                       UsuarioRedTecnico = null,
                       UrlDiseñoCasos = "https://www.prueba.com",
                       UrlEvidencias = "https://www.prueba.com",
                       UrlRepositorio = "https://www.prueba.com"
                   }
               );

            this.InicializarAdapatadorClientes();

            prueba = this.negocioPrueba.Obtener(Guid.NewGuid());
            nombreTecnicoActual = prueba.NombreTecnico;

            Assert.AreEqual(nombreTecnicoEsperado, nombreTecnicoActual);
        }
    }
}

