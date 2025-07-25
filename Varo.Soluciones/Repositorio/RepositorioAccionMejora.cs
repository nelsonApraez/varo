namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Constantes;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    public class RepositorioAccionMejora : RepositorioBase, IRepositorioAccionMejora
    {
        public IList<AccionesMejora> ObtenerPorMetricaAgil(int idMetricaAgil, string lenguaje)
        {
            IList<AccionesMejora> ListaAccionesMejora = new List<AccionesMejora>();
            AccionesMejora AccionesMejora;
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspAccionesMejoraSelectPorIdMetricaAgil"))
            {
                this.BaseDeDatos.AddInParameter(command, "IdMetricaAgil", DbType.Int32, idMetricaAgil);
                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        AccionesMejora = new AccionesMejora();
                        AccionesMejora.Id = dataReader.ToInt("Id");
                        AccionesMejora.IdMetricaAgil = dataReader.ToInt("IdMetricaAgil");
                        AccionesMejora.Accion = dataReader.ToString("Accion");
                        AccionesMejora.Causa = dataReader.ToString("Causa");
                        AccionesMejora.Responsable.Id = dataReader.ToByte("IdResponsable");
                        AccionesMejora.Estado.Id = dataReader.ToByte("IdEstado");
                        if (lenguaje == TransversalesConstantes.Espanol)
                        {
                            AccionesMejora.Responsable.Nombre = dataReader.ToString("NombreResponsable");
                            AccionesMejora.Estado.Nombre = dataReader.ToString("NombreEstado");
                        }
                        else
                        {
                            AccionesMejora.Responsable.Nombre = dataReader.ToString("NombreResponsableEN");
                            AccionesMejora.Estado.Nombre = dataReader.ToString("NombreEstadoEN");
                        }
                        ListaAccionesMejora.Add(AccionesMejora);
                    }
                }
            }
            return ListaAccionesMejora;
        }

        public IList<AccionesMejora> ObtenerPorMetricaAgil(int idMetricaAgil)
        {
            return ObtenerPorMetricaAgil(idMetricaAgil, TransversalesConstantes.Espanol);
        }
        public IList<AccionesMejora> ConsultarPorSolucion(Guid idSolucion, string lenguaje)
        {
            IList<AccionesMejora> ListaAccionesMejora = new List<AccionesMejora>();
            AccionesMejora AccionesMejora;
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspAccionesMejoraSelectPorIdSolucion"))
            {
                this.BaseDeDatos.AddInParameter(command, "IdSolucion", DbType.Guid, idSolucion);
                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        AccionesMejora = new AccionesMejora();
                        AccionesMejora.Id = dataReader.ToInt("Id");
                        AccionesMejora.IdSolucion = dataReader.ToGuid("IdSolucion");
                        AccionesMejora.Sprint = dataReader.ToString("Sprint");
                        AccionesMejora.Accion = dataReader.ToString("Accion");
                        AccionesMejora.Causa = dataReader.ToString("Causa");
                        AccionesMejora.Responsable.Id = dataReader.ToByte("IdResponsable");
                        if (lenguaje == TransversalesConstantes.Espanol)
                        {
                            AccionesMejora.Responsable.Nombre = dataReader.ToString("NombreResponsable");
                            AccionesMejora.Estado.Nombre = dataReader.ToString("NombreEstado");
                        }
                        else
                        {
                            AccionesMejora.Responsable.Nombre = dataReader.ToString("NombreResponsableEN");
                            AccionesMejora.Estado.Nombre = dataReader.ToString("NombreEstadoEN");
                        }

                        AccionesMejora.Estado.Id = dataReader.ToByte("IdEstado");
                        ListaAccionesMejora.Add(AccionesMejora);
                    }
                }
            }
            return ListaAccionesMejora;
        }

        public void Crear(AccionesMejora accionesMejora)
        {
            if (accionesMejora != null)
            {

                using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspAccionesMejoraInsert"))
                {
                    this.BaseDeDatos.AddInParameter(command, "IdMetricaAgil", DbType.Int32, accionesMejora.IdMetricaAgil);
                    this.BaseDeDatos.AddInParameter(command, "Accion", DbType.String, accionesMejora.Accion);
                    this.BaseDeDatos.AddInParameter(command, "Causa", DbType.String, accionesMejora.Causa);
                    this.BaseDeDatos.AddInParameter(command, "IdResponsable", DbType.Int32, accionesMejora.Responsable.Id);
                    this.BaseDeDatos.AddInParameter(command, "IdEstado", DbType.Int32, accionesMejora.Estado.Id);

                    this.BaseDeDatos.ExecuteNonQuery(command);
                }

            }
        }
        public void Editar(AccionesMejora accionesMejora)
        {
            if (accionesMejora != null)
            {
                using (DbCommand command =
                    this.BaseDeDatos.GetStoredProcCommand("uspAccionesMejoraUpdate"))
                {
                    this.BaseDeDatos.AddInParameter(command, "Id", DbType.Int32, accionesMejora.Id);
                    this.BaseDeDatos.AddInParameter(command, "Accion", DbType.String, accionesMejora.Accion);
                    this.BaseDeDatos.AddInParameter(command, "Causa", DbType.String, accionesMejora.Causa);
                    this.BaseDeDatos.AddInParameter(command, "IdResponsable", DbType.Int32, accionesMejora.Responsable.Id);
                    this.BaseDeDatos.AddInParameter(command, "IdEstado", DbType.Int32, accionesMejora.Estado.Id);

                    this.BaseDeDatos.ExecuteNonQuery(command);
                }
            }
        }

        public void Eliminar(int idAccionMejora)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspAccionesMejoraDeletePorId"))
            {
                this.BaseDeDatos.AddInParameter(command, "id", DbType.Int32, idAccionMejora);

                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }

        public IList<AccionesMejora> ConsultarPorSolucionParametroBusqueda(Guid idSolucion, string parametro, string lenguaje)
        {
            IList<AccionesMejora> ListaAccionesMejora = new List<AccionesMejora>();
            AccionesMejora AccionesMejora;
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspAccionesMejoraSelectPorIdSolucionParam"))
            {
                this.BaseDeDatos.AddInParameter(command, "IdSolucion", DbType.Guid, idSolucion);
                this.BaseDeDatos.AddInParameter(command, "ParametroBusqueda", DbType.String, parametro);
                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        AccionesMejora = new AccionesMejora();
                        AccionesMejora.Id = dataReader.ToInt("Id");
                        AccionesMejora.IdSolucion = dataReader.ToGuid("IdSolucion");
                        AccionesMejora.Sprint = dataReader.ToString("Sprint");
                        AccionesMejora.Accion = dataReader.ToString("Accion");
                        AccionesMejora.Causa = dataReader.ToString("Causa");
                        AccionesMejora.Responsable.Id = dataReader.ToByte("IdResponsable");
                        if (lenguaje == TransversalesConstantes.Espanol)
                        {
                            AccionesMejora.Responsable.Nombre = dataReader.ToString("NombreResponsable");
                            AccionesMejora.Estado.Nombre = dataReader.ToString("NombreEstado");
                        }
                        else
                        {
                            AccionesMejora.Responsable.Nombre = dataReader.ToString("NombreResponsableEN");
                            AccionesMejora.Estado.Nombre = dataReader.ToString("NombreEstadoEN");
                        }

                        AccionesMejora.Estado.Id = dataReader.ToByte("IdEstado");
                        ListaAccionesMejora.Add(AccionesMejora);
                    }
                }
            }
            return ListaAccionesMejora;
        }
    }
}

