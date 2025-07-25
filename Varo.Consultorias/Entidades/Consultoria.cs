namespace Varo.Consultorias.Entidades
{
    using Varo.Maestros.Entidades;
    using Varo.Transversales.Entidades;
    using System;

    public class Consultoria
    {
        public Consultoria()
        {
            this.LineaConsultoria = new ItemMaestro();
            this.LineaNegocio = new ItemMaestro();
            this.Estado = new ItemMaestro();
            this.Oficina = new ItemMaestro();
            this.Cliente = new Cliente();
            this.Pais = new ItemMaestro();
            this.UsoComercial = new ItemMaestro();
            this.Gsdc = new ItemMaestro();
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string UsuarioRedGerente { get; set; }
        public string UsuarioRedConsultor { get; set; }
        public string UrlDocumentacion { get; set; }
        public string UrlDiseno { get; set; }
        public string UrlGestionTareas { get; set; }
        public string UrlGestionIncidentes { get; set; }
        public string UrlGestionAseguramientoCalidad { get; set; }
        public string UrlLeccionesAprendidas { get; set; }
        public string UrlOportunidadCrm { get; set; }
        public string UrlProyectoPsa { get; set; }
        public string Observacion { get; set; }
        public string Descripcion { get; set; }
        public string NombreContactoCliente { get; set; }
        public string CorreoContactoCliente { get; set; }
        public string TelefonoContactoCliente { get; set; }
        public Cliente Cliente { get; set; }
        public ItemMaestro Pais { get; set; }
        public ItemMaestro LineaConsultoria { get; set; }
        public ItemMaestro LineaNegocio { get; set; }
        public string Etiqueta { get; set; }
        public ItemMaestro Estado { get; set; }
        public ItemMaestro Oficina { get; set; }
        public string UsuarioRedLogueado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaCierre { get; set; }
        public int HorasEstimadas { get; set; }
        public int HorasEjecutadas { get; set; }
        public ItemMaestro UsoComercial { get; set; }
        public ItemMaestro Gsdc { get; set; }

        public int ObjetivoNegocio { get; set; }
    }
}

