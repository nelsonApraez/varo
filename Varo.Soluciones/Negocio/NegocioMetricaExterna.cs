
namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.SistemasExternos;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System.Collections.Generic;

    public class NegocioMetricaExterna : NegocioBase, INegocioMetricaExterna
    {
        private readonly IAdaptadorSonarExterno adaptadorSonarExterno;
        public NegocioMetricaExterna() :
            this(new RepositorioBase(), new AdaptadorSonarExterno())
        { }

        public NegocioMetricaExterna(IRepositorioBase repositorioBase
            , IAdaptadorSonarExterno adaptadorSonarExterno) : base(repositorioBase)
        {
            this.adaptadorSonarExterno = adaptadorSonarExterno;
        }

        public IList<Metrica> ConsultarMetricas()
        {

            return this.adaptadorSonarExterno.ConsultarMetricas();
        }

        public void CrearValorMetrica(ValorMetricaProyecto valorMetricaProyecto)
        {
            this.adaptadorSonarExterno.CrearValorMetrica(valorMetricaProyecto);
        }

        public IList<ValorMetrica> ConsultarValorMetricaPorProyecto(int idProyecto)
        {
            return this.adaptadorSonarExterno.ConsultarValorMetricas(idProyecto);
        }
    }
}

