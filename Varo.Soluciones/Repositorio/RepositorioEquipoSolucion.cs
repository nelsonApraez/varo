
namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    public class RepositorioEquipoSolucion : RepositorioBase, IRepositorioEquipoSolucion
    {
        public IList<EquipoSolucion> Consultar(Guid idSolucion)
        {
            IList<EquipoSolucion> listaEquipoSolucion = new List<EquipoSolucion>();
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspEquiposSolucionesSelectPorIdSolucion"))
            {
                this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, idSolucion);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    EquipoSolucion equipoSolucion = null;

                    while (dataReader.Read())
                    {
                        equipoSolucion = new EquipoSolucion();

                        equipoSolucion.IdSolucion = dataReader.ToGuid("IdSolucion");
                        equipoSolucion.Id = dataReader.ToGuid("Id");
                        equipoSolucion.Nombre = dataReader.ToString("Nombre");

                        listaEquipoSolucion.Add(equipoSolucion);
                    }
                }
            }
            return listaEquipoSolucion;
        }

        public void Crear(EquipoSolucion equipoSolucion)
        {
            if (equipoSolucion != null)
            {
                using (DbCommand command =
                        this.BaseDeDatos.GetStoredProcCommand("uspEquiposSolucionesInsert"))
                {
                    this.BaseDeDatos.AddInParameter(command, "id", DbType.Guid, Guid.NewGuid());
                    this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, equipoSolucion.IdSolucion);
                    this.BaseDeDatos.AddInParameter(command, "nombre", DbType.String, equipoSolucion.Nombre);

                    this.BaseDeDatos.ExecuteNonQuery(command);
                }
            }
        }

        public void Editar(EquipoSolucion equipoSolucion)
        {
            if (equipoSolucion != null)
            {
                using (DbCommand command =
                        this.BaseDeDatos.GetStoredProcCommand("uspEquiposSolucionesUpdate"))
                {
                    this.BaseDeDatos.AddInParameter(command, "id", DbType.Guid, equipoSolucion.Id);
                    this.BaseDeDatos.AddInParameter(command, "nombre", DbType.String, equipoSolucion.Nombre);

                    this.BaseDeDatos.ExecuteNonQuery(command);
                }
            }
        }

        public void Eliminar(Guid idEquipo)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspEquiposSolucionesDeletePorIdEquipo"))
            {
                this.BaseDeDatos.AddInParameter(command, "idEquipo", DbType.Guid, idEquipo);
                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }

        public void EliminarPorIdSolucion(Guid idSolucion)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspEquiposSolucionesDeletePorIdSolucion"))
            {
                this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, idSolucion);
                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }

        public IList<MetricasAgiles> ConsultarMetricaPorIdEquipo(Guid idEquipo)
        {
            IList<MetricasAgiles> listaMetrica = new List<MetricasAgiles>();
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspMetricasAgilesSelectPorIdEquipo"))
            {
                this.BaseDeDatos.AddInParameter(command, "idEquipo", DbType.Guid, idEquipo);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    MetricasAgiles metrica = null;

                    while (dataReader.Read())
                    {
                        metrica = new MetricasAgiles();
                        metrica.Id = dataReader.ToInt("Id");
                        metrica.Sprint = dataReader.ToString("Sprint");

                        listaMetrica.Add(metrica);
                    }
                }
            }
            return listaMetrica;
        }
    }
}

