namespace Varo.Consultorias.Negocio
{
    using Varo.Consultorias.Entidades;
    using Varo.Consultorias.Repositorio;
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

        public IList<CalificacionAuditoria> Obtener(Guid idConsultoria)
        {
            return this.repositorioAuditoria.Obtener(idConsultoria);
        }

        public CalificacionAuditoria ObtenerUltimaCalificacion(Guid idConsultoria)
        {
            return this.repositorioAuditoria.ObtenerUltimaCalificacion(idConsultoria);
        }

        public void Crear(CalificacionAuditoria auditoria)
        {
            if (auditoria != null)
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    auditoria.ListaCalificacionAuditorias.ToList().ForEach(c => c.IdConsultoria = auditoria.IdConsultoria);

                    this.repositorioAuditoria.Eliminar(auditoria.IdConsultoria);
                    this.repositorioAuditoria.Crear(auditoria);

                    transactionScope.Complete();
                }
            }
        }

        public void Editar(CalificacionAuditoria auditoria)
        {
            this.repositorioAuditoria.Editar(auditoria);
        }

        public void Eliminar(Guid idConsultoria)
        {
            this.repositorioAuditoria.Eliminar(idConsultoria);
        }
    }
}

