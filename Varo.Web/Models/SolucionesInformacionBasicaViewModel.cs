namespace Varo.Web.Models
{
    using System;

    public class SolucionesInformacionBasicaViewModel
    {
        public Guid id { get; set; }

        public string nombreProyecto { get; set; }
        public string nombreCliente { get; set; }
        public string nombreGerente { get; set; }
        public string nombreResponsable { get; set; }
        public string nombreScrumMaster { get; set; }
        public string urlDocumentacion { get; set; }
        public string urlRepositorioCodigoFuente { get; set; }
        public string urlInspeccion { get; set; }
        public string urlLeccionesAprendidas { get; set; }
        public string urlGestionAseguramientoCalidad { get; set; }
        public string nombreTipo { get; set; }
        public string nombreMarcoTrabajo { get; set; }
        public string nombreLineaSolucion { get; set; }
        public string nombreLineaNegocio { get; set; }
        public string nombreEstado { get; set; }
        public string nombreOficina { get; set; }

        /// <summary>
        /// Indica si el control de documentacion y codigo se realiza.
        /// True si se hacen ambas practicas, false de lo contrario
        /// </summary>
        public bool? controlArtefactos { get; set; }

        /// <summary>
        /// Indica si la gestion de tareas y errores se realiza.
        /// True si se ambas dos practicas, false de lo contrario
        /// </summary>
        public bool? gestionBacklog { get; set; }
        public bool? pruebasUnitariasAutomatizadas { get; set; }
        public bool? pruebasFuncionalesAutomatizadas { get; set; }
        public bool? integracionContinua { get; set; }
        public bool? inspeccionContinua { get; set; }
        public bool? despliegueContinuo { get; set; }
        public bool? monitoreoContinuo { get; set; }
        public bool? infraestructuraComoCodigo { get; set; }
        public string imagenNivelMadurez { get; set; }
        public int conteoTotalFilas { get; set; }
    }
}
