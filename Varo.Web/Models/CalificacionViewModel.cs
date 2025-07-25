namespace Varo.Web.Models
{
    using Varo.Maestros.Entidades;
    using Varo.Soluciones.Entidades;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public abstract class CalificacionViewModel
    {
        public Guid Id { get; set; }
        public Guid IdSolucion { get; set; }
        public Guid IdConsultoria { get; set; }
        [DataType(DataType.Url)]
        public string Url { get; set; }
        public decimal Calificacion { get; set; }
        public string CalificacionDeSeguridad { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public string Proceso { get; set; }
        public string Observacion { get; set; }
        public IEnumerable<SelectListItem> ListaClientes { get; set; }
        public IEnumerable<SelectListItem> ListaSoluciones { get; set; }
        public Cliente Cliente { get; set; }
        public Solucion Solucion { get; set; }
        public IList<CalificacionViewModel> ListaCalificaciones { get; set; }
    }
}

