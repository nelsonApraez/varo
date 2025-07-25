namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System.Collections.Generic;
    using System.Linq;
    using System.Transactions;

    public class NegocioSeguimiento : NegocioBase, INegocioSeguimiento
    {
        private readonly IRepositorioSeguimiento repositorioSeguimiento;
        public NegocioSeguimiento() : this(new RepositorioBase(), new RepositorioSeguimiento())
        { }

        public NegocioSeguimiento(IRepositorioBase repositorioBase,
                                IRepositorioSeguimiento repositorioSeguimiento) : base(repositorioBase)
        {
            this.repositorioSeguimiento = repositorioSeguimiento;
        }

        public IList<Seguimiento> Consultar(int idAccionMejora)
        {
            return this.repositorioSeguimiento.Consultar(idAccionMejora);
        }

        public void Crear(Seguimiento seguimiento)
        {
            if (seguimiento != null)
            {

                seguimiento.ListaSeguimiento.ToList().ForEach(c => c.IdAccionesMejora = seguimiento.IdAccionesMejora);
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    this.repositorioSeguimiento.Eliminar(seguimiento.IdAccionesMejora);
                    this.repositorioSeguimiento.Crear(seguimiento);

                    transactionScope.Complete();
                }
            }
        }

    }
}

