namespace Varo.Web.Models
{
    using Varo.Maestros.Entidades;
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Entidades;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class SolucionesViewModel
    {
        public SolucionesViewModel()
        {
            this.Tipo = new ItemMaestro();
            this.MarcoTrabajo = new ItemMaestro();
            this.LineaSolucion = new ItemMaestro();
            this.LineaNegocio = new ItemMaestro();
            this.Estado = new ItemMaestro();
            this.Oficina = new ItemMaestro();
            this.Cliente = new Cliente();
            this.Pais = new ItemMaestro();
            this.Gsdc = new ItemMaestro();
            this.UsoComercial = new ItemMaestro();
        }


        [Required]
        public Guid Id { get; set; }
        public Guid? Consultoria { get; set; }
        public IEnumerable<SelectListItem> ListaConsultoria { get; set; }
        [Required]
        public string NombreProyecto { get; set; }
        [Required]
        public string UsuarioRedGerente { get; set; }
        [Required]
        public string NombreGerente { get; set; }
        [Required]
        public string RolGerente { get; set; }
        [Required]
        public string UsuarioRedResponsable { get; set; }
        [Required]
        public string NombreResponsable { get; set; }
        [Required]
        public string RolResponsable { get; set; }
        public string UsuarioRedScrumMaster { get; set; }
        public string NombreScrumMaster { get; set; }
        public string RolScrumMaster { get; set; }
        //[Required]
        public string UrlDocumentacion { get; set; }
        //[Required]
        public string UrlRepositorioCodigoFuente { get; set; }
        public string UrlInspeccion { get; set; }
        public string UrlDiseno { get; set; }
        //[Required]
        public string UrlGestionTareas { get; set; }
        //[Required]
        public string UrlGestionIncidentes { get; set; }
        //[Required]
        public string UrlGestionAseguramientoCalidad { get; set; }
        //[Required]
        public string UrlLeccionesAprendidas { get; set; }
        public string UrlOportunidadCrm { get; set; }
        public string UrlProyectoPsa { get; set; }
        [DataType(DataType.MultilineText)]
        public string Observacion { get; set; }
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
        public string Etiqueta { get; set; }
        public string UX { get; set; }
        //[Required]
        public string NombreContactoCliente { get; set; }
        //[Required]
        public string CorreoContactoCliente { get; set; }
        public string TelefonoContactoCliente { get; set; }
        public Cliente Cliente { get; set; }
        public IEnumerable<SelectListItem> ListaCliente { get; set; }
        public ItemMaestro Pais { get; set; }
        public IEnumerable<SelectListItem> ListaPais { get; set; }
        public ItemMaestro Tipo { get; set; }
        public IEnumerable<SelectListItem> ListaTipo { get; set; }
        public ItemMaestro Estado { get; set; }
        public IEnumerable<SelectListItem> ListaEstados { get; set; }
        public ItemMaestro Oficina { get; set; }
        public IEnumerable<SelectListItem> ListaOficinas { get; set; }
        public ItemMaestro LineaSolucion { get; set; }
        public IEnumerable<SelectListItem> ListaLineaSolucion { get; set; }
        public ItemMaestro MarcoTrabajo { get; set; }
        public IEnumerable<SelectListItem> ListaMarcosTrabajo { get; set; }
        public ItemMaestro LineaNegocio { get; set; }
        public IEnumerable<SelectListItem> ListaLineaNegocio { get; set; }
        public string checkExperienciaUsuario { get; set; }
        public IntegracionesContinuas IntegracionesContinuas { get; set; }
        public DesplieguesContinuos DesplieguesContinuos { get; set; }
        public MonitoreosContinuos MonitoreosContinuos { get; set; }
        public IEnumerable<SelectListItem> ListaInspeccionContinua { get; set; }
        public TecnologiasViewModel TecnologiasViewModel { get; set; }
        public bool? ControlDocumentacion { get; set; }
        public bool? ControlCodigo { get; set; }
        public bool? GestionTareas { get; set; }
        public bool? GestionErrores { get; set; }
        public bool? PruebasUnitariasAutomatizadas { get; set; }
        public bool? PruebasFuncionalesAutomatizadas { get; set; }
        public bool? IntegracionContinua { get; set; }
        public bool? InspeccionContinua { get; set; }
        public bool? DespliegueContinuo { get; set; }
        public bool? MonitoreoContinuo { get; set; }
        public bool? SeguridadContinua { get; set; }
        public bool? RendimientoContinuo { get; set; }
        public bool? InfraestructuraComoCodigo { get; set; }
        public string notasControlDocumentacion { get; set; }
        public string notasControlCodigo { get; set; }
        public string notasGestionTareas { get; set; }
        public string notasGestionErrores { get; set; }
        public string notasPruebasUnitariasAutomatizadas { get; set; }
        public string notasPruebasFuncionalesAutomatizadas { get; set; }
        public string notasIntegracionContinua { get; set; }
        public string notasInspeccionContinua { get; set; }
        public string notasDespliegueContinuo { get; set; }
        public string notasMonitoreoContinuo { get; set; }
        public string notasSeguridadContinua { get; set; }
        public string notasRendimientoContinuo { get; set; }
        public string notasInfraestructuraComoCodigo { get; set; }
        public string Vista { get; set; }
        public IEnumerable<SelectListItem> ListaUsoComercial { get; set; }
        public IEnumerable<SelectListItem> ListaGsdc { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaCierre { get; set; }
        public ItemMaestro Gsdc { get; set; }
        public ItemMaestro UsoComercial { get; set; }
        public int ObjetivoNegocio { get; set; }
    }
}

