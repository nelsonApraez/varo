using System;

namespace Varo.Api.Models
{
    /// <summary>
    /// Operacion
    /// </summary>
    public class Operacion
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public byte IdTipo { get; set; }
        public string NombreTipo { get; set; }
        public byte IdLineaNegocio { get; set; }
        public string NombreLineaNegocio { get; set; }
        public byte IdEstado { get; set; }
        public string NombreEstado { get; set; }
        public byte IdOficina { get; set; }
        public string NombreOficina { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string UsuarioRedGerente { get; set; }
        public string UsuarioRedResponsableTecnico { get; set; }
        public string UsuarioRedScrumMaster { get; set; }
    }
}
