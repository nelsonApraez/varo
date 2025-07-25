namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Repositorio;
    using System.Data;
    using System.Data.Common;

    public class RepositorioDefectoInterno : RepositorioBase, IRepositorioDefectoInterno
    {
        public DefectosInternos ObtenerPorMetricaAgil(int idMetricaAgil)
        {
            DefectosInternos defectosInternos;
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspDefectosInternosSelectPorIdMetricaAgil"))
            {
                defectosInternos = new DefectosInternos();
                this.BaseDeDatos.AddInParameter(command, "IdMetricaAgil", DbType.Int32, idMetricaAgil);
                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        defectosInternos.Id = dataReader.ToInt("Id");
                        defectosInternos.IdMetricaAgil = dataReader.ToInt("IdMetricaAgil");
                        defectosInternos.Reportados = dataReader.ToInt("Reportados");
                        defectosInternos.Cerrados = dataReader.ToInt("Cerrados");
                        defectosInternos.Actuales = dataReader.ToInt("Actuales");
                        defectosInternos.Abiertos = dataReader.ToInt("Abiertos");
                        defectosInternos.Observaciones = dataReader.ToString("Observaciones");
                    }
                }
            }
            return defectosInternos;
        }


        public void Crear(DefectosInternos defectosInternos)
        {
            if (defectosInternos != null)
            {
                using (DbCommand command =
                    this.BaseDeDatos.GetStoredProcCommand("uspDefectosInternosInsert"))
                {
                    this.BaseDeDatos.AddInParameter(command, "IdMetricaAgil", DbType.Int32, defectosInternos.IdMetricaAgil);
                    this.BaseDeDatos.AddInParameter(command, "Reportados", DbType.Int32, defectosInternos.Reportados);
                    this.BaseDeDatos.AddInParameter(command, "Cerrados", DbType.Int32, defectosInternos.Cerrados);
                    this.BaseDeDatos.AddInParameter(command, "Actuales", DbType.Int32, defectosInternos.Actuales);
                    this.BaseDeDatos.AddInParameter(command, "Abiertos", DbType.Int32, defectosInternos.Abiertos);
                    this.BaseDeDatos.AddInParameter(command, "Observaciones", DbType.String, defectosInternos.Observaciones);

                    this.BaseDeDatos.ExecuteNonQuery(command);
                }
            }


        }

        public void Eliminar(int idMetricaAgil)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspDefectosInternosDeletePorId"))
            {
                this.BaseDeDatos.AddInParameter(command, "idMetricaAgil", DbType.Int32, idMetricaAgil);

                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }
    }
}

