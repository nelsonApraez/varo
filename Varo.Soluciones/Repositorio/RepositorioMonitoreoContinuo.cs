namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Globalization;

    public class RepositorioMonitoreoContinuo : RepositorioBase, IRepositorioMonitoreoContinuo
    {
        public void Crear(MonitoreosContinuos monitoreoContinuo)
        {
            if (monitoreoContinuo != null)
            {
                foreach (var itemMonitoreoContinuo in monitoreoContinuo.ListaMonitoreosContinuos)
                {
                    using (DbCommand command =
                        this.BaseDeDatos.GetStoredProcCommand("uspMonitoreoContinuoInsert"))
                    {
                        this.BaseDeDatos.AddInParameter(command, "id", DbType.Guid, Guid.NewGuid());
                        this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, itemMonitoreoContinuo.IdSolucion);
                        this.BaseDeDatos.AddInParameter(command, "nombre", DbType.String, itemMonitoreoContinuo.Nombre);
                        this.BaseDeDatos.AddInParameter(command, "UrlMonitoreo", DbType.String, itemMonitoreoContinuo.UrlMonitoreo.ToString(CultureInfo.CurrentCulture) ?? "");

                        this.BaseDeDatos.ExecuteNonQuery(command);
                    }
                }
            }
        }

        public void EliminarPorIdSolucion(Guid idSolucion)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspMonitoreoContinuoDeletePorIdSolucion"))
            {
                this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, idSolucion);
                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }

        public IList<MonitoreosContinuos> ConsultarPorIdSolucion(Guid idSolucion)
        {
            IList<MonitoreosContinuos> listaMonitoreoContinuo = new List<MonitoreosContinuos>();
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspMonitoreoContinuoSelectPorIdSolucion"))
            {
                this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, idSolucion);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    MonitoreosContinuos MonitoreoContinuo = null;

                    while (dataReader.Read())
                    {
                        MonitoreoContinuo = new MonitoreosContinuos();

                        MonitoreoContinuo.Id = dataReader.ToGuid("Id");
                        MonitoreoContinuo.Nombre = dataReader.ToString("Nombre");
                        if (dataReader.ToString("UrlMonitoreo") != "")
                        {
                            MonitoreoContinuo.UrlMonitoreo = dataReader.ToString("UrlMonitoreo");
                        }

                        listaMonitoreoContinuo.Add(MonitoreoContinuo);
                    }
                }
            }
            return listaMonitoreoContinuo;
        }
    }
}

