namespace Varo.Soluciones.Test
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Constantes;
    using Varo.Transversales.Repositorio;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class MetricasAgilesTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioMetricaAgil> repositorioMetricaAgil = null;
        private Mock<IRepositorioHistoriayEsfuerzo> repositorioHistoriayEsfuerzo = null;
        private Mock<IRepositorioHistoria> repositorioHistoria = null;
        private Mock<IRepositorioDefectoInterno> repositorioDefectoInterno = null;
        private Mock<IRepositorioDefectoExterno> repositorioDefectoExterno = null;
        private Mock<IRepositorioIncendio> repositorioIncendio = null;
        private Mock<IRepositorioCalidadCodigo> repositorioCalidadCodigo = null;
        private Mock<IRepositorioAccionMejora> repositorioAccionMejora = null;
        private Mock<IRepositorioSeguimiento> repositorioSeguimiento = null;
        private INegocioMetricaAgil negocioMetricaAgil = null;
        private Mock<IRepositorioSolucion> repositorioSolucion = null;
        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioMetricaAgil = new Mock<IRepositorioMetricaAgil>();
            this.repositorioHistoriayEsfuerzo = new Mock<IRepositorioHistoriayEsfuerzo>();
            this.repositorioHistoria = new Mock<IRepositorioHistoria>();
            this.repositorioDefectoInterno = new Mock<IRepositorioDefectoInterno>();
            this.repositorioDefectoExterno = new Mock<IRepositorioDefectoExterno>();
            this.repositorioIncendio = new Mock<IRepositorioIncendio>();
            this.repositorioCalidadCodigo = new Mock<IRepositorioCalidadCodigo>();
            this.repositorioAccionMejora = new Mock<IRepositorioAccionMejora>();
            this.repositorioSeguimiento = new Mock<IRepositorioSeguimiento>();
            this.repositorioSolucion = new Mock<IRepositorioSolucion>();
            this.negocioMetricaAgil =
                new NegocioMetricaAgil(
                    this.repositorioBase.Object,
                    this.repositorioMetricaAgil.Object,
                    this.repositorioHistoriayEsfuerzo.Object,
                    this.repositorioHistoria.Object,
                    this.repositorioDefectoInterno.Object,
                    this.repositorioDefectoExterno.Object,
                    this.repositorioIncendio.Object,
                    this.repositorioCalidadCodigo.Object,
                    this.repositorioAccionMejora.Object,
                    this.repositorioSeguimiento.Object,
                    this.repositorioSolucion.Object);
        }
        [TestMethod]
        public void ConsultarTest()
        {
            IList<MetricasAgiles> metricaActual = null;
            this.repositorioMetricaAgil
                .Setup(it => it.Consultar(It.IsAny<Guid>()))
                .Returns(new List<MetricasAgiles>());
            metricaActual = this.negocioMetricaAgil.Consultar(It.IsAny<Guid>());
            Assert.IsNotNull(metricaActual);
        }

        [TestMethod]
        public void ConsultarPorParametroTest()
        {
            IList<MetricasAgiles> listaMetricasAgilesActual;
            IList<MetricasAgiles> listaMetricasAgilesEsperado = new List<MetricasAgiles>()
            {
                new MetricasAgiles
                {
                    Id = 1,
                    Sprint ="prueba 1"
                }
            };

            this.repositorioMetricaAgil.Setup(
                it => it
                .ConsultarPorParametro(It.IsAny<Guid>(), It.IsAny<string>()))
                .Returns(
                    new List<MetricasAgiles>()
                    {
                        new MetricasAgiles
                        {
                            Id = 1,
                            Sprint ="prueba 1"
                        }
                    }
                );

            listaMetricasAgilesActual = this.negocioMetricaAgil.ConsultarPorParametro(Guid.NewGuid(), "prueba");

            Assert.AreEqual(listaMetricasAgilesEsperado.Count, listaMetricasAgilesActual.Count);
            Assert.AreEqual(listaMetricasAgilesEsperado[0].Id, listaMetricasAgilesActual[0].Id);
        }

        [TestMethod]
        public void CrearMetricasAgilesconIdIgualTest()
        {
            MetricasAgiles metricasAgiles = new MetricasAgiles();
            metricasAgiles.IdSolucion = Guid.NewGuid();
            metricasAgiles.Sprint = "1";
            metricasAgiles.FechaFinal = DateTime.Now;
            metricasAgiles.FechaInicial = DateTime.Now;

            IList<MetricasAgiles> listaMetricasAgiles = new List<MetricasAgiles>()
            {
                new MetricasAgiles
                {
                    IdSolucion = Guid.NewGuid(),
                    Sprint = "1",
                    FechaFinal = DateTime.Now,
                    FechaInicial = DateTime.Now
                }
            };
            metricasAgiles.ListaMetricasAgiles = listaMetricasAgiles;
            this.repositorioMetricaAgil
                .Setup(it => it.Consultar(It.IsAny<Guid>()))
                .Returns(listaMetricasAgiles);
            this.repositorioMetricaAgil
                .Setup(it => it.Actualizar(It.IsAny<MetricasAgiles>()));


            this.repositorioMetricaAgil
                .Setup(it => it.Crear(It.IsAny<MetricasAgiles>()));
            this.negocioMetricaAgil.Crear(metricasAgiles);
        }
        [TestMethod]
        public void CrearMetricasAgilesconIdDiferenteTest()
        {
            MetricasAgiles metricasAgiles = new MetricasAgiles();
            metricasAgiles.IdSolucion = Guid.NewGuid();
            metricasAgiles.Sprint = "1";
            metricasAgiles.FechaFinal = DateTime.Now;
            metricasAgiles.FechaInicial = DateTime.Now;

            IList<MetricasAgiles> listaMetricasAgiles = new List<MetricasAgiles>()
            {
                new MetricasAgiles
                {
                    IdSolucion = Guid.NewGuid(),
                    Sprint = "1",
                    FechaFinal = DateTime.Now,
                    FechaInicial = DateTime.Now,
                    Id=2
                }
            };
            metricasAgiles.ListaMetricasAgiles = listaMetricasAgiles;
            this.repositorioMetricaAgil
                .Setup(it => it.Consultar(It.IsAny<Guid>()))
                .Returns(new List<MetricasAgiles>()
                        {
                            new MetricasAgiles
                            {
                                IdSolucion = Guid.NewGuid(),
                                Sprint = "1",
                                FechaFinal = DateTime.Now,
                                FechaInicial = DateTime.Now,
                                Id=3
                            }
                        });
            this.repositorioMetricaAgil
                .Setup(it => it.Actualizar(It.IsAny<MetricasAgiles>()));

            this.repositorioHistoriayEsfuerzo
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioHistoria
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioHistoria
               .Setup(it => it.ObtenerPorMetricaAgil(It.IsAny<int>()))
               .Returns(new List<Historias>());
            this.repositorioDefectoInterno
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioDefectoExterno
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioSolucion
                .Setup(it => it.ObtenerIdMarcoTrabajo(It.IsAny<int>()))
                .Returns(NumerosConstantes.IdScrumban);
            this.repositorioIncendio
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioCalidadCodigo
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioAccionMejora
                .Setup(it => it.ObtenerPorMetricaAgil(It.IsAny<int>()))
                .Returns(new List<AccionesMejora>()
                        {
                            new AccionesMejora
                            {
                                Accion = "accion",
                                Id = 1,
                                Estado = new Transversales.Entidades.ItemMaestro(),
                                IdMetricaAgil = 1,
                                IdSolucion = Guid.NewGuid(),
                                Sprint = "1",
                                Responsable = new Transversales.Entidades.ItemMaestro()
                            }
                        });

            this.repositorioSeguimiento
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioAccionMejora
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioMetricaAgil
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioMetricaAgil
                .Setup(it => it.Crear(It.IsAny<MetricasAgiles>()));
            this.negocioMetricaAgil.Crear(metricasAgiles);
        }

        [TestMethod]
        public void ActualizarMetricaAgilconIdDiferenteTest()
        {
            Historias historias = llenarHistoria();
            DefectosInternos defectosInternos = llenarDefectosInternos();
            DefectosExternos defectosExternos = llenarDefectosExternos();
            Incendios incendios = llenarIncendios();
            CalidadCodigo calidadCodigo = llenarCalidadCodigo();
            AccionesMejora accionesMejora = llenarAccionesMejora();

            this.repositorioHistoriayEsfuerzo
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioHistoriayEsfuerzo
                .Setup(it => it.Crear(It.IsAny<HistoriasyEsfuerzos>()));
            this.repositorioHistoria
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioHistoria
                .Setup(it => it.Crear(It.IsAny<Historias>()));
            this.repositorioDefectoInterno
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioDefectoInterno
                .Setup(it => it.Crear(It.IsAny<DefectosInternos>()));
            this.repositorioDefectoExterno
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioDefectoExterno
                .Setup(it => it.Crear(It.IsAny<DefectosExternos>()));
            this.repositorioSolucion
                .Setup(it => it.ObtenerIdMarcoTrabajo(It.IsAny<int>()))
                .Returns(1);
            this.repositorioIncendio
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioIncendio
                .Setup(it => it.Crear(It.IsAny<Incendios>()));
            this.repositorioCalidadCodigo
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioCalidadCodigo
                .Setup(it => it.Crear(It.IsAny<CalidadCodigo>()));

            this.repositorioAccionMejora
                .Setup(it => it.ObtenerPorMetricaAgil(It.IsAny<int>()))
                .Returns(new List<AccionesMejora>() {
                    new AccionesMejora
                    {
                        Accion = "accion",
                        Id = 1,
                        Estado = new Transversales.Entidades.ItemMaestro(),
                        IdMetricaAgil = 1,
                        IdSolucion = Guid.NewGuid(),
                        Sprint = "1",
                        Responsable = new Transversales.Entidades.ItemMaestro()
                    }
                });
            this.repositorioAccionMejora
                .Setup(it => it.Editar(It.IsAny<AccionesMejora>()));
            this.repositorioSeguimiento
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioAccionMejora
                .Setup(it => it.Eliminar(It.IsAny<int>()));


            this.negocioMetricaAgil.Actualizar(new HistoriasyEsfuerzos(),
                historias, defectosInternos, defectosExternos, incendios, calidadCodigo, accionesMejora
                );
        }
        [TestMethod]
        public void ActualizarMetricaAgilconIdIgualTest()
        {
            Historias historias = llenarHistoria();
            DefectosInternos defectosInternos = llenarDefectosInternos();
            DefectosExternos defectosExternos = llenarDefectosExternos();
            Incendios incendios = llenarIncendios();
            CalidadCodigo calidadCodigo = llenarCalidadCodigo();
            AccionesMejora accionesMejora = llenarAccionesMejora();

            this.repositorioHistoriayEsfuerzo
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioHistoriayEsfuerzo
                .Setup(it => it.Crear(It.IsAny<HistoriasyEsfuerzos>()));
            this.repositorioHistoria
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioHistoria
                .Setup(it => it.Crear(It.IsAny<Historias>()));
            this.repositorioDefectoInterno
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioDefectoInterno
                .Setup(it => it.Crear(It.IsAny<DefectosInternos>()));
            this.repositorioDefectoExterno
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioDefectoExterno
                .Setup(it => it.Crear(It.IsAny<DefectosExternos>()));
            this.repositorioSolucion
                .Setup(it => it.ObtenerIdMarcoTrabajo(It.IsAny<int>()))
                .Returns(1);
            this.repositorioIncendio
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioIncendio
                .Setup(it => it.Crear(It.IsAny<Incendios>()));
            this.repositorioCalidadCodigo
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioCalidadCodigo
                .Setup(it => it.Crear(It.IsAny<CalidadCodigo>()));

            this.repositorioAccionMejora
                .Setup(it => it.ObtenerPorMetricaAgil(It.IsAny<int>()))
                .Returns(new List<AccionesMejora>() {
                    new AccionesMejora
                    {
                        Accion = "accion",
                        Id = 0,
                        Estado = new Transversales.Entidades.ItemMaestro(),
                        IdMetricaAgil = 1,
                        IdSolucion = Guid.NewGuid(),
                        Sprint = "1",
                        Responsable = new Transversales.Entidades.ItemMaestro()
                    }
                });
            this.repositorioAccionMejora
                .Setup(it => it.Editar(It.IsAny<AccionesMejora>()));
            this.repositorioSeguimiento
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioAccionMejora
                .Setup(it => it.Eliminar(It.IsAny<int>()));


            this.negocioMetricaAgil.Actualizar(new HistoriasyEsfuerzos(),
                historias, defectosInternos, defectosExternos, incendios, calidadCodigo, accionesMejora
                );
        }

        [TestMethod]
        public void ActualizarMetricaScrumbanconIdDiferenteTest()
        {
            Historias historias = llenarHistoria();
            DefectosInternos defectosInternos = llenarDefectosInternos();
            DefectosExternos defectosExternos = llenarDefectosExternos();
            Incendios incendios = llenarIncendios();
            CalidadCodigo calidadCodigo = llenarCalidadCodigo();
            AccionesMejora accionesMejora = llenarAccionesMejora();

            this.repositorioHistoriayEsfuerzo
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioHistoriayEsfuerzo
                .Setup(it => it.Crear(It.IsAny<HistoriasyEsfuerzos>()));
            this.repositorioHistoria
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioHistoria
                .Setup(it => it.Crear(It.IsAny<Historias>()));
            this.repositorioDefectoInterno
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioDefectoInterno
                .Setup(it => it.Crear(It.IsAny<DefectosInternos>()));
            this.repositorioDefectoExterno
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioDefectoExterno
                .Setup(it => it.Crear(It.IsAny<DefectosExternos>()));
            this.repositorioSolucion
                .Setup(it => it.ObtenerIdMarcoTrabajo(It.IsAny<int>()))
                .Returns(NumerosConstantes.IdScrumban);
            this.repositorioIncendio
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioIncendio
                .Setup(it => it.Crear(It.IsAny<Incendios>()));
            this.repositorioCalidadCodigo
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioCalidadCodigo
                .Setup(it => it.Crear(It.IsAny<CalidadCodigo>()));

            this.repositorioAccionMejora
                .Setup(it => it.ObtenerPorMetricaAgil(It.IsAny<int>()))
                .Returns(new List<AccionesMejora>() {
                    new AccionesMejora
                    {
                        Accion = "accion",
                        Id = 1,
                        Estado = new Transversales.Entidades.ItemMaestro(),
                        IdMetricaAgil = 1,
                        IdSolucion = Guid.NewGuid(),
                        Sprint = "1",
                        Responsable = new Transversales.Entidades.ItemMaestro()
                    }
                });
            this.repositorioAccionMejora
                .Setup(it => it.Editar(It.IsAny<AccionesMejora>()));
            this.repositorioSeguimiento
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioAccionMejora
                .Setup(it => it.Eliminar(It.IsAny<int>()));


            this.negocioMetricaAgil.Actualizar(new HistoriasyEsfuerzos(),
                historias, defectosInternos, defectosExternos, incendios, calidadCodigo, accionesMejora
                );
        }
        [TestMethod]
        public void ActualizarMetricaScrumbanconIdIgualTest()
        {
            Historias historias = llenarHistoria();
            DefectosInternos defectosInternos = llenarDefectosInternos();
            DefectosExternos defectosExternos = llenarDefectosExternos();
            Incendios incendios = llenarIncendios();
            CalidadCodigo calidadCodigo = llenarCalidadCodigo();
            AccionesMejora accionesMejora = llenarAccionesMejora();

            this.repositorioHistoriayEsfuerzo
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioHistoriayEsfuerzo
                .Setup(it => it.Crear(It.IsAny<HistoriasyEsfuerzos>()));
            this.repositorioHistoria
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioHistoria
                .Setup(it => it.Crear(It.IsAny<Historias>()));
            this.repositorioDefectoInterno
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioDefectoInterno
                .Setup(it => it.Crear(It.IsAny<DefectosInternos>()));
            this.repositorioDefectoExterno
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioDefectoExterno
                .Setup(it => it.Crear(It.IsAny<DefectosExternos>()));
            this.repositorioSolucion
                .Setup(it => it.ObtenerIdMarcoTrabajo(It.IsAny<int>()))
                .Returns(NumerosConstantes.IdScrumban);
            this.repositorioIncendio
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioIncendio
                .Setup(it => it.Crear(It.IsAny<Incendios>()));
            this.repositorioCalidadCodigo
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioCalidadCodigo
                .Setup(it => it.Crear(It.IsAny<CalidadCodigo>()));

            this.repositorioAccionMejora
                .Setup(it => it.ObtenerPorMetricaAgil(It.IsAny<int>()))
                .Returns(new List<AccionesMejora>() {
                    new AccionesMejora
                    {
                        Accion = "accion",
                        Id = 0,
                        Estado = new Transversales.Entidades.ItemMaestro(),
                        IdMetricaAgil = 1,
                        IdSolucion = Guid.NewGuid(),
                        Sprint = "1",
                        Responsable = new Transversales.Entidades.ItemMaestro()
                    }
                });
            this.repositorioAccionMejora
                .Setup(it => it.Editar(It.IsAny<AccionesMejora>()));
            this.repositorioSeguimiento
                .Setup(it => it.Eliminar(It.IsAny<int>()));
            this.repositorioAccionMejora
                .Setup(it => it.Eliminar(It.IsAny<int>()));


            this.negocioMetricaAgil.Actualizar(new HistoriasyEsfuerzos(),
                historias, defectosInternos, defectosExternos, incendios, calidadCodigo, accionesMejora
                );
        }

        private Historias llenarHistoria()
        {
            return new Historias
            {
                EsfuerzoEstimado = new decimal(),
                EsfuerzoReal = new decimal(),
                Id = new int(),
                IdMetricaAgil = new int(),
                Nombre = "",
                Numero = "",
                Observaciones = ""
            };
        }
        private DefectosInternos llenarDefectosInternos()
        {
            return new DefectosInternos
            {
                Abiertos = new int(),
                Actuales = new int(),
                Cerrados = new int(),
                Id = new int(),
                IdMetricaAgil = new int(),
                Observaciones = "",
                Reportados = new int()
            };
        }
        private DefectosExternos llenarDefectosExternos()
        {
            return new DefectosExternos
            {
                Reportados = new int(),
                Observaciones = "",
                IdMetricaAgil = new int(),
                Id = new int(),
                Cerrados = new int(),
                Actuales = new int(),
                Abiertos = new int(),
                Densidad = new decimal()
            };
        }
        private Incendios llenarIncendios()
        {
            return new Incendios
            {
                Reportados = new int(),
                Observaciones = "",
                IdMetricaAgil = new int(),
                Id = new int(),
                Solucionados = new int(),
            };
        }
        private CalidadCodigo llenarCalidadCodigo()
        {
            return new CalidadCodigo
            {
                Bugs = new int(),
                Id = new int(),
                Cobertura = new decimal(),
                DeudaTecnica = new decimal(),
                Duplicado = new decimal(),
                IdMetricaAgil = new int(),
                Observaciones = "",
                Vulnerabilidades = new int()
            };
        }
        private AccionesMejora llenarAccionesMejora()
        {
            AccionesMejora accionesMejora = new AccionesMejora();
            accionesMejora.ListaAccionesMejora = new List<AccionesMejora>()
            {
                new AccionesMejora
                {
                    Accion = "accion",
                    Id = 0,
                    Estado = new Transversales.Entidades.ItemMaestro(),
                    IdMetricaAgil = 1,
                    IdSolucion = Guid.NewGuid(),
                    Sprint = "1",
                    Responsable = new Transversales.Entidades.ItemMaestro()
                }
            };
            return accionesMejora;
        }

        private Solucion llenarSoluciones()
        {
            return new Solucion
            {
                Id = Guid.NewGuid(),
                MarcoTrabajo = new Transversales.Entidades.ItemMaestro(),
            };
        }
    }
}

