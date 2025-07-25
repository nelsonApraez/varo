
namespace Varo.Web.Controllers
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Web.Mvc;

    public class EquiposController : BaseController
    {
        private readonly INegocioEquipoSolucion negocioEquipoSolucion;

        public EquiposController()
        {
            this.negocioEquipoSolucion = new NegocioEquipoSolucion();
        }
        public ActionResult Consultar(Guid idSolucion)
        {
            EquipoSolucionViewModel equipoSolucionViewModel = new EquipoSolucionViewModel();

            try
            {
                equipoSolucionViewModel.EquipoSolucion.ListaEquipoSolucion = this.negocioEquipoSolucion.Consultar(idSolucion);
                equipoSolucionViewModel.IdSolucion = idSolucion;
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }
            return View(equipoSolucionViewModel);
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Crear(EquipoSolucionViewModel equipoSolucionViewModel, FormCollection form)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    List<EquipoSolucion> listaEquipos = new List<EquipoSolucion>();
                    EquipoSolucion equipos = new EquipoSolucion();

                    var arrayIdEquipos = Request.Form.GetValues("itemId");
                    var arrayNombreEquipos = Request.Form.GetValues("itemNombre");

                    for (int i = 0; i < arrayNombreEquipos.Length; i++)
                    {
                        EquipoSolucion itemNombreEquipo = new EquipoSolucion();
                        itemNombreEquipo.Nombre = arrayNombreEquipos[i].ToString(CultureInfo.CurrentCulture);
                        if (arrayIdEquipos[i] != string.Empty)
                        {
                            itemNombreEquipo.Id = new Guid(arrayIdEquipos[i]);
                        }
                        listaEquipos.Add(itemNombreEquipo);
                    }

                    equipos.IdSolucion = equipoSolucionViewModel.IdSolucion;
                    equipos.ListaEquipoSolucion = listaEquipos;

                    this.negocioEquipoSolucion.Crear(equipos);
                    TempData["MensajeCrearModulos"] = Recursos.Lenguaje.MensajeRegistroModificado;
                }

                return RedirectToAction("Editar", "Solucion", new { id = equipoSolucionViewModel.IdSolucion });
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Consultar", "Equipos", new { idSolucion = equipoSolucionViewModel.IdSolucion });
            }
        }

    }
}

