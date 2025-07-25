namespace Varo.Soluciones.Test
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Repositorio;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;

    [TestClass]
    public class PracticasCalidadTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioPracticaCalidad> repositorioPracticaCalidad = null;
        private INegocioPracticaCalidad negocioPrcaticaCalidad = null;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioPracticaCalidad = new Mock<IRepositorioPracticaCalidad>();


            this.negocioPrcaticaCalidad =
                new NegocioPracticaCalidad(
                    this.repositorioBase.Object,
                    this.repositorioPracticaCalidad.Object);
        }

        [TestMethod]
        public void ConsultarPracticasCalidadPorIdSolucionTest()
        {
            Guid idSolucion = Guid.NewGuid();
            PracticasCalidad practicasActual;
            PracticasCalidad practicasEsperado = new PracticasCalidad
            {
                id = idSolucion
            };

            this.repositorioPracticaCalidad.Setup(
                it => it
                .ConsultarPorIdSolucion(It.IsAny<Guid>()))
                .Returns(
                    new PracticasCalidad
                    {
                        id = idSolucion
                    }
                );

            practicasActual = this.negocioPrcaticaCalidad.ConsultarPorIdSolucion(It.IsAny<Guid>());

            Assert.AreEqual(practicasEsperado.id, practicasActual.id);
        }

        [TestMethod]
        public void ConsultarPracticasCalidadPorIdSolucionSinResultadoTest()
        {
            PracticasCalidad practicasActual;
            PracticasCalidad practicasEsperado = new PracticasCalidad();

            this.repositorioPracticaCalidad.Setup(
                it => it
                .ConsultarPorIdSolucion(It.IsAny<Guid>()))
                .Returns(
                    new PracticasCalidad()
                );

            practicasActual = this.negocioPrcaticaCalidad.ConsultarPorIdSolucion(It.IsAny<Guid>());

            Assert.AreEqual(practicasEsperado.id, practicasActual.id);
        }

        [TestMethod]
        public void ObtenerImagenNivelMadurezDevuelveGateando()
        {
            string nombreImagen;

            //Arrange

            //Por defecto no se aplica ninguna practica por lo tanto se cumplen todas.
            PracticasCalidad practicasCalidad = new PracticasCalidad();

            //Indicamos que practicas se cumplen y cuales no se cumplen.
            practicasCalidad.controlDocumentacion = false;
            practicasCalidad.controlCodigo = false;
            practicasCalidad.gestionTareas = false;
            practicasCalidad.gestionErrores = false;
            practicasCalidad.integracionContinua = false;
            practicasCalidad.inspeccionContinua = false;
            practicasCalidad.pruebasUnitariasAutomatizadas = false;
            practicasCalidad.pruebasFuncionalesAutomatizadas = false;
            practicasCalidad.despliegueContinuo = false;
            practicasCalidad.monitoreoContinuo = false;
            practicasCalidad.seguridadContinua = false;
            practicasCalidad.rendimientoContinuo = false;
            practicasCalidad.infraestructuraComoCodigo = false;

            this.negocioPrcaticaCalidad.EstablecerPracticas(practicasCalidad);

            //Act
            nombreImagen = negocioPrcaticaCalidad.ObtenerImagenNivelMadurez();

            //Assert
            Assert.AreEqual(nombreImagen, "gateando.png");
        }

        [TestMethod]
        public void ObtenerImagenNivelMadurezDevuelveCaminando()
        {
            string nombreImagen;

            //Arrange

            //Por defecto no se aplica ninguna practica por lo tanto se cumplen todas.
            PracticasCalidad practicasCalidad = new PracticasCalidad();

            //Indicamos que practicas se cumplen y cuales no se cumplen.
            practicasCalidad.controlDocumentacion = true;
            practicasCalidad.controlCodigo = true;
            practicasCalidad.gestionTareas = true;
            practicasCalidad.gestionErrores = true;
            practicasCalidad.integracionContinua = false;
            practicasCalidad.inspeccionContinua = false;
            practicasCalidad.pruebasUnitariasAutomatizadas = false;
            practicasCalidad.pruebasFuncionalesAutomatizadas = false;
            practicasCalidad.despliegueContinuo = false;
            practicasCalidad.monitoreoContinuo = false;
            practicasCalidad.seguridadContinua = false;
            practicasCalidad.rendimientoContinuo = false;
            practicasCalidad.infraestructuraComoCodigo = false;

            this.negocioPrcaticaCalidad.EstablecerPracticas(practicasCalidad);

            //Act
            nombreImagen = negocioPrcaticaCalidad.ObtenerImagenNivelMadurez();

            //Assert
            Assert.AreEqual(nombreImagen, "caminando.png");
        }

        [TestMethod]
        public void ObtenerImagenNivelMadurezDevuelveBicicleta()
        {
            string nombreImagen;

            //Arrange

            //Por defecto no se aplica ninguna practica por lo tanto se cumplen todas.
            PracticasCalidad practicasCalidad = new PracticasCalidad();

            //Indicamos que practicas se cumplen y cuales no se cumplen.
            practicasCalidad.controlDocumentacion = true;
            practicasCalidad.controlCodigo = true;
            practicasCalidad.gestionTareas = true;
            practicasCalidad.gestionErrores = true;
            practicasCalidad.integracionContinua = true;
            practicasCalidad.inspeccionContinua = true;
            practicasCalidad.pruebasUnitariasAutomatizadas = false;
            practicasCalidad.pruebasFuncionalesAutomatizadas = false;
            practicasCalidad.despliegueContinuo = false;
            practicasCalidad.monitoreoContinuo = false;
            practicasCalidad.seguridadContinua = false;
            practicasCalidad.rendimientoContinuo = false;
            practicasCalidad.infraestructuraComoCodigo = false;

            this.negocioPrcaticaCalidad.EstablecerPracticas(practicasCalidad);

            //Act
            nombreImagen = negocioPrcaticaCalidad.ObtenerImagenNivelMadurez();

            //Assert
            Assert.AreEqual(nombreImagen, "bicicleta.png");
        }

        [TestMethod]
        public void ObtenerImagenNivelMadurezDevuelveCarro()
        {
            string nombreImagen;

            //Arrange

            //Por defecto no se aplica ninguna practica por lo tanto se cumplen todas.
            PracticasCalidad practicasCalidad = new PracticasCalidad();

            //Indicamos que practicas se cumplen y cuales no se cumplen.
            practicasCalidad.controlDocumentacion = true;
            practicasCalidad.controlCodigo = true;
            practicasCalidad.gestionTareas = true;
            practicasCalidad.gestionErrores = true;
            practicasCalidad.integracionContinua = true;
            practicasCalidad.inspeccionContinua = true;
            practicasCalidad.pruebasUnitariasAutomatizadas = true;
            practicasCalidad.pruebasFuncionalesAutomatizadas = true;
            practicasCalidad.despliegueContinuo = false;
            practicasCalidad.monitoreoContinuo = false;
            practicasCalidad.seguridadContinua = false;
            practicasCalidad.rendimientoContinuo = false;
            practicasCalidad.infraestructuraComoCodigo = false;

            this.negocioPrcaticaCalidad.EstablecerPracticas(practicasCalidad);

            //Act
            nombreImagen = negocioPrcaticaCalidad.ObtenerImagenNivelMadurez();

            //Assert
            Assert.AreEqual(nombreImagen, "carro.png");
        }

        [TestMethod]
        public void ObtenerImagenNivelMadurezDevuelveAvion()
        {
            string nombreImagen;

            //Arrange

            //Por defecto no se aplica ninguna practica por lo tanto se cumplen todas.
            PracticasCalidad practicasCalidad = new PracticasCalidad();

            //Indicamos que practicas se cumplen y cuales no se cumplen.
            practicasCalidad.controlDocumentacion = true;
            practicasCalidad.controlCodigo = true;
            practicasCalidad.gestionTareas = true;
            practicasCalidad.gestionErrores = true;
            practicasCalidad.integracionContinua = true;
            practicasCalidad.inspeccionContinua = true;
            practicasCalidad.pruebasUnitariasAutomatizadas = true;
            practicasCalidad.pruebasFuncionalesAutomatizadas = true;
            practicasCalidad.despliegueContinuo = true;
            practicasCalidad.monitoreoContinuo = true;
            practicasCalidad.seguridadContinua = false;
            practicasCalidad.rendimientoContinuo = false;
            practicasCalidad.infraestructuraComoCodigo = false;

            this.negocioPrcaticaCalidad.EstablecerPracticas(practicasCalidad);

            //Act
            nombreImagen = negocioPrcaticaCalidad.ObtenerImagenNivelMadurez();

            //Assert
            Assert.AreEqual(nombreImagen, "avion.png");
        }

        [TestMethod]
        public void ObtenerImagenNivelMadurezDevuelveCohete()
        {
            string nombreImagen;

            //Arrange

            //Por defecto no se aplica ninguna practica por lo tanto se cumplen todas.
            PracticasCalidad practicasCalidad = new PracticasCalidad();

            //Indicamos que practicas se cumplen y cuales no se cumplen.
            practicasCalidad.controlDocumentacion = true;
            practicasCalidad.controlCodigo = true;
            practicasCalidad.gestionTareas = true;
            practicasCalidad.gestionErrores = true;
            practicasCalidad.integracionContinua = true;
            practicasCalidad.inspeccionContinua = true;
            practicasCalidad.pruebasUnitariasAutomatizadas = true;
            practicasCalidad.pruebasFuncionalesAutomatizadas = true;
            practicasCalidad.despliegueContinuo = true;
            practicasCalidad.monitoreoContinuo = true;
            practicasCalidad.seguridadContinua = true;
            practicasCalidad.rendimientoContinuo = true;
            practicasCalidad.infraestructuraComoCodigo = true;

            this.negocioPrcaticaCalidad.EstablecerPracticas(practicasCalidad);

            //Act
            nombreImagen = negocioPrcaticaCalidad.ObtenerImagenNivelMadurez();

            //Assert
            Assert.AreEqual(nombreImagen, "cohete.png");
        }
    }
}

