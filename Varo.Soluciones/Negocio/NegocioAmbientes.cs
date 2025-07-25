namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Transactions;

    public class NegocioAmbientes : NegocioBase, INegocioAmbientes
    {
        private readonly IRepositorioAmbientes repositorioAmbientes;

        public NegocioAmbientes() : this(new RepositorioBase(), new RepositorioAmbientes())
        { }

        public NegocioAmbientes(IRepositorioBase repositorioBase, IRepositorioAmbientes repositorioAmbientes) : base(repositorioBase)
        {
            this.repositorioAmbientes = repositorioAmbientes;
        }

        public void Crear(Ambientes ambientes)
        {
            if (ambientes != null)
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    ambientes.ListaAmbientes.ToList().ForEach(h => h.IdSolucion = ambientes.IdSolucion);

                    this.repositorioAmbientes.Eliminar(ambientes.IdSolucion);
                    this.repositorioAmbientes.Crear(ambientes);

                    transactionScope.Complete();
                }
            }
        }

        public IList<Ambientes> Consultar(Guid idSolucion, string lenguaje)
        {
            IList<Ambientes> listaAmbientes = repositorioAmbientes.Consultar(idSolucion, lenguaje);
            return listaAmbientes;
        }
    }
}

