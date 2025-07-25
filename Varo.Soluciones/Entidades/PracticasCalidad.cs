namespace Varo.Soluciones.Entidades
{
    using System;

    public class PracticasCalidad
    {
        public Guid id { get; set; }
        public bool? controlDocumentacion { get; set; }
        public bool? controlCodigo { get; set; }
        public bool? gestionTareas { get; set; }
        public bool? gestionErrores { get; set; }
        public bool? pruebasUnitariasAutomatizadas { get; set; }
        public bool? pruebasFuncionalesAutomatizadas { get; set; }
        public bool? integracionContinua { get; set; }
        public bool? inspeccionContinua { get; set; }
        public bool? despliegueContinuo { get; set; }
        public bool? monitoreoContinuo { get; set; }
        public bool? seguridadContinua { get; set; }
        public bool? rendimientoContinuo { get; set; }
        public bool? infraestructuraComoCodigo { get; set; }
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

    }
}
