namespace Varo.Soluciones.Entidades
{
    using System;

    public class Prueba
    {
        public Guid Id { get; set; }

        public Guid IdSolucion { get; set; }

        public string NombreSolucion { get; set; }

        public string UsuarioRedTecnico { get; set; }

        public string NombreTecnico { get; set; }

        public int CasosDefinidos { get; set; }
        public int CasosAutomatizar { get; set; }

        public int CasosAutomatizados { get; set; }
        public string UrlDiseñoCasos { get; set; }
        public string UrlEvidencias { get; set; }
        public string UrlRepositorio { get; set; }

        public int CasosPendientes { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public bool EstaenPipeline { get; set; }

        public string Observaciones { get; set; }
    }
}

