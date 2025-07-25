namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    public class RepositorioMetricaAgil : RepositorioBase, IRepositorioMetricaAgil
    {
        public IList<MetricasAgiles> Consultar(Guid idSolucion)
        {
            IList<MetricasAgiles> listaMetricasAgiles;
            MetricasAgiles metricasAgiles;
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspMetricasAgilesSelectPorIdSolucion"))
            {
                listaMetricasAgiles = new List<MetricasAgiles>();
                this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, idSolucion);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        metricasAgiles = new MetricasAgiles();

                        metricasAgiles.Id = dataReader.ToInt("Id");
                        metricasAgiles.IdSolucion = dataReader.ToGuid("IdSolucion");
                        metricasAgiles.Sprint = dataReader.ToString("Sprint");
                        metricasAgiles.FechaInicial = dataReader.ToDateTime("FechaInicial");
                        metricasAgiles.FechaFinal = dataReader.ToDateTime("FechaFinal");
                        metricasAgiles.IdEquipo = dataReader.ToGuid("IdEquipo");
                        metricasAgiles.NombreEquipo = dataReader.ToString("NombreEquipo");

                        listaMetricasAgiles.Add(metricasAgiles);
                    }
                }
            }
            return listaMetricasAgiles;

        }


        public void Crear(MetricasAgiles metricasAgiles)
        {
            if (metricasAgiles != null)
            {
                using (DbCommand command =
                    this.BaseDeDatos.GetStoredProcCommand("uspMetricasAgilesInsert"))
                {
                    this.BaseDeDatos.AddInParameter(command, "id", DbType.Int32, metricasAgiles.Id);
                    this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, metricasAgiles.IdSolucion);
                    this.BaseDeDatos.AddInParameter(command, "idEquipo", DbType.Guid, metricasAgiles.IdEquipo);
                    this.BaseDeDatos.AddInParameter(command, "sprint", DbType.String, metricasAgiles.Sprint);
                    this.BaseDeDatos.AddInParameter(command, "fechaInicial", DbType.DateTime, metricasAgiles.FechaInicial);
                    this.BaseDeDatos.AddInParameter(command, "fechaFinal", DbType.DateTime, metricasAgiles.FechaFinal);

                    this.BaseDeDatos.ExecuteNonQuery(command);
                }
            }
        }
        public void Actualizar(MetricasAgiles metricasAgiles)
        {
            if (metricasAgiles != null)
            {
                using (DbCommand command =
                    this.BaseDeDatos.GetStoredProcCommand("uspMetricasAgilesUpdate"))
                {
                    this.BaseDeDatos.AddInParameter(command, "id", DbType.Int32, metricasAgiles.Id);
                    this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, metricasAgiles.IdSolucion);
                    this.BaseDeDatos.AddInParameter(command, "idEquipo", DbType.Guid, metricasAgiles.IdEquipo);
                    this.BaseDeDatos.AddInParameter(command, "sprint", DbType.String, metricasAgiles.Sprint);
                    this.BaseDeDatos.AddInParameter(command, "fechaInicial", DbType.DateTime, metricasAgiles.FechaInicial);
                    this.BaseDeDatos.AddInParameter(command, "fechaFinal", DbType.DateTime, metricasAgiles.FechaFinal);

                    this.BaseDeDatos.ExecuteNonQuery(command);
                }
            }
        }
        public void Eliminar(int idMetricaAgil)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspMetricasAgilesDeletePorIdSolucion"))
            {
                this.BaseDeDatos.AddInParameter(command, "idMetricaAgil", DbType.Int32, idMetricaAgil);
                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }

        public IList<MetricasAgiles> ConsultarPorParametro(Guid idSolucion, string parametro)
        {
            IList<MetricasAgiles> listaMetricasAgiles;
            MetricasAgiles metricasAgiles;
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspMetricasAgilesSelectPorIdSolucionParam"))
            {
                listaMetricasAgiles = new List<MetricasAgiles>();
                this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, idSolucion);
                this.BaseDeDatos.AddInParameter(command, "ParametroBusqueda", DbType.String, parametro);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        metricasAgiles = new MetricasAgiles();

                        metricasAgiles.Id = dataReader.ToInt("Id");
                        metricasAgiles.IdSolucion = dataReader.ToGuid("IdSolucion");
                        metricasAgiles.Sprint = dataReader.ToString("Sprint");
                        metricasAgiles.FechaInicial = dataReader.ToDateTime("FechaInicial");
                        metricasAgiles.FechaFinal = dataReader.ToDateTime("FechaFinal");
                        metricasAgiles.IdEquipo = dataReader.ToGuid("IdEquipo");
                        metricasAgiles.NombreEquipo = dataReader.ToString("NombreEquipo");

                        listaMetricasAgiles.Add(metricasAgiles);
                    }
                }
            }
            return listaMetricasAgiles;

        }
    }
}

