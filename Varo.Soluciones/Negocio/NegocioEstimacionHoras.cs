namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Transactions;

    public class NegocioEstimacionHoras : NegocioBase, INegocioEstimacionHoras
    {
        private readonly IRepositorioEstimacionHoras repositorioEstimacionHoras;

        public NegocioEstimacionHoras() : this(new RepositorioBase(), new RepositorioEstimacionHoras())
        { }

        public NegocioEstimacionHoras(
            IRepositorioBase repositorioBase,
            IRepositorioEstimacionHoras repositorioEstimacionHoras) :
            base(repositorioBase)
        {
            this.repositorioEstimacionHoras = repositorioEstimacionHoras;
        }

        public void Crear(EstimacionHorasSolucion estimacionHorasSolucion)
        {
            if (estimacionHorasSolucion != null)
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    this.repositorioEstimacionHoras.Eliminar(estimacionHorasSolucion.IdSolucion);
                    this.repositorioEstimacionHoras.Crear(estimacionHorasSolucion);

                    transactionScope.Complete();
                }
            }
        }

        public IList<EstimacionHorasSolucion> Consultar(Guid idSolucion)
        {
            return this.repositorioEstimacionHoras.Consultar(idSolucion);
        }
    }
}

