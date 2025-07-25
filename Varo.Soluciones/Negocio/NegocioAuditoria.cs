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

    public class NegocioAuditoria : NegocioBase, INegocioAuditoria
    {
        private readonly IRepositorioAuditoria repositorioAuditoria;

        public NegocioAuditoria() : this(new RepositorioBase(), new RepositorioAuditoria())
        { }

        public NegocioAuditoria(IRepositorioBase repositorioBase,
                                IRepositorioAuditoria repositorioAuditoria) : base(repositorioBase)
        {
            this.repositorioAuditoria = repositorioAuditoria;
        }

        public IList<CalificacionAuditoria> Obtener(Guid idSolucion)
        {
            return this.repositorioAuditoria.Obtener(idSolucion);
        }

        public CalificacionAuditoria ObtenerUltimaCalificacion(Guid idSolucion)
        {
            return this.repositorioAuditoria.ObtenerUltimaCalificacion(idSolucion);
        }

        public void Crear(CalificacionAuditoria auditoria)
        {
            if (auditoria != null)
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    this.repositorioAuditoria.Crear(auditoria);

                    transactionScope.Complete();
                }
            }
        }

        public void Actualizar(CalificacionAuditoria auditoria)
        {
            if (auditoria != null)
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    auditoria.ListaCalificacionAuditorias.ToList().ForEach(c => c.IdSolucion = auditoria.IdSolucion);

                    this.repositorioAuditoria.Eliminar(auditoria.IdSolucion);
                    this.repositorioAuditoria.Crear(auditoria);

                    transactionScope.Complete();
                }
            }
        }

        public void Editar(CalificacionAuditoria auditoria)
        {
            this.repositorioAuditoria.Editar(auditoria);
        }

        public void Eliminar(Guid idSolucion)
        {
            this.repositorioAuditoria.Eliminar(idSolucion);
        }
    }
}

