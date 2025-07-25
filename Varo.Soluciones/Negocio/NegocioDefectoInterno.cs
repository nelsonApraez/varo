namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System.Transactions;

    public class NegocioDefectoInterno : NegocioBase, INegocioDefectoInterno
    {
        private readonly IRepositorioDefectoInterno repositorioDefectoInterno;

        public NegocioDefectoInterno() : this(new RepositorioBase(), new RepositorioDefectoInterno())
        { }

        public NegocioDefectoInterno(IRepositorioBase repositorioBase,
                                IRepositorioDefectoInterno repositorioDefectoInterno) : base(repositorioBase)
        {
            this.repositorioDefectoInterno = repositorioDefectoInterno;
        }

        public DefectosInternos ObtenerPorMetricaAgil(int idMetricaAgil)
        {
            return this.repositorioDefectoInterno.ObtenerPorMetricaAgil(idMetricaAgil);
        }

        public void Crear(DefectosInternos defectosInternos)
        {
            if (defectosInternos != null)
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    this.repositorioDefectoInterno.Eliminar(defectosInternos.IdMetricaAgil);
                    this.repositorioDefectoInterno.Crear(defectosInternos);

                    transactionScope.Complete();
                }
            }
        }
    }
}

