
namespace Varo.Web.Controllers
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Web.Mvc;

    public class CorreosNotificacionesController : BaseController
    {
        private readonly INegocioNotificaciones negocioCorreoNotificaciones;

        public CorreosNotificacionesController()
        {
            this.negocioCorreoNotificaciones = new NegocioNotificaciones();
        }

        public ActionResult Consultar()
        {
            CorreoNotificacionesViewModel correoNotificacionesViewModel = new CorreoNotificacionesViewModel();

            try
            {
                correoNotificacionesViewModel.ListaCorreosNotificaciones = this.negocioCorreoNotificaciones.Consultar(this.ObtenerLenguaje);

            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(correoNotificacionesViewModel);

        }
        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Editar(FormCollection form)
        {
            try
            {
                Notificaciones notificaciones = new Notificaciones();
                IList<Notificaciones> listaValorNotificaciones = new List<Notificaciones>();
                var listaNotificaciones = this.negocioCorreoNotificaciones.Consultar(this.ObtenerLenguaje);

                foreach (var itemlistaNotificacion in listaNotificaciones)
                {
                    if (!string.IsNullOrEmpty(Request.Form["" + itemlistaNotificacion.Id]))
                    {
                        string valor = Request.Form["" + itemlistaNotificacion.Id].ToString(CultureInfo.CurrentCulture);
                        Notificaciones notifiacion = new Notificaciones
                        {
                            Valor = valor,
                            Id = itemlistaNotificacion.Id
                        };

                        listaValorNotificaciones.Add(notifiacion);
                    }

                }

                notificaciones.ListaNotificaciones = listaValorNotificaciones;

                this.negocioCorreoNotificaciones.Editar(notificaciones);

                TempData["MensajeCrearModulos"] = Recursos.Lenguaje.MensajeRegistroModificado;
                return RedirectToAction("Consultar", "CorreosNotificaciones");
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Consultar", "CorreosNotificaciones");
            }

        }
    }
}

