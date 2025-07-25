namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System.Transactions;

    public class NegocioDefectoExterno : NegocioBase, INegocioDefectoExterno
    {
        private readonly IRepositorioDefectoExterno repositorioDefectoExterno;

        public NegocioDefectoExterno() : this(new RepositorioBase(), new RepositorioDefectoExterno())
        { }

        public NegocioDefectoExterno(IRepositorioBase repositorioBase,
                                IRepositorioDefectoExterno repositorioDefectoExterno) : base(repositorioBase)
        {
            this.repositorioDefectoExterno = repositorioDefectoExterno;
        }

        public DefectosExternos ObtenerPorMetricaAgil(int idMetricaAgil)
        {
            return this.repositorioDefectoExterno.ObtenerPorMetricaAgil(idMetricaAgil);
        }

        public void Crear(DefectosExternos defectosExternos)
        {
            if (defectosExternos != null)
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    this.repositorioDefectoExterno.Eliminar(defectosExternos.IdMetricaAgil);
                    this.repositorioDefectoExterno.Crear(defectosExternos);

                    transactionScope.Complete();
                }
            }
        }
    }
}

