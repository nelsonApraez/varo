namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Globalization;

    public class RepositorioIntegracionContinua : RepositorioBase, IRepositorioIntegracionContinua
    {
        public void Crear(IntegracionesContinuas integracionContinua)
        {
            if (integracionContinua != null)
            {
                foreach (var itemIntegracionContinua in integracionContinua.ListaIntegracionesContinuas)
                {
                    using (DbCommand command =
                        this.BaseDeDatos.GetStoredProcCommand("uspIntegracionesContinuasInsert"))
                    {
                        this.BaseDeDatos.AddInParameter(command, "id", DbType.Guid, Guid.NewGuid());
                        this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, itemIntegracionContinua.IdSolucion);
                        this.BaseDeDatos.AddInParameter(command, "nombre", DbType.String, itemIntegracionContinua.Nombre);
                        this.BaseDeDatos.AddInParameter(command, "urlCompilacion", DbType.String, itemIntegracionContinua.UrlCompilacion.ToString(CultureInfo.CurrentCulture));
                        this.BaseDeDatos.AddInParameter(command, "idProyectoInspeccion", DbType.Int32, itemIntegracionContinua.IdProyectoInspeccion);

                        this.BaseDeDatos.ExecuteNonQuery(command);
                    }
                }
            }
        }

        public void EliminarPorIdSolucion(Guid idSolucion)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspIntegracionesContinuasDeletePorIdSolucion"))
            {
                this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, idSolucion);
                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }

        public IList<IntegracionesContinuas> ConsultarPorIdSolucion(Guid idSolucion)
        {
            IList<IntegracionesContinuas> listaIntegracionesContinuas = new List<IntegracionesContinuas>();
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspIntegracionesContinuasSelectPorIdSolucion"))
            {
                this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, idSolucion);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    IntegracionesContinuas integracionesContinuas = null;

                    while (dataReader.Read())
                    {
                        integracionesContinuas = new IntegracionesContinuas();

                        integracionesContinuas.Id = dataReader.ToGuid("Id");
                        integracionesContinuas.IdSolucion = dataReader.ToGuid("IdSolucion");
                        integracionesContinuas.Nombre = dataReader.ToString("Nombre");
                        integracionesContinuas.UrlCompilacion = dataReader.ToString("UrlCompilacion");
                        integracionesContinuas.IdProyectoInspeccion = dataReader.ToInt("IdProyectoInspeccion");

                        listaIntegracionesContinuas.Add(integracionesContinuas);
                    }
                }
            }
            return listaIntegracionesContinuas;
        }
    }
}

