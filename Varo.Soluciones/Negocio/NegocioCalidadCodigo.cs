namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System.Transactions;

    public class NegocioCalidadCodigo : NegocioBase, INegocioCalidadCodigo
    {
        private readonly IRepositorioCalidadCodigo repositorioCalidadCodigo;

        public NegocioCalidadCodigo() : this(new RepositorioBase(), new RepositorioCalidadCodigo())
        { }

        public NegocioCalidadCodigo(IRepositorioBase repositorioBase,
                                IRepositorioCalidadCodigo repositorioCalidadCodigo) : base(repositorioBase)
        {
            this.repositorioCalidadCodigo = repositorioCalidadCodigo;
        }

        public CalidadCodigo ObtenerPorMetricaAgil(int idMetricaAgil)
        {
            return this.repositorioCalidadCodigo.ObtenerPorMetricaAgil(idMetricaAgil);
        }

        public void Crear(CalidadCodigo calidadCodigo)
        {
            if (calidadCodigo != null)
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    this.repositorioCalidadCodigo.Eliminar(calidadCodigo.IdMetricaAgil);
                    this.repositorioCalidadCodigo.Crear(calidadCodigo);

                    transactionScope.Complete();
                }
            }
        }
    }
}

