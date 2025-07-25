namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Transactions;

    public class NegocioAccionMejora : NegocioBase, INegocioAccionMejora
    {
        private readonly IRepositorioAccionMejora repositorioAccionMejora;

        public NegocioAccionMejora() : this(new RepositorioBase(), new RepositorioAccionMejora())
        { }

        public NegocioAccionMejora(IRepositorioBase repositorioBase,
                                IRepositorioAccionMejora repositorioAccionMejora) : base(repositorioBase)
        {
            this.repositorioAccionMejora = repositorioAccionMejora;
        }

        public IList<AccionesMejora> ObtenerPorMetricaAgil(int idMetricaAgil, string lenguaje)
        {
            return this.repositorioAccionMejora.ObtenerPorMetricaAgil(idMetricaAgil, lenguaje);
        }

        public IList<AccionesMejora> ConsultarPorSolucion(Guid idSolucion, string lenguaje)
        {
            return this.repositorioAccionMejora.ConsultarPorSolucion(idSolucion, lenguaje);
        }

        public void Crear(AccionesMejora accionesMejora)
        {
            if (accionesMejora != null)
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    this.repositorioAccionMejora.Eliminar(accionesMejora.IdMetricaAgil);
                    this.repositorioAccionMejora.Crear(accionesMejora);
                    transactionScope.Complete();
                }
            }
        }

        public void Editar(AccionesMejora accionesMejora)
        {
            if (accionesMejora != null)
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    foreach (var itemAccionesMejora in accionesMejora.ListaAccionesMejora)
                    {
                        this.repositorioAccionMejora.Editar(itemAccionesMejora);
                    }
                    transactionScope.Complete();
                }
            }
        }

        public IList<AccionesMejora> ConsultarPorSolucionParametroBusqueda(Guid idSolucion, string parametro, string lenguaje)
        {
            return this.repositorioAccionMejora.ConsultarPorSolucionParametroBusqueda(idSolucion, parametro, lenguaje);
        }
    }
}

