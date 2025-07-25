namespace Varo.Web.Controllers
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Transversales;
    using Varo.Transversales.Constantes;
    using Varo.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;
    public class ProyectoExternoController : BaseController
    {
        private readonly NegocioProyectoExterno negocioProyectoExterno;

        public ProyectoExternoController()
        {
            this.negocioProyectoExterno = new NegocioProyectoExterno();
        }
        [HttpGet]
        public ActionResult Consultar(
            int? numeroPaginaActual,
            string terminoBusqueda,
            string filtroActual,
            string checkEnEjecucion,
            string enEjecucion)
        {
            PaginadorViewModel<IEnumerable<ProyectoExternoViewModel>> proyectosViewModel =
                new PaginadorViewModel<IEnumerable<ProyectoExternoViewModel>>();

            try
            {
                IEnumerable<Proyecto> proyectos = this.VerificarBusquedaYPaginadorProyecto(numeroPaginaActual, terminoBusqueda,
                   filtroActual, proyectosViewModel, checkEnEjecucion, enEjecucion);

                proyectosViewModel.EntidadViewModel = this.ConvertirProyectosAProyectosViewModel(proyectos);

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_Proyectos", proyectosViewModel);
                }

                return View(proyectosViewModel);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(proyectosViewModel);
        }

        public ActionResult Consultar()
        {
            ProyectoExternoViewModel proyectoExternoViewModel = new ProyectoExternoViewModel();

            try
            {
                proyectoExternoViewModel.Proyecto.ListaProyectos = this.negocioProyectoExterno.ConsultarProyectos();

            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(proyectoExternoViewModel);
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Crear(ProyectoExternoViewModel proyectoExternoViewModel, FormCollection form)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    List<Proyecto> listaProyecto = new List<Proyecto>();
                    Proyecto Proyecto = new Proyecto();

                    var arrayIdProyectos = Request.Form.GetValues("itemId");
                    var arrayNombreProyectos = Request.Form.GetValues("itemNombre");

                    for (int i = 0; i < arrayNombreProyectos.Length; i++)
                    {
                        Proyecto itemNombreEquipo = new Proyecto();
                        itemNombreEquipo.Nombre = arrayNombreProyectos[i].ToString(CultureInfo.CurrentCulture);
                        if (arrayIdProyectos[i] != string.Empty)
                        {
                            itemNombreEquipo.Id = Convert.ToInt32(arrayIdProyectos[i], CultureInfo.CurrentCulture);
                        }
                        listaProyecto.Add(itemNombreEquipo);
                    }

                    Proyecto.ListaProyectos = listaProyecto;

                    this.negocioProyectoExterno.CrearProyecto(Proyecto);
                    TempData["respuestaCreacion"] = Recursos.Lenguaje.MensajeRegistroModificado;
                }

                return RedirectToAction("Crear", "MetricaExterno");
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Consultar", "ProyectoExterno");
            }
        }


        public ActionResult Eliminar(int idProyecto)
        {
            try
            {
                Proyecto proyecto = new Proyecto
                {
                    Id = idProyecto
                };

                this.negocioProyectoExterno.InactivarProyecto(proyecto);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true, message = Recursos.Lenguaje.MensajeSolucionEliminada }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Editar(int idProyecto, string nombre)
        {
            try
            {

                this.negocioProyectoExterno.EditarProyecto(new Proyecto { Id = idProyecto, Nombre = nombre });
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true, message = Recursos.Lenguaje.MensajeSolucionModificada }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Crear(string nombre)
        {
            try
            {
                this.negocioProyectoExterno.CrearProyecto(new Proyecto { Nombre = nombre, IdOrigen = nombre });
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true, message = Recursos.Lenguaje.MensajeSolucionEliminada }, JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<Proyecto> VerificarBusquedaYPaginadorProyecto(
            int? numeroPaginaActual,
            string terminoBusqueda,
            string filtroActual,
            PaginadorViewModel<IEnumerable<ProyectoExternoViewModel>> proyectosViewModel,
            string checkTodos,
            string enEjecucion)
        {
            int NumeroPaginaActual = Convert.ToInt16(numeroPaginaActual ?? 1, CultureInfo.CurrentCulture);
            string parametroBusqueda = terminoBusqueda;
            string CheckEnEjecucion = checkTodos;

            if (parametroBusqueda != null)
            {
                NumeroPaginaActual = 1;
            }
            else
            {
                parametroBusqueda = string.Empty;
            }

            if (CheckEnEjecucion != null)
            {
                CheckEnEjecucion = "checked";
            }
            else
            {
                CheckEnEjecucion = NumeroPaginaActual == NumerosConstantes.Numero1 && enEjecucion != "checked" ? "" : enEjecucion;
            }

            ViewBag.enEjecucion = CheckEnEjecucion;

            ViewBag.filtroActualProyecto = parametroBusqueda;


            IEnumerable<Proyecto> proyectos;
            proyectos = this.negocioProyectoExterno.ConsultarProyectosPorParametro(
                            new FiltroProyecto
                            {
                                Activo = CheckEnEjecucion == "checked" ? 1 : 0,
                                Parametro = parametroBusqueda,
                                NumeroPagina = NumeroPaginaActual,
                                TamanoPagina = ParametrosGenerales.CantidadDeRegistrosPorPagina
                            });

            if (proyectos.Any())
            {
                proyectosViewModel.Paginador =
                new Paginador(
                    ViewBag.filtroActual,
                    ViewBag.enEjecucion,
                    proyectos.FirstOrDefault().ConteoTotalFilas,
                    NumeroPaginaActual,
                    ParametrosGenerales.CantidadDeRegistrosPorPagina);
            }

            return proyectos;
        }

        private IEnumerable<ProyectoExternoViewModel> ConvertirProyectosAProyectosViewModel(IEnumerable<Proyecto> proyectos)
        {

            IEnumerable<ProyectoExternoViewModel> proyectosViewModel = from proyecto in proyectos
                                                                       select new ProyectoExternoViewModel
                                                                       {
                                                                           Id = proyecto.Id,
                                                                           Nombre = proyecto.Nombre,
                                                                           IdTipoOrigen = proyecto.IdTipoOrigen,
                                                                           IdOrigen = proyecto.IdOrigen,
                                                                           Activo = proyecto.Activo
                                                                       };

            return proyectosViewModel;
        }
    }
}

