namespace Varo.Api.Models
{
    using System;

    public class Solucion
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public byte IdTipo { get; set; }
        public string NombreTipo { get; set; }
        public byte IdMarcoTrabajo { get; set; }
        public string NombreMarcoTrabajo { get; set; }
        public byte IdLineaTecnologica { get; set; }
        public string NombreLineaTecnologica { get; set; }
        public byte IdLineaNegocio { get; set; }
        public string NombreLineaNeogcio { get; set; }
        public byte IdEstado { get; set; }
        public string NombreEstado { get; set; }
        public byte IdOficina { get; set; }
        public string NombreOficina { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string UsuarioRedGerente { get; set; }
        public string UsuarioRedResponsableTecnico { get; set; }
        public string UsuarioRedScrumMaster { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaCierre { get; set; }
        public string UrlDocumentacion { get; set; }

        public byte IdGsdc { get; set; }
        public string NombreGsdc { get; set; }
    }
}
