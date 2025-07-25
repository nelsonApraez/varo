namespace Varo.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PruebasFuncionalesViewModel
    {
        public Guid Id { get; set; }

        public Guid IdSolucion { get; set; }

        public int CasosDefinidos { get; set; }
        public int CasosaAutomatizar { get; set; }
        public int CasosAutomatizados { get; set; }
        public string UrlDiseñodeCasos { get; set; }
        public string UrlEvidencias { get; set; }
        public string UrlRepositorio { get; set; }
        public int CasosPendientes { get; set; }

        public string UsuarioRedTecnico { get; set; }

        public string NombreTecnico { get; set; }

        public DateTime FechaCreacion { get; set; }
        public string EstaenPipeline { get; set; }

        [DataType(DataType.MultilineText)]
        public string Observaciones { get; set; }
    }
}
