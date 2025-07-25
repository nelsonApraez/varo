namespace Varo.Web.Models
{
    using Varo.Soluciones.Entidades;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class MetricasAgilesViewModel : IValidatableObject
    {
        public MetricasAgilesViewModel()
        {
            this.metricasAgiles = new MetricasAgiles();
        }
        public int Id { get; set; }

        public Guid IdSolucion { get; set; }

        public IEnumerable<SelectListItem> ListaEquipos { get; set; }

        public Guid IdEquipo { get; set; }

        public string NombreEquipo { get; set; }
        public int Sprint { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "fecha inicial")]
        public DateTime FechaInicial { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "fecha final")]
        public DateTime FechaFinal { get; set; }

        public MetricasAgiles metricasAgiles { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errormsg = new List<ValidationResult>();
            if (FechaFinal < FechaInicial)
            {
                errormsg.Add(new ValidationResult("La fecha final no puede ser menor a la fecha inicial", new[] { "FechaFinal" }));
            }
            return errormsg;
        }
    }
}

