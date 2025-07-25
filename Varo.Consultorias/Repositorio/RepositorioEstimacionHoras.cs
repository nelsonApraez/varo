namespace Varo.Consultorias.Repositorio
{
    using Varo.Consultorias.Entidades;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    public class RepositorioEstimacionHoras : RepositorioBase, IRepositorioEstimacionHoras
    {
        public void Crear(EstimacionHorasConsultoria estimacionHorasConsultoria)
        {
            if (estimacionHorasConsultoria != null)
            {
                foreach (var itemEstimacionHoras in estimacionHorasConsultoria.ListaEstimacionHorasConsultoria)
                {
                    using (DbCommand command = this.BaseDeDatos.GetStoredProcCommand("uspEstimacionHorasConsultoriaInsert"))
                    {
                        this.BaseDeDatos.AddInParameter(command, "id", DbType.Guid, Guid.NewGuid());
                        this.BaseDeDatos.AddInParameter(command, "idConsultoria", DbType.Guid, estimacionHorasConsultoria.IdConsultoria);
                        this.BaseDeDatos.AddInParameter(command, "concepto", DbType.String, itemEstimacionHoras.Concepto);
                        this.BaseDeDatos.AddInParameter(command, "horasEstimadas", DbType.Int32, itemEstimacionHoras.HorasEstimadas);
                        this.BaseDeDatos.AddInParameter(command, "horasEjecutadas", DbType.Int32, itemEstimacionHoras.HorasEjecutadas);

                        this.BaseDeDatos.ExecuteNonQuery(command);
                    }
                }
            }
        }

        public void Eliminar(Guid idConsultoria)
        {
            using (DbCommand command = this.BaseDeDatos.GetStoredProcCommand("uspEstimacionHorasConsultoriaDeletePorId"))
            {
                this.BaseDeDatos.AddInParameter(command, "idConsultoria", DbType.Guid, idConsultoria);
                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }

        public IList<EstimacionHorasConsultoria> Consultar(Guid idConsultoria)
        {
            IList<EstimacionHorasConsultoria> listaEstimacionHorasConsultoria = new List<EstimacionHorasConsultoria>();
            using (DbCommand command = this.BaseDeDatos.GetStoredProcCommand("uspEstimacionHorasConsultoriaSelectPorId"))
            {
                this.BaseDeDatos.AddInParameter(command, "idConsultoria", DbType.Guid, idConsultoria);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    EstimacionHorasConsultoria estimacionHorasConsultoria = null;

                    while (dataReader.Read())
                    {
                        estimacionHorasConsultoria = new EstimacionHorasConsultoria
                        {
                            Id = dataReader.ToGuid("Id"),
                            Concepto = dataReader.ToString("Concepto"),
                            HorasEstimadas = dataReader.ToInt("HorasEstimadas"),
                            HorasEjecutadas = dataReader.ToInt("HorasEjecutadas")
                        };

                        listaEstimacionHorasConsultoria.Add(estimacionHorasConsultoria);
                    }
                }
            }
            return listaEstimacionHorasConsultoria;
        }
    }
}

