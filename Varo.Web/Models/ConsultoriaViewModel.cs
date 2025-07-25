namespace Varo.Web.Models
{
    using Varo.Maestros.Entidades;
    using Varo.Transversales.Entidades;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class ConsultoriaViewModel
    {
        public ConsultoriaViewModel()
        {
            this.LineaConsultoria = new ItemMaestro();
            this.LineaNegocio = new ItemMaestro();
            this.Estado = new ItemMaestro();
            this.Oficina = new ItemMaestro();
            this.Cliente = new Cliente();
            this.Pais = new ItemMaestro();
            this.Gsdc = new ItemMaestro();
            this.UsoComercial = new ItemMaestro();
        }

        public Guid Id { get; set; }
        [Required]
        public string NombreProyecto { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaCierre { get; set; }
        [Required]
        public string UsuarioRedGerente { get; set; }
        [Required]
        public string NombreGerente { get; set; }
        [Required]
        public string RolGerente { get; set; }
        [Required]
        public string UsuarioRedConsultor { get; set; }
        [Required]
        public string NombreConsultor { get; set; }
        [Required]
        public string RolConsultor { get; set; }
        [Required]
        public string UrlDocumentacion { get; set; }
        public string UrlDiseno { get; set; }
        [Required]
        public string UrlGestionTareas { get; set; }
        [Required]
        public string UrlGestionIncidentes { get; set; }
        [Required]
        public string UrlGestionAseguramientoCalidad { get; set; }
        [Required]
        public string UrlLeccionesAprendidas { get; set; }
        public string UrlOportunidadCrm { get; set; }
        public string UrlProyectoPsa { get; set; }

        [DataType(DataType.MultilineText)]
        public string Observacion { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
        public string Etiqueta { get; set; }
        [Required]
        public string NombreContactoCliente { get; set; }
        [Required]
        public string CorreoContactoCliente { get; set; }
        public string TelefonoContactoCliente { get; set; }
        public Cliente Cliente { get; set; }
        public IEnumerable<SelectListItem> ListaCliente { get; set; }
        public ItemMaestro Pais { get; set; }
        public IEnumerable<SelectListItem> ListaPais { get; set; }
        public ItemMaestro Estado { get; set; }
        public IEnumerable<SelectListItem> ListaEstados { get; set; }
        public ItemMaestro Oficina { get; set; }
        public IEnumerable<SelectListItem> ListaOficinas { get; set; }
        public ItemMaestro LineaConsultoria { get; set; }
        public IEnumerable<SelectListItem> ListaLineaConsultoria { get; set; }
        public ItemMaestro LineaNegocio { get; set; }
        public IEnumerable<SelectListItem> ListaLineaNegocio { get; set; }
        public TecnologiasViewModel TecnologiasViewModel { get; set; }
        public string Vista { get; set; }
        public IEnumerable<SelectListItem> ListaUsoComercial { get; set; }
        public IEnumerable<SelectListItem> ListaGsdc { get; set; }
        public ItemMaestro Gsdc { get; set; }
        public ItemMaestro UsoComercial { get; set; }

        public int ObjetivoNegocio { get; set; }
    }
}

