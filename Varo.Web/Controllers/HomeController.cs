//// --------------------------------------------------------------------------------
//// <copyright file="HomeController.cs">Company S.A.</copyright>
//// <author>Nelson Apraez</author>
//// <email>developer@company.com</email>
//// <date>09/09/2018</date>
//// <summary>Proporciona funcionalidades genéricas para los controllers.</summary>
//// --------------------------------------------------------------------------------

namespace Varo.Web.Controllers
{
    using Varo.Consultorias.Entidades;
    using Varo.Consultorias.Negocio;
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        private readonly int estadoEjecucionConsultoria = 1;
        private readonly int estadoEjecucionSolucion = 1;
        private readonly int gsdcCO = 1;
        private readonly int gsdcLATAM = 2;
        private readonly int gsdcNORAM = 3;
        private readonly int gsdcEMEA = 4;
        private readonly int gsdcDACH = 5;
        private readonly int gsdcAPAC = 6;
        private readonly INegocioSoluciones negocioSoluciones;
        private readonly INegocioConsultoria negocioConsultoria;

        public HomeController()
        {
            this.negocioSoluciones = new NegocioSoluciones();
            this.negocioConsultoria = new NegocioConsultoria();
        }

        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();

            try
            {
                IList<Consultoria> consultorias = this.negocioConsultoria.Consultar();
                IList<Solucion> soluciones = this.negocioSoluciones.Consultar();

                homeViewModel.ConsultoriasAPAC = consultorias.ToList().Count(lista => lista.Gsdc.Id == this.gsdcAPAC && lista.Estado.Id == this.estadoEjecucionConsultoria);
                homeViewModel.ConsultoriasEMEA = consultorias.ToList().Count(lista => (lista.Gsdc.Id == this.gsdcEMEA || lista.Gsdc.Id == this.gsdcDACH) && lista.Estado.Id == this.estadoEjecucionConsultoria);
                homeViewModel.ConsultoriasLATAM = consultorias.ToList().Count(lista => (lista.Gsdc.Id == this.gsdcLATAM || lista.Gsdc.Id == this.gsdcCO) && lista.Estado.Id == this.estadoEjecucionConsultoria);
                homeViewModel.ConsultoriasNORAM = consultorias.ToList().Count(lista => lista.Gsdc.Id == this.gsdcNORAM && lista.Estado.Id == this.estadoEjecucionConsultoria);

                homeViewModel.SolucionesAPAC = soluciones.ToList().Count(lista => lista.Gsdc.Id == this.gsdcAPAC && lista.Estado.Id == this.estadoEjecucionSolucion);
                homeViewModel.SolucionesEMEA = soluciones.ToList().Count(lista => (lista.Gsdc.Id == this.gsdcEMEA || lista.Gsdc.Id == this.gsdcDACH) && lista.Estado.Id == this.estadoEjecucionSolucion);
                homeViewModel.SolucionesLATAM = soluciones.ToList().Count(lista => (lista.Gsdc.Id == this.gsdcLATAM || lista.Gsdc.Id == this.gsdcCO) && lista.Estado.Id == this.estadoEjecucionSolucion);
                homeViewModel.SolucionesNORAM = soluciones.ToList().Count(lista => lista.Gsdc.Id == this.gsdcNORAM && lista.Estado.Id == this.estadoEjecucionSolucion);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(homeViewModel);
        }
    }
}
