namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System.Collections.Generic;
    using System.Transactions;

    public class NegocioHistoria : NegocioBase, INegocioHistoria
    {
        private readonly IRepositorioHistoria repositorioHistoria;

        public NegocioHistoria() : this(new RepositorioBase(), new RepositorioHistoria())
        { }

        public NegocioHistoria(IRepositorioBase repositorioBase,
                                IRepositorioHistoria repositorioHistoria) : base(repositorioBase)
        {
            this.repositorioHistoria = repositorioHistoria;
        }

        public IList<Historias> ObtenerPorMetricaAgil(int idMetricaAgil)
        {
            return this.repositorioHistoria.ObtenerPorMetricaAgil(idMetricaAgil);
        }

        public void Crear(Historias historias)
        {
            if (historias != null)
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    this.repositorioHistoria.Eliminar(historias.IdMetricaAgil);
                    this.repositorioHistoria.Crear(historias);

                    transactionScope.Complete();
                }
            }
        }
    }
}

