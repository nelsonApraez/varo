
namespace Varo.Consultorias.Entidades
{
    using Varo.Maestros.Entidades;
    using Varo.Transversales.Entidades;
    using System;
    public class ConsultoriaInformacionBasica
    {
        public ConsultoriaInformacionBasica()
        {
            this.Cliente = new Cliente();
            this.LineaConsultoria = new ItemMaestro();
            this.Estado = new ItemMaestro();
            this.Oficina = new ItemMaestro();
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public Cliente Cliente { get; set; }
        public string UsuarioRedGerente { get; set; }
        public string NombreGerente { get; set; }
        public string UsuarioRedConsultor { get; set; }
        public string NombreConsultor { get; set; }
        public string UrlDocumentacion { get; set; }
        public string UrlGestionAseguramientoCalidad { get; set; }
        public string UrlLeccionesAprendidas { get; set; }
        public ItemMaestro LineaConsultoria { get; set; }
        public ItemMaestro Estado { get; set; }
        public ItemMaestro Oficina { get; set; }
        public int ConteoTotalFilas { get; set; }
    }
}

