namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.SistemasExternos;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Linq;

    public class NegocioMetricaSistemica : NegocioBase, INegocioMetricaSistemica
    {
        private readonly IAdaptadorSombreroBlanco adaptadorSombreroBlanco;

        public NegocioMetricaSistemica() : this(new RepositorioBase(), new AdaptadorSombreroBlanco())
        { }

        public NegocioMetricaSistemica(IRepositorioBase repositorioBase,
                                IAdaptadorSombreroBlanco adaptadorSombreroBlanco) : base(repositorioBase)
        {
            this.adaptadorSombreroBlanco = adaptadorSombreroBlanco;
        }

        public CalificacionDesempeno ObtenerUltimaCalificacionDesempeño(Guid idSolucion)
        {
            throw new NotImplementedException();
        }

        public CalificacionSeguridad ObtenerUltimaCalificacionSeguridad(Guid idSolucion)
        {
            var calificacionSeguridad = this.adaptadorSombreroBlanco.ObtenerCalificacionSeguridad(idSolucion);
            if (calificacionSeguridad.Count == 0)
                return null;
            return calificacionSeguridad.First();
        }
    }
}

