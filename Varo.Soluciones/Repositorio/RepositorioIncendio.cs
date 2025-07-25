namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Repositorio;
    using System.Data;
    using System.Data.Common;

    public class RepositorioIncendio : RepositorioBase, IRepositorioIncendio
    {
        public Incendios ObtenerPorMetricaAgil(int idMetricaAgil)
        {
            Incendios incendios;
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspIncendiosSelectPorIdMetricaAgil"))
            {
                incendios = new Incendios();
                this.BaseDeDatos.AddInParameter(command, "IdMetricaAgil", DbType.Int32, idMetricaAgil);
                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        incendios.Id = dataReader.ToInt("Id");
                        incendios.IdMetricaAgil = dataReader.ToInt("IdMetricaAgil");
                        incendios.Reportados = dataReader.ToInt("Reportados");
                        incendios.Solucionados = dataReader.ToInt("Solucionados");
                        incendios.Observaciones = dataReader.ToString("Observaciones");
                    }
                }
            }
            return incendios;
        }


        public void Crear(Incendios incendios)
        {
            if (incendios != null)
            {
                using (DbCommand command =
                    this.BaseDeDatos.GetStoredProcCommand("uspIncendiosInsert"))
                {
                    this.BaseDeDatos.AddInParameter(command, "IdMetricaAgil", DbType.Int32, incendios.IdMetricaAgil);
                    this.BaseDeDatos.AddInParameter(command, "Reportados", DbType.Int32, incendios.Reportados);
                    this.BaseDeDatos.AddInParameter(command, "Solucionados", DbType.Int32, incendios.Solucionados);
                    this.BaseDeDatos.AddInParameter(command, "Observaciones", DbType.String, incendios.Observaciones);

                    this.BaseDeDatos.ExecuteNonQuery(command);
                }
            }
        }

        public void Eliminar(int idMetricaAgil)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspIncendiosDeletePorId"))
            {
                this.BaseDeDatos.AddInParameter(command, "idMetricaAgil", DbType.Int32, idMetricaAgil);

                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }
    }
}

