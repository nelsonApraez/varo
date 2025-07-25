namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System.Transactions;

    public class NegocioHistoriayEsfuerzo : NegocioBase, INegocioHistoriayEsfuerzo
    {
        private readonly IRepositorioHistoriayEsfuerzo repositorioHistoriayEsfuerzo;

        public NegocioHistoriayEsfuerzo() : this(new RepositorioBase(), new RepositorioHistoriayEsfuerzo())
        { }

        public NegocioHistoriayEsfuerzo(IRepositorioBase repositorioBase,
                                IRepositorioHistoriayEsfuerzo repositorioHistoriayEsfuerzo) : base(repositorioBase)
        {
            this.repositorioHistoriayEsfuerzo = repositorioHistoriayEsfuerzo;
        }

        public HistoriasyEsfuerzos ObtenerPorMetricaAgil(int idMetricaAgil)
        {
            return this.repositorioHistoriayEsfuerzo.ObtenerPorMetricaAgil(idMetricaAgil);
        }

        public void Crear(HistoriasyEsfuerzos historiayEsfuerzo)
        {
            if (historiayEsfuerzo != null)
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    this.repositorioHistoriayEsfuerzo.Eliminar(historiayEsfuerzo.Id);
                    this.repositorioHistoriayEsfuerzo.Crear(historiayEsfuerzo);

                    transactionScope.Complete();
                }
            }
        }
    }
}

