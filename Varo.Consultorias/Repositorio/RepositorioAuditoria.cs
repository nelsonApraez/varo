namespace Varo.Consultorias.Repositorio
{
    using Varo.Consultorias.Entidades;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    public class RepositorioAuditoria : RepositorioBase, IRepositorioAuditoria
    {
        public IList<CalificacionAuditoria> Obtener(Guid idConsultoria)
        {
            IList<CalificacionAuditoria> listaCalificacionAuditoria = new List<CalificacionAuditoria>();
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspAuditoriaConsultoriaSelectPorId"))
            {
                this.BaseDeDatos.AddInParameter(command, "idConsultoria", DbType.Guid, idConsultoria);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    CalificacionAuditoria calificacionAuditoria = null;

                    while (dataReader.Read())
                    {
                        calificacionAuditoria = new CalificacionAuditoria();

                        calificacionAuditoria.Id = dataReader.ToGuid("Id");
                        calificacionAuditoria.IdConsultoria = dataReader.ToGuid("IdConsultoria");
                        calificacionAuditoria.Url = dataReader.ToString("Url");
                        calificacionAuditoria.Calificacion = dataReader.ToDecimal("Calificacion");
                        calificacionAuditoria.Fecha = dataReader.ToDateTime("Fecha");
                        calificacionAuditoria.Proceso = dataReader.ToString("Proceso") ?? " ";
                        calificacionAuditoria.Observacion = dataReader.ToString("Observacion");
                        listaCalificacionAuditoria.Add(calificacionAuditoria);
                    }
                }
            }
            return listaCalificacionAuditoria;

        }

        public CalificacionAuditoria ObtenerUltimaCalificacion(Guid idConsultoria)
        {
            CalificacionAuditoria calificacionAuditoria = new CalificacionAuditoria();

            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspAuditoriaConsultoriaSelectUltimaCalificacionPorId"))
            {
                this.BaseDeDatos.AddInParameter(command, "idConsultoria", DbType.Guid, idConsultoria);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        calificacionAuditoria.Id = dataReader.ToGuid("Id");
                        calificacionAuditoria.IdConsultoria = dataReader.ToGuid("IdConsultoria");
                        calificacionAuditoria.Url = dataReader.ToString("Url");
                        calificacionAuditoria.Calificacion = dataReader.ToDecimal("Calificacion");
                        calificacionAuditoria.Fecha = dataReader.ToDateTime("Fecha");
                        calificacionAuditoria.Proceso = dataReader.ToString("Proceso");
                    }
                }
            }
            return calificacionAuditoria;

        }

        public void Crear(CalificacionAuditoria auditoria)
        {
            if (auditoria != null)
            {
                foreach (var itemAuditoria in auditoria.ListaCalificacionAuditorias)
                {
                    using (DbCommand command =
                        this.BaseDeDatos.GetStoredProcCommand("uspAuditoriaConsultoriaInsert"))
                    {
                        this.BaseDeDatos.AddInParameter(command, "idConsultoria", DbType.Guid, itemAuditoria.IdConsultoria);
                        this.BaseDeDatos.AddInParameter(command, "calificacionAuditoria", DbType.Decimal, itemAuditoria.Calificacion);
                        this.BaseDeDatos.AddInParameter(command, "urlAuditoria", DbType.String, itemAuditoria.Url);
                        this.BaseDeDatos.AddInParameter(command, "fechaAuditoria", DbType.DateTime, itemAuditoria.Fecha);
                        this.BaseDeDatos.AddInParameter(command, "procesoAuditoria", DbType.String, itemAuditoria.Proceso);
                        this.BaseDeDatos.AddInParameter(command, "observacion", DbType.String, itemAuditoria.Observacion);
                        this.BaseDeDatos.ExecuteNonQuery(command);
                    }
                }
            }


        }

        public void Editar(CalificacionAuditoria auditoria)
        {
            using (DbCommand command = this.BaseDeDatos.GetStoredProcCommand("uspAuditoriaConsultoriaUpdate"))
            {
                this.BaseDeDatos.AddInParameter(command, "idConsultoria", DbType.Guid, auditoria.IdConsultoria);
                this.BaseDeDatos.AddInParameter(command, "calificacionAuditoria", DbType.Decimal, auditoria.Calificacion);
                this.BaseDeDatos.AddInParameter(command, "urlAuditoria", DbType.String, auditoria.Url);
                this.BaseDeDatos.AddInParameter(command, "fechaAuditoria", DbType.DateTime, auditoria.Fecha);
                this.BaseDeDatos.AddInParameter(command, "procesoAuditoria", DbType.String, auditoria.Proceso);

                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }

        public void Eliminar(Guid idConsultoria)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspAuditoriaConsultoriaDeletePorId"))
            {
                this.BaseDeDatos.AddInParameter(command, "idConsultoria", DbType.Guid, idConsultoria);
                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }
    }
}

