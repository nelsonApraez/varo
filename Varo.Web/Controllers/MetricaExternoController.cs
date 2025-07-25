namespace Varo.Web.Controllers
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;

    public class MetricaExternoController : BaseController
    {
        private readonly NegocioMetricaExterna negocioMetricaExterno;
        private readonly NegocioProyectoExterno negocioProyectoExterno;

        public MetricaExternoController()
        {
            this.negocioMetricaExterno = new NegocioMetricaExterna();
            this.negocioProyectoExterno = new NegocioProyectoExterno();
        }
        // GET: RegistrarMetrica
        public ActionResult Crear(string idOrigenProyecto)
        {
            MetricaExternoViewModel metricaExternoViewModel = new MetricaExternoViewModel();

            try
            {
                metricaExternoViewModel.IdOrigenProyecto = idOrigenProyecto;
                metricaExternoViewModel.ListaProyectos =
                  this.ConvertirListaProyectosEnSelectListItem(this.negocioProyectoExterno.ConsultarProyectos());

                metricaExternoViewModel.ListadoMetricas = this.negocioMetricaExterno.ConsultarMetricas();

            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(metricaExternoViewModel);
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Crear(MetricaExternoViewModel metricaViewModel, FormCollection form)
        {
            ValorMetricaProyecto valorMetrica = new ValorMetricaProyecto();
            Proyecto proyecto;
            IList<ValorMetricaExterna> listaMetricas = new List<ValorMetricaExterna>();

            try
            {
                proyecto = this.ObtenerProyectoValorMetrica(metricaViewModel);
                valorMetrica.Proyecto = proyecto;
                valorMetrica.Ano = metricaViewModel.Ano;
                valorMetrica.Mes = metricaViewModel.Mes;
                valorMetrica.FechaAnalisis = metricaViewModel.FechaAnalisis;
                valorMetrica.ListadoValorMetrica = this.ObtenerListaMetricas();

                this.negocioMetricaExterno.CrearValorMetrica(valorMetrica);

                TempData["respuestaCreacion"] = Recursos.Lenguaje.MensajeRegistroCreado;
                return RedirectToAction("Crear");
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Crear");
        }

        public ActionResult Consultar(int idProyecto)
        {
            MetricaExternoViewModel metricaExternoViewModel = new MetricaExternoViewModel();

            try
            {
                var listaValorMetrica = this.negocioMetricaExterno.ConsultarValorMetricaPorProyecto(idProyecto);
                metricaExternoViewModel.ListadoValorMetricasFechas = listaValorMetrica
                                                                   .GroupBy(x => new { x.Ano, x.Mes })
                                                                   .Select(s => new ValorMetrica { Ano = s.Key.Ano, Mes = s.Key.Mes }).ToList();

                metricaExternoViewModel.IdProyecto = idProyecto;

            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(metricaExternoViewModel);

        }

        public ActionResult VerDetalle(int idProyecto, int ano, int mes)
        {
            MetricaExternoViewModel metricaExternoViewModel = new MetricaExternoViewModel();

            try
            {
                var listaValorMetrica = this.negocioMetricaExterno.ConsultarValorMetricaPorProyecto(idProyecto);
                metricaExternoViewModel.ListadoValorMetricas = this.negocioMetricaExterno.ConsultarValorMetricaPorProyecto(idProyecto)
                                                                     .Where(x => x.Mes == mes && x.Ano == ano).ToList();

                metricaExternoViewModel.IdProyecto = idProyecto;
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(metricaExternoViewModel);

        }

        private Proyecto ObtenerProyectoValorMetrica(MetricaExternoViewModel metricaExternoViewModel)
        {
            return new Proyecto
            {
                IdOrigen = metricaExternoViewModel.IdOrigenProyecto
            };
        }

        private IList<SelectListItem> ConvertirListaProyectosEnSelectListItem(IEnumerable<Proyecto> proyectos)
        {
            IList<SelectListItem> selectListItem =

            proyectos.ToList().ConvertAll(Proyectos =>
            {
                return new SelectListItem
                {
                    Text = Proyectos.Nombre,
                    Value = Proyectos.IdOrigen
                };
            });

            return selectListItem;
        }

        private IList<ValorMetricaExterna> ObtenerListaMetricas()
        {
            IList<ValorMetricaExterna> listaValorMetrica = new List<ValorMetricaExterna>();
            var listaMetricas = this.negocioMetricaExterno.ConsultarMetricas();
            foreach (var metrica in listaMetricas)
            {
                if (!string.IsNullOrEmpty(Request.Form["" + metrica.Nombre]))
                {
                    decimal valor = Convert.ToDecimal(Request.Form["" + metrica.Nombre], CultureInfo.CurrentCulture);
                    ValorMetricaExterna valorMetrica = new ValorMetricaExterna();
                    valorMetrica.Valor = valor;
                    valorMetrica.NombreMetrica = metrica.Nombre;
                    listaValorMetrica.Add(valorMetrica);
                }

            }
            return listaValorMetrica;
        }
    }
}

