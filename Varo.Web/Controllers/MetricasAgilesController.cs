namespace Varo.Web.Controllers
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Transversales.Constantes;
    using Varo.Transversales.Entidades;
    using Varo.Transversales.Excepciones;
    using Varo.Web.Helpers;
    using Varo.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;

    public class MetricasAgilesController : BaseController
    {
        private readonly INegocioSoluciones negocioSoluciones;
        private readonly INegocioMetricaAgil negocioMetricaAgil;
        private readonly INegocioHistoriayEsfuerzo negocioHistoriayEsfuerzo;
        private readonly INegocioDefectoInterno negocioDefectoInterno;
        private readonly INegocioDefectoExterno negocioDefectoExterno;
        private readonly INegocioIncendio negocioIncendio;
        private readonly INegocioCalidadCodigo negocioCalidadCodigo;
        private readonly INegocioHistoria negocioHistoria;
        private readonly INegocioAccionMejora negocioAccionMejora;
        private readonly INegocioEquipoSolucion negocioEquipoSolucion;
        public bool ExistenCamposVaciosFormulario { get; private set; }


        public MetricasAgilesController()
        {
            this.negocioMetricaAgil = new NegocioMetricaAgil();
            this.negocioHistoriayEsfuerzo = new NegocioHistoriayEsfuerzo();
            this.negocioHistoria = new NegocioHistoria();
            this.negocioDefectoInterno = new NegocioDefectoInterno();
            this.negocioDefectoExterno = new NegocioDefectoExterno();
            this.negocioIncendio = new NegocioIncendio();
            this.negocioCalidadCodigo = new NegocioCalidadCodigo();
            this.negocioAccionMejora = new NegocioAccionMejora();
            this.negocioSoluciones = new NegocioSoluciones();
            this.negocioEquipoSolucion = new NegocioEquipoSolucion();
        }

        [HttpGet]
        public ActionResult Consultar(Guid idSolucion, string terminoBusqueda, string filtroActual)
        {
            MetricasAgilesViewModel metricasAgilesViewModel = new MetricasAgilesViewModel();

            try
            {
                metricasAgilesViewModel.metricasAgiles.ListaMetricasAgiles = this.VerificarBusquedaYPaginadorMetricasAgiles(idSolucion, terminoBusqueda, filtroActual).ToList();
                metricasAgilesViewModel.ListaEquipos = ConvertirListaEquiposEnSelectListItem(
                    this.negocioEquipoSolucion.Consultar(idSolucion));
                metricasAgilesViewModel.IdSolucion = idSolucion;
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_MetricasAgiles", metricasAgilesViewModel);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(metricasAgilesViewModel);
        }
        public ActionResult Obtener(Guid idSolucion, string sprint, int idMetricaAgil)
        {
            MetricasViewModel metricasViewModel = new MetricasViewModel();
            try
            {
                metricasViewModel.historiasyEsfuerzosViewModel = ObtenerHistoriasyEsfuerzos(idSolucion, idMetricaAgil);
                metricasViewModel.historiasViewModel = ObtenerHistorias(idMetricaAgil);
                metricasViewModel.defectosInternosViewModel = ObtenerDefectosInternos(idMetricaAgil);
                metricasViewModel.defectosExternosViewModel = ObtenerDefectosExternos(idMetricaAgil);
                metricasViewModel.incendiosViewModel = ObtenerIncendios(idMetricaAgil);
                metricasViewModel.calidadCodigoViewModel = ObtenerCalidadCodigo(idMetricaAgil);
                metricasViewModel.accionesMejoraViewModel = ObtenerAccionesMejora(idMetricaAgil);
                metricasViewModel.mostrarIncendios = negocioSoluciones.EsSolucionScrumban(idSolucion);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            metricasViewModel.sprint = sprint;
            ViewBag.sprint = sprint;
            return View(metricasViewModel);
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Crear(MetricasAgilesViewModel metricasAgilesViewModel, FormCollection form)
        {
            List<MetricasAgiles> listaMetricas = new List<MetricasAgiles>();
            try
            {
                MetricasAgiles metricasAgiles = new MetricasAgiles();

                var ArrayId = Request.Form.GetValues("itemId");
                var ArrayEquipos = Request.Form.GetValues("itemIdEquipo");
                var ArraySprint = Request.Form.GetValues("itemSprint");
                var ArrayFechaInicial = Request.Form.GetValues("itemFechaInicial");
                var ArrayFechaFinal = Request.Form.GetValues("itemFechaFinal");

                for (int i = 0; i < ArraySprint.Length; i++)
                {
                    MetricasAgiles itemMetricaAgil = new MetricasAgiles();
                    if (ArrayId != null && ArrayId.Count() >= i + 1)
                    {
                        itemMetricaAgil.Id = int.Parse(ArrayId[i].ToString(
                            CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
                    }

                    if (ArrayEquipos != null && ArrayEquipos.Count() >= i + 1)
                    {
                        if (ArrayEquipos[i] != Guid.Empty.ToString() &&
                            ArrayEquipos[i] != string.Empty)
                        {
                            itemMetricaAgil.IdEquipo = new Guid(ArrayEquipos[i]);
                        }
                    }

                    itemMetricaAgil.IdSolucion = metricasAgilesViewModel.IdSolucion;
                    itemMetricaAgil.Sprint = ArraySprint[i].ToString(CultureInfo.CurrentCulture);
                    itemMetricaAgil.FechaInicial = ArrayFechaInicial[i] != "" ?
                        itemMetricaAgil.FechaInicial = DateTime.Parse(ArrayFechaInicial[i].ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture) :
                        DateTime.Now;
                    itemMetricaAgil.FechaFinal = ArrayFechaFinal[i] != "" ?
                        itemMetricaAgil.FechaFinal = DateTime.Parse(ArrayFechaFinal[i].ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture) :
                        DateTime.Now;

                    listaMetricas.Add(itemMetricaAgil);

                }

                metricasAgiles.IdSolucion = metricasAgilesViewModel.IdSolucion;
                metricasAgiles.ListaMetricasAgiles = listaMetricas;

                if (!ModelState.IsValid)
                {
                    metricasAgilesViewModel.metricasAgiles = new MetricasAgiles();
                    metricasAgilesViewModel.metricasAgiles.ListaMetricasAgiles = listaMetricas;
                    return View("~/Views/MetricasAgiles/Consultar.cshtml", metricasAgilesViewModel);
                }
                this.negocioMetricaAgil.Crear(metricasAgiles);
                TempData["MensajeCrearModulos"] = Recursos.Lenguaje.MensajeRegistroModificado;
                return RedirectToAction("Consultar", new { idSolucion = metricasAgilesViewModel.IdSolucion });
            }
            catch (Exception excepcion)
            {
                metricasAgilesViewModel.metricasAgiles = new MetricasAgiles();
                metricasAgilesViewModel.metricasAgiles.ListaMetricasAgiles = listaMetricas;

                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Consultar", new { idSolucion = metricasAgilesViewModel.IdSolucion });
            }
        }
        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Actualizar(MetricasViewModel metricasViewModel, FormCollection form)
        {
            try
            {
                HistoriasyEsfuerzos historiasyEsfuerzos;
                Historias historias;
                DefectosInternos defectosInternos;
                DefectosExternos defectosExternos;
                Incendios incendios;
                CalidadCodigo calidadCodigo;
                AccionesMejora accionesMejora;
                historiasyEsfuerzos = EstablecerHistoriasyEsfuerzo(metricasViewModel);
                historias = EstablecerHistorias(metricasViewModel);
                defectosInternos = EstablecerDefectosInternos(metricasViewModel);
                defectosExternos = EstablecerDefectosExternos(metricasViewModel);
                incendios = EstablecerIncendios(metricasViewModel);
                calidadCodigo = EstablecerCalidadCodigo(metricasViewModel);
                accionesMejora = EstablecerAccionesMejora(metricasViewModel);

                this.negocioMetricaAgil.Actualizar(historiasyEsfuerzos, historias, defectosInternos, defectosExternos, incendios, calidadCodigo, accionesMejora);
                TempData["MensajeCrearModulos"] = Recursos.Lenguaje.MensajeRegistroModificado;
                return RedirectToAction("Consultar", "MetricasAgiles", new { idSolucion = metricasViewModel.historiasyEsfuerzosViewModel.IdSolucion });
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Consultar", "MetricasAgiles", new { idSolucion = metricasViewModel.historiasyEsfuerzosViewModel.IdSolucion });
            }
        }

        private HistoriasyEsfuerzosViewModel ObtenerHistoriasyEsfuerzos(Guid idSolucion, int idMetricaAgil)
        {
            HistoriasyEsfuerzosViewModel historiasyEsfuerzosViewModel = new HistoriasyEsfuerzosViewModel();
            HistoriasyEsfuerzos historiasyEsfuerzos = this.negocioHistoriayEsfuerzo.ObtenerPorMetricaAgil(idMetricaAgil);
            historiasyEsfuerzosViewModel.Id = historiasyEsfuerzos.Id;
            historiasyEsfuerzosViewModel.EsfuerzoEstimado = historiasyEsfuerzos.EsfuerzoEstimado.ToString();
            historiasyEsfuerzosViewModel.EsfuerzoLogrado = historiasyEsfuerzos.EsfuerzoLogrado.ToString();
            historiasyEsfuerzosViewModel.HistoriasEstimadas = historiasyEsfuerzos.HistoriasEstimadas;
            historiasyEsfuerzosViewModel.HistoriasLogradas = historiasyEsfuerzos.HistoriasLogradas;
            historiasyEsfuerzosViewModel.Observaciones = historiasyEsfuerzos.Observaciones;
            historiasyEsfuerzosViewModel.IdMetricaAgil = idMetricaAgil;
            historiasyEsfuerzosViewModel.IdSolucion = idSolucion;
            return historiasyEsfuerzosViewModel;
        }
        private HistoriasViewModel ObtenerHistorias(int idMetricaAgil)
        {
            HistoriasViewModel historiasViewModel = new HistoriasViewModel();
            Historias historias = new Historias
            {
                ListaHistorias = negocioHistoria.ObtenerPorMetricaAgil(idMetricaAgil)
            };
            historiasViewModel.historias = historias;
            return historiasViewModel;
        }
        private DefectosInternosViewModel ObtenerDefectosInternos(int idMetricaAgil)
        {
            DefectosInternosViewModel defectosInternosViewModel = new DefectosInternosViewModel();
            DefectosInternos defectosInternos = this.negocioDefectoInterno.ObtenerPorMetricaAgil(idMetricaAgil);
            defectosInternosViewModel.ReportadosDefectos = defectosInternos.Reportados;
            defectosInternosViewModel.CerradosDefectos = defectosInternos.Cerrados;
            defectosInternosViewModel.ActualesDefectos = defectosInternos.Actuales;
            defectosInternosViewModel.AbiertosDefectos = defectosInternos.Abiertos;
            defectosInternosViewModel.ObservacionesDefectos = defectosInternos.Observaciones;
            return defectosInternosViewModel;
        }
        private DefectosExternosViewModel ObtenerDefectosExternos(int idMetricaAgil)
        {
            DefectosExternosViewModel defectosExternosViewModel = new DefectosExternosViewModel();
            DefectosExternos defectosExternos = this.negocioDefectoExterno.ObtenerPorMetricaAgil(idMetricaAgil);
            defectosExternosViewModel.ReportadosDefectos = defectosExternos.Reportados;
            defectosExternosViewModel.CerradosDefectos = defectosExternos.Cerrados;
            defectosExternosViewModel.ActualesDefectos = defectosExternos.Actuales;
            defectosExternosViewModel.AbiertosDefectos = defectosExternos.Abiertos;
            defectosExternosViewModel.DensidadDefectosExternos = defectosExternos.Densidad.ToString(CultureInfo.CurrentCulture);
            defectosExternosViewModel.ObservacionesDefectos = defectosExternos.Observaciones;
            return defectosExternosViewModel;
        }
        private IncendiosViewModel ObtenerIncendios(int idMetricaAgil)
        {
            IncendiosViewModel incendiosViewModel = new IncendiosViewModel();
            Incendios incendios = this.negocioIncendio.ObtenerPorMetricaAgil(idMetricaAgil);
            incendiosViewModel.ReportadosIncendios = incendios.Reportados;
            incendiosViewModel.SolucionadosIncendios = incendios.Solucionados;
            incendiosViewModel.ObservacionesIncendios = incendios.Observaciones;
            return incendiosViewModel;
        }
        private CalidadCodigoViewModel ObtenerCalidadCodigo(int idMetricaAgil)
        {
            CalidadCodigoViewModel calidadCodigoViewModel = new CalidadCodigoViewModel();
            CalidadCodigo CalidadCodigo = this.negocioCalidadCodigo.ObtenerPorMetricaAgil(idMetricaAgil);
            calidadCodigoViewModel.Bugs = CalidadCodigo.Bugs;
            calidadCodigoViewModel.Vulnerabilidades = CalidadCodigo.Vulnerabilidades;
            calidadCodigoViewModel.DeudaTecnica = CalidadCodigo.DeudaTecnica.ToString();
            calidadCodigoViewModel.Cobertura = CalidadCodigo.Cobertura.ToString();
            calidadCodigoViewModel.Duplicado = CalidadCodigo.Duplicado.ToString();
            calidadCodigoViewModel.ObservacionesdeCalidadCodigo = CalidadCodigo.Observaciones;
            return calidadCodigoViewModel;
        }
        private AccionesMejoraViewModel ObtenerAccionesMejora(int idMetricaAgil)
        {
            AccionesMejoraViewModel accionesMejoraViewModel = new AccionesMejoraViewModel();
            AccionesMejora AccionesMejora = new AccionesMejora();
            AccionesMejora.ListaAccionesMejora = this.negocioAccionMejora.ObtenerPorMetricaAgil(idMetricaAgil, this.ObtenerLenguaje);
            accionesMejoraViewModel.AccionesMejora = AccionesMejora;
            accionesMejoraViewModel.Id = AccionesMejora.Id;
            accionesMejoraViewModel.Accion = AccionesMejora.Accion;
            ItemMaestro responsable = new ItemMaestro();
            if (AccionesMejora.Responsable != null)
            {
                responsable.Id = AccionesMejora.Responsable.Id;
            }
            accionesMejoraViewModel.Responsable = responsable;
            ItemMaestro estado = new ItemMaestro();
            if (AccionesMejora.Estado != null)
            {
                estado.Id = AccionesMejora.Estado.Id;
            }
            accionesMejoraViewModel.Estado = estado;
            accionesMejoraViewModel.ListaResponsablesAccionesMejora = this.negocioSoluciones.ConsultarPorMaestro(
                TiposMaestro.ResponsablesAccionesMejora,
                this.ObtenerLenguaje).ToRequiredSelectListItem();
            accionesMejoraViewModel.ListaEstadosAccionesMejora = this.negocioSoluciones.ConsultarPorMaestro(
                TiposMaestro.EstadosAccionesMejora,
                this.ObtenerLenguaje).ToRequiredSelectListItem();
            return accionesMejoraViewModel;
        }
        private HistoriasyEsfuerzos EstablecerHistoriasyEsfuerzo(MetricasViewModel metricasViewModel)
        {
            return new HistoriasyEsfuerzos
            {
                Id = metricasViewModel.historiasyEsfuerzosViewModel.Id,
                IdMetricaAgil = metricasViewModel.historiasyEsfuerzosViewModel.IdMetricaAgil,
                EsfuerzoEstimado = Convert.ToDecimal(
                    CultureInfo.CurrentCulture.Name == TransversalesConstantes.CulturaEspanol ?
                    metricasViewModel.historiasyEsfuerzosViewModel.EsfuerzoEstimado.Replace('.', ',') :
                    metricasViewModel.historiasyEsfuerzosViewModel.EsfuerzoEstimado.Replace(',', '.'),
                    CultureInfo.CurrentCulture
                    ),
                EsfuerzoLogrado = Convert.ToDecimal(
                    CultureInfo.CurrentCulture.Name == TransversalesConstantes.CulturaEspanol ?
                    metricasViewModel.historiasyEsfuerzosViewModel.EsfuerzoLogrado.Replace('.', ',') :
                    metricasViewModel.historiasyEsfuerzosViewModel.EsfuerzoLogrado.Replace(',', '.'),
                    CultureInfo.CurrentCulture
                    ),
                HistoriasEstimadas = metricasViewModel.historiasyEsfuerzosViewModel.HistoriasEstimadas,
                HistoriasLogradas = metricasViewModel.historiasyEsfuerzosViewModel.HistoriasLogradas,
                Observaciones = metricasViewModel.historiasyEsfuerzosViewModel.Observaciones
            };
        }
        private DefectosInternos EstablecerDefectosInternos(MetricasViewModel metricasViewModel)
        {
            return new DefectosInternos
            {
                IdMetricaAgil = metricasViewModel.historiasyEsfuerzosViewModel.IdMetricaAgil,
                Reportados = metricasViewModel.defectosInternosViewModel.ReportadosDefectos,
                Cerrados = metricasViewModel.defectosInternosViewModel.CerradosDefectos,
                Actuales = metricasViewModel.defectosInternosViewModel.ReportadosDefectos - metricasViewModel.defectosInternosViewModel.CerradosDefectos,
                Abiertos = metricasViewModel.defectosInternosViewModel.AbiertosDefectos,
                Observaciones = metricasViewModel.defectosInternosViewModel.ObservacionesDefectos
            };
        }
        private DefectosExternos EstablecerDefectosExternos(MetricasViewModel metricasViewModel)
        {
            return new DefectosExternos
            {
                IdMetricaAgil = metricasViewModel.historiasyEsfuerzosViewModel.IdMetricaAgil,
                Reportados = metricasViewModel.defectosExternosViewModel.ReportadosDefectos,
                Cerrados = metricasViewModel.defectosExternosViewModel.CerradosDefectos,
                Actuales = metricasViewModel.defectosExternosViewModel.ReportadosDefectos - metricasViewModel.defectosExternosViewModel.CerradosDefectos,
                Abiertos = metricasViewModel.defectosExternosViewModel.AbiertosDefectos,
                Densidad = metricasViewModel.historiasyEsfuerzosViewModel.HistoriasLogradas == (int)default ? (int)default : (Convert.ToDecimal(
                    metricasViewModel.defectosExternosViewModel.ReportadosDefectos, CultureInfo.CurrentCulture) / Convert.ToDecimal(
                        metricasViewModel.historiasyEsfuerzosViewModel.HistoriasLogradas,
                        CultureInfo.CurrentCulture)),
                Observaciones = metricasViewModel.defectosExternosViewModel.ObservacionesDefectos
            };
        }
        private Incendios EstablecerIncendios(MetricasViewModel metricasViewModel)
        {
            return new Incendios
            {
                IdMetricaAgil = metricasViewModel.historiasyEsfuerzosViewModel.IdMetricaAgil,
                Reportados = (int)metricasViewModel.incendiosViewModel.ReportadosIncendios,
                Solucionados = (int)metricasViewModel.incendiosViewModel.SolucionadosIncendios,
                Observaciones = metricasViewModel.incendiosViewModel.ObservacionesIncendios
            };
        }
        private CalidadCodigo EstablecerCalidadCodigo(MetricasViewModel metricasViewModel)
        {
            return new CalidadCodigo
            {
                IdMetricaAgil = metricasViewModel.historiasyEsfuerzosViewModel.IdMetricaAgil,
                Bugs = metricasViewModel.calidadCodigoViewModel.Bugs,
                Vulnerabilidades = metricasViewModel.calidadCodigoViewModel.Vulnerabilidades,
                DeudaTecnica = Convert.ToDecimal(
                    CultureInfo.CurrentCulture.Name == TransversalesConstantes.CulturaEspanol ?
                    metricasViewModel.calidadCodigoViewModel.DeudaTecnica.Replace('.', ',') :
                    metricasViewModel.calidadCodigoViewModel.DeudaTecnica.Replace(',', '.'),
                    CultureInfo.CurrentCulture),
                Cobertura = Convert.ToDecimal(
                    CultureInfo.CurrentCulture.Name == TransversalesConstantes.CulturaEspanol ?
                    metricasViewModel.calidadCodigoViewModel.Cobertura.Replace('.', ',') :
                    metricasViewModel.calidadCodigoViewModel.Cobertura.Replace(',', '.'),
                    CultureInfo.CurrentCulture),
                Duplicado = Convert.ToDecimal(
                    CultureInfo.CurrentCulture.Name == TransversalesConstantes.CulturaEspanol ?
                    metricasViewModel.calidadCodigoViewModel.Duplicado.Replace('.', ',') :
                    metricasViewModel.calidadCodigoViewModel.Duplicado.Replace(',', '.'),
                    CultureInfo.CurrentCulture),
                Observaciones = metricasViewModel.calidadCodigoViewModel.ObservacionesdeCalidadCodigo
            };
        }
        private AccionesMejora EstablecerAccionesMejora(MetricasViewModel metricasViewModel)
        {
            List<AccionesMejora> listaAccionesMejora = new List<AccionesMejora>();
            AccionesMejora accionesMejora = new AccionesMejora();

            var ArrayId = Request.Form.GetValues("itemIdAccionMejora");
            var ArrayCausa = Request.Form.GetValues("itemCausa");
            var ArrayAccion = Request.Form.GetValues("itemAccionMejora");
            var ArrayResponsable = Request.Form.GetValues("itemIdResponsable");
            var ArrayEstado = Request.Form.GetValues("itemIdEstado");

            for (int i = 0; i < ArrayAccion.Length; i++)
            {
                AccionesMejora itemAccionesMejora = new AccionesMejora();
                if (ArrayId != null && ArrayId.Count() >= i + 1)
                {
                    itemAccionesMejora.Id = int.Parse(ArrayId[i].ToString(
                        CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
                }
                itemAccionesMejora.IdMetricaAgil = metricasViewModel.historiasyEsfuerzosViewModel.IdMetricaAgil;
                itemAccionesMejora.Causa = ArrayCausa[i].ToString(CultureInfo.CurrentCulture);
                itemAccionesMejora.Accion = ArrayAccion[i].ToString(CultureInfo.CurrentCulture);
                itemAccionesMejora.Responsable.Id = (byte)int.Parse(ArrayResponsable[i].ToString(
                    CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
                itemAccionesMejora.Estado.Id = (byte)int.Parse(ArrayEstado[i].ToString(
                    CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
                listaAccionesMejora.Add(itemAccionesMejora);
            }

            accionesMejora.IdMetricaAgil = metricasViewModel.historiasyEsfuerzosViewModel.IdMetricaAgil;
            accionesMejora.ListaAccionesMejora = listaAccionesMejora;
            return accionesMejora;
        }
        private Historias EstablecerHistorias(MetricasViewModel metricasViewModel)
        {
            Historias historias = new Historias();
            List<Historias> listaHistorias = new List<Historias>();

            var ArrayId = Request.Form.GetValues("itemId");
            var ArrayNumero = Request.Form.GetValues("itemNumero");
            var ArrayNombre = Request.Form.GetValues("itemNombre");
            var ArrayEsfuerzosEstimado = Request.Form.GetValues("itemEsfuerzoEstimado");
            var ArrayEsfuerzoReal = Request.Form.GetValues("itemEsfuerzoReal");
            var ArrayObservaciones = Request.Form.GetValues("itemObservaciones");

            var separador = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            for (int i = 0; i < ArrayNumero.Length; i++)
            {
                Historias itemHistoria = new Historias();
                if (ArrayId != null && ArrayId.Count() >= i + 1)
                {
                    itemHistoria.Id = int.Parse(ArrayId[i].ToString(
                        CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
                }
                itemHistoria.IdMetricaAgil = metricasViewModel.historiasyEsfuerzosViewModel.IdMetricaAgil;
                itemHistoria.Numero = ArrayNumero[i].ToString(CultureInfo.CurrentCulture);
                itemHistoria.Nombre = (ArrayNombre[i].ToString(CultureInfo.CurrentCulture));
                itemHistoria.EsfuerzoEstimado = decimal.Parse(
                    separador == TransversalesConstantes.Coma ?
                    ArrayEsfuerzosEstimado[i].ToString(
                        CultureInfo.CurrentCulture).Replace('.', ',') :
                    ArrayEsfuerzosEstimado[i].ToString(
                        CultureInfo.CurrentCulture).Replace(',', '.'), CultureInfo.CurrentCulture);
                itemHistoria.EsfuerzoReal = decimal.Parse(
                    separador == TransversalesConstantes.Coma ?
                    ArrayEsfuerzoReal[i].ToString(CultureInfo.CurrentCulture).Replace('.', ',') :
                    ArrayEsfuerzoReal[i].ToString(
                        CultureInfo.CurrentCulture).Replace(',', '.'), CultureInfo.CurrentCulture);
                itemHistoria.Observaciones = (ArrayObservaciones[i].ToString(CultureInfo.CurrentCulture));
                listaHistorias.Add(itemHistoria);
            }

            historias.IdMetricaAgil = metricasViewModel.historiasyEsfuerzosViewModel.IdMetricaAgil;
            historias.ListaHistorias = listaHistorias;
            return historias;
        }

        public void ValidarListasSeguimiento(int idMetricaAgil)
        {
            var historias = this.negocioHistoria.ObtenerPorMetricaAgil(idMetricaAgil);
            if (historias.Count > 0)
            {
                throw new NegocioExcepcion("No se puede eliminar la m�trica. Verificar si existe seguimiento registrado.");
            }

        }

        private IList<SelectListItem> ConvertirListaEquiposEnSelectListItem(IEnumerable<EquipoSolucion> listaEquipos)
        {
            return listaEquipos.ToList().ConvertAll(EquipoSolucion =>
            {
                return new SelectListItem
                {
                    Text = EquipoSolucion.Nombre,
                    Value = EquipoSolucion.Id.ToString()
                };
            });
        }

        public IEnumerable<MetricasAgiles> VerificarBusquedaYPaginadorMetricasAgiles(
            Guid idSolucion,
            string terminoBusqueda,
            string filtroActual)
        {
            string parametroBusqueda = terminoBusqueda;

            ViewBag.filtroActualProyecto = parametroBusqueda;


            IEnumerable<MetricasAgiles> metricasAgiles;
            if (string.IsNullOrEmpty(parametroBusqueda))
            {
                metricasAgiles = this.negocioMetricaAgil.Consultar(idSolucion);
            }
            else
            {
                metricasAgiles = this.negocioMetricaAgil.ConsultarPorParametro(
                           idSolucion,
                           parametroBusqueda);
            }

            return metricasAgiles;
        }
    }
}

