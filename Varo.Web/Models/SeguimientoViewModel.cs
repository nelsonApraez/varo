namespace Varo.Web.Models
{
    using Varo.Soluciones.Entidades;
    using System;

    public class SeguimientoViewModel
    {
        public SeguimientoViewModel()
        {
            this.seguimiento = new Seguimiento();
        }
        public int Id { get; set; }
        public Guid IdSolucion { get; set; }
        public int IdAccionesMejora { get; set; }
        public string Observacion { get; set; }

        public DateTime? Fecha { get; set; }

        public String Usuario { get; set; }
        public Seguimiento seguimiento { get; set; }

    }
}
