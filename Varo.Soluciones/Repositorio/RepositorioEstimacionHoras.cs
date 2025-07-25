namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    public class RepositorioEstimacionHoras : RepositorioBase, IRepositorioEstimacionHoras
    {
        public void Crear(EstimacionHorasSolucion estimacionHorasSolucion)
        {
            if (estimacionHorasSolucion != null)
            {
                foreach (var itemEstimacionHoras in estimacionHorasSolucion.ListaEstimacionHorasSolucion)
                {
                    using (DbCommand command = this.BaseDeDatos.GetStoredProcCommand("uspEstimacionHorasSolucionInsert"))
                    {
                        this.BaseDeDatos.AddInParameter(command, "id", DbType.Guid, Guid.NewGuid());
                        this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, estimacionHorasSolucion.IdSolucion);
                        this.BaseDeDatos.AddInParameter(command, "concepto", DbType.String, itemEstimacionHoras.Concepto);
                        this.BaseDeDatos.AddInParameter(command, "horasEstimadas", DbType.Int32, itemEstimacionHoras.HorasEstimadas);
                        this.BaseDeDatos.AddInParameter(command, "horasEjecutadas", DbType.Int32, itemEstimacionHoras.HorasEjecutadas);

                        this.BaseDeDatos.ExecuteNonQuery(command);
                    }
                }
            }
        }

        public IList<EstimacionHorasSolucion> Consultar(Guid idSolucion)
        {
            IList<EstimacionHorasSolucion> listaEstimacionHorasSolucion = new List<EstimacionHorasSolucion>();
            using (DbCommand command = this.BaseDeDatos.GetStoredProcCommand("uspEstimacionHorasSolucionSelectPorId"))
            {
                this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, idSolucion);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    EstimacionHorasSolucion estimacionHorasSolucion = null;

                    while (dataReader.Read())
                    {
                        estimacionHorasSolucion = new EstimacionHorasSolucion();

                        estimacionHorasSolucion.Id = dataReader.ToGuid("Id");
                        estimacionHorasSolucion.Concepto = dataReader.ToString("Concepto");
                        estimacionHorasSolucion.HorasEstimadas = dataReader.ToInt("HorasEstimadas");
                        estimacionHorasSolucion.HorasEjecutadas = dataReader.ToInt("HorasEjecutadas");

                        listaEstimacionHorasSolucion.Add(estimacionHorasSolucion);
                    }
                }
            }
            return listaEstimacionHorasSolucion;
        }

        public void Eliminar(Guid idSolucion)
        {
            using (DbCommand command = this.BaseDeDatos.GetStoredProcCommand("uspEstimacionHorasSolucionDeletePorId"))
            {
                this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, idSolucion);
                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }


    }
}

