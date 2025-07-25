namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System.Transactions;

    public class NegocioIncendio : NegocioBase, INegocioIncendio
    {
        private readonly IRepositorioIncendio repositorioIncendio;

        public NegocioIncendio() : this(new RepositorioBase(), new RepositorioIncendio())
        { }

        public NegocioIncendio(IRepositorioBase repositorioBase,
                                IRepositorioIncendio repositorioIncendio) : base(repositorioBase)
        {
            this.repositorioIncendio = repositorioIncendio;
        }

        public Incendios ObtenerPorMetricaAgil(int idMetricaAgil)
        {
            return this.repositorioIncendio.ObtenerPorMetricaAgil(idMetricaAgil);
        }

        public void Crear(Incendios incendios)
        {
            if (incendios != null)
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    this.repositorioIncendio.Eliminar(incendios.IdMetricaAgil);
                    this.repositorioIncendio.Crear(incendios);

                    transactionScope.Complete();
                }
            }
        }
    }
}

