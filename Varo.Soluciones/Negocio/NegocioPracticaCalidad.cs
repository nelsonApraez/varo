// -------------------------------------------------------------------------------
// <copyright file="NegocioSoluciones.cs" company="Company S.A.">
//     COPYRIGHT(C) 2018, Company S.A.
// </copyright>
// <author>Developer</author>
// <email>developer@company.com</email>
// <date>09/08/2018</date>
// <summary>Implementa las funcionalidades de negocio para las soluciones.</summary>
// -------------------------------------------------------------------------------

namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System;

    public class NegocioPracticaCalidad : NegocioBase, INegocioPracticaCalidad
    {
        private bool controlDocumentacion;
        private bool controlCodigo;
        private bool gestionTareas;
        private bool gestionErrores;
        private bool integracionContinua;
        private bool inspeccionContinua;
        private bool pruebasUnitarias;
        private bool pruebasFuncionales;
        private bool despliegueContinuo;
        private bool monitoreoContinuo;
        private bool seguridadContinua;
        private bool rendimientoContinuo;
        private bool infraestructuraComoCodigo;

        private readonly IRepositorioPracticaCalidad repositorioPracticaCalidad;

        public NegocioPracticaCalidad() :
            this(
                new RepositorioBase(),
                new RepositorioPracticaCalidad())
        { }

        public NegocioPracticaCalidad(
            IRepositorioBase repositorioBase,
            IRepositorioPracticaCalidad repositorioPracticaCalidad) :
            base(repositorioBase)
        {
            this.repositorioPracticaCalidad = repositorioPracticaCalidad;
        }

        public PracticasCalidad ConsultarPorIdSolucion(Guid idSolucion)
        {
            return this.repositorioPracticaCalidad.ConsultarPorIdSolucion(idSolucion);
        }

        public void EstablecerPracticas(PracticasCalidad practicas)
        {
            controlDocumentacion = comprobarSiCumple(practicas.controlDocumentacion);
            controlCodigo = comprobarSiCumple(practicas.controlCodigo);
            gestionTareas = comprobarSiCumple(practicas.gestionTareas);
            gestionErrores = comprobarSiCumple(practicas.gestionErrores);
            integracionContinua = comprobarSiCumple(practicas.integracionContinua);
            inspeccionContinua = comprobarSiCumple(practicas.inspeccionContinua);
            pruebasUnitarias = comprobarSiCumple(practicas.pruebasUnitariasAutomatizadas);
            pruebasFuncionales = comprobarSiCumple(practicas.pruebasFuncionalesAutomatizadas);
            despliegueContinuo = comprobarSiCumple(practicas.despliegueContinuo);
            monitoreoContinuo = comprobarSiCumple(practicas.monitoreoContinuo);
            seguridadContinua = comprobarSiCumple(practicas.seguridadContinua);
            rendimientoContinuo = comprobarSiCumple(practicas.rendimientoContinuo);
            infraestructuraComoCodigo = comprobarSiCumple(practicas.infraestructuraComoCodigo);
        }

        public string ObtenerImagenNivelMadurez()
        {
            if (esCohete()) return "cohete.png";
            if (esAvion()) return "avion.png";
            if (esCarro()) return "carro.png";
            if (esBicicleta()) return "bicicleta.png";
            if (esCaminando()) return "caminando.png";

            return "gateando.png";
        }

        /// <summary>
        /// Decide si la practica de calidad esta cumplida o no.
        /// </summary>
        /// <param name="practica"></param>
        /// <returns>
        /// True si la practica esta cumplida o no se aplica (es null o true) 
        /// False si la practica no está cumplida (es false)
        /// </returns>
        private bool comprobarSiCumple(bool? practica)
        {
            return (practica == null || practica == true) ? true : false;
        }

        private bool esCaminando()
        {
            return (this.controlDocumentacion && this.controlCodigo && this.gestionTareas && this.gestionErrores);
        }

        private bool esBicicleta()
        {
            return (esCaminando() && this.integracionContinua && this.inspeccionContinua);
        }

        private bool esCarro()
        {
            return (esBicicleta() && this.pruebasUnitarias && this.pruebasFuncionales);
        }

        private bool esAvion()
        {
            return (esCarro() && this.despliegueContinuo && this.monitoreoContinuo);
        }

        private bool esCohete()
        {
            return (esAvion() && this.seguridadContinua && this.rendimientoContinuo && this.infraestructuraComoCodigo);
        }
    }
}
