namespace Varo.Web.Models
{
    using Varo.Soluciones.Entidades;
    using System;
    using System.Collections.Generic;

    public class ResumenSolucionViewModel
    {
        public ResumenSolucionViewModel()
        {
            Lineas = "0";
            Bugs = 0;
            Vulnerabilidades = 0;
            CodeSmell = 0;
            Cobertura = 0;
            CodigoDuplicado = 0;
        }

        public string Cliente { get; set; }

        public string NombreSolucion { get; set; }

        public string LineaSolucion { get; set; }

        public string TipoSolucion { get; set; }

        public IList<TecnologiaSolucion> Tecnologias { get; set; }

        public string Lineas { get; set; }

        public int Bugs { get; set; }

        public int Vulnerabilidades { get; set; }

        public int Hotspots { get; set; }

        public decimal CodeSmell { get; set; }

        public decimal Cobertura { get; set; }

        public decimal CodigoDuplicado { get; set; }

        public string UrlAuditoria { get; set; }

        public string CalificacionAuditoria { get; set; }

        public DateTime FechaCalificacionAuditoria { get; set; }

        public string UrlSeguridad { get; set; }

        public string CalificacionSeguridad { get; set; }

        public DateTime FechaCalificacionSeguridad { get; set; }

        public string UrlDesemepeno { get; set; }

        public string CalificacionDesemepeno { get; set; }

        public DateTime FechaCalificacionDesempeno { get; set; }

        public string RutaLogo { get; set; }

        /// <summary>
        /// Indica si el control de documentos y codigo se realiza.
        /// True si se ambas dos practicas, false de lo contrario
        /// </summary>
        public bool? ControlArtefactos { get; set; }

        /// <summary>
        /// Indica si la gestion de tareas y errores se realiza.
        /// True si se ambas dos practicas, false de lo contrario
        /// </summary>
        public bool? GestionBacklog { get; set; }

        public bool? PruebasUnitariasAutomatizadas { get; set; }

        public bool? PruebasFuncionalesAutomatizadas { get; set; }

        public bool? IntegracionContinua { get; set; }

        public bool? InspeccionContinua { get; set; }

        public bool? DespliegueContinuo { get; set; }

        public bool? MonitoreoContinuo { get; set; }

        public bool? SeguridadContinua { get; set; }

        public bool? RendimientoContinuo { get; set; }

        public bool? InfraestructuraComoCodigo { get; set; }

        public string ImagenNivelMadurez { get; set; }

        public string Framework { get; set; }

        public string Estado { get; set; }
    }
}

