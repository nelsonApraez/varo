namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Repositorio;
    using System.Data;
    using System.Data.Common;

    public class RepositorioHistoriayEsfuerzo : RepositorioBase, IRepositorioHistoriayEsfuerzo
    {
        public HistoriasyEsfuerzos ObtenerPorMetricaAgil(int idMetricaAgil)
        {
            HistoriasyEsfuerzos historiasyEsfuerzos;
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspHistoriasyEsfuerzosSelectPorIdMetricaAgil"))
            {
                historiasyEsfuerzos = new HistoriasyEsfuerzos();
                this.BaseDeDatos.AddInParameter(command, "IdMetricaAgil", DbType.Int32, idMetricaAgil);
                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        historiasyEsfuerzos.Id = dataReader.ToInt("Id");
                        historiasyEsfuerzos.IdMetricaAgil = dataReader.ToInt("IdMetricaAgil");
                        historiasyEsfuerzos.HistoriasEstimadas = dataReader.ToInt("HistoriasEstimadas");
                        historiasyEsfuerzos.HistoriasLogradas = dataReader.ToInt("HistoriasLogradas");
                        historiasyEsfuerzos.EsfuerzoEstimado = dataReader.ToDecimal("EsfuerzoEstimado");
                        historiasyEsfuerzos.EsfuerzoLogrado = dataReader.ToDecimal("EsfuerzoLogrado");
                        historiasyEsfuerzos.Observaciones = dataReader.ToString("Observaciones");
                    }
                }
            }
            return historiasyEsfuerzos;
        }


        public void Crear(HistoriasyEsfuerzos historiayEsfuerzo)
        {
            if (historiayEsfuerzo != null)
            {
                using (DbCommand command =
                    this.BaseDeDatos.GetStoredProcCommand("uspHistoriasyEsfuerzosInsert"))
                {
                    this.BaseDeDatos.AddInParameter(command, "IdMetricaAgil", DbType.Int32, historiayEsfuerzo.IdMetricaAgil);
                    this.BaseDeDatos.AddInParameter(command, "HistoriasEstimadas", DbType.Int32, historiayEsfuerzo.HistoriasEstimadas);
                    this.BaseDeDatos.AddInParameter(command, "HistoriasLogradas", DbType.Int32, historiayEsfuerzo.HistoriasLogradas);
                    this.BaseDeDatos.AddInParameter(command, "EsfuerzoEstimado", DbType.Decimal, historiayEsfuerzo.EsfuerzoEstimado);
                    this.BaseDeDatos.AddInParameter(command, "EsfuerzoLogrado", DbType.Decimal, historiayEsfuerzo.EsfuerzoLogrado);
                    this.BaseDeDatos.AddInParameter(command, "Observaciones", DbType.String, historiayEsfuerzo.Observaciones);

                    this.BaseDeDatos.ExecuteNonQuery(command);
                }
            }


        }

        public void Eliminar(int idMetricaAgil)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspHistoriasyEsfuerzosDeletePorId"))
            {
                this.BaseDeDatos.AddInParameter(command, "idMetricaAgil", DbType.Int32, idMetricaAgil);

                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }
    }
}

