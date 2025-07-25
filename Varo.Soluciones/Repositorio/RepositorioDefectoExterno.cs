namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Repositorio;
    using System.Data;
    using System.Data.Common;

    public class RepositorioDefectoExterno : RepositorioBase, IRepositorioDefectoExterno
    {
        public DefectosExternos ObtenerPorMetricaAgil(int idMetricaAgil)
        {
            DefectosExternos defectosExternos;
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspDefectosExternosSelectPorIdMetricaAgil"))
            {
                defectosExternos = new DefectosExternos();
                this.BaseDeDatos.AddInParameter(command, "IdMetricaAgil", DbType.Int32, idMetricaAgil);
                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        defectosExternos.Id = dataReader.ToInt("Id");
                        defectosExternos.IdMetricaAgil = dataReader.ToInt("IdMetricaAgil");
                        defectosExternos.Reportados = dataReader.ToInt("Reportados");
                        defectosExternos.Cerrados = dataReader.ToInt("Cerrados");
                        defectosExternos.Actuales = dataReader.ToInt("Actuales");
                        defectosExternos.Abiertos = dataReader.ToInt("Abiertos");
                        defectosExternos.Densidad = dataReader.ToDecimal("Densidad");
                        defectosExternos.Observaciones = dataReader.ToString("Observaciones");
                    }
                }
            }
            return defectosExternos;
        }


        public void Crear(DefectosExternos defectosExternos)
        {
            if (defectosExternos != null)
            {
                using (DbCommand command =
                    this.BaseDeDatos.GetStoredProcCommand("uspDefectosExternosInsert"))
                {
                    this.BaseDeDatos.AddInParameter(command, "IdMetricaAgil", DbType.Int32, defectosExternos.IdMetricaAgil);
                    this.BaseDeDatos.AddInParameter(command, "Reportados", DbType.Int32, defectosExternos.Reportados);
                    this.BaseDeDatos.AddInParameter(command, "Cerrados", DbType.Int32, defectosExternos.Cerrados);
                    this.BaseDeDatos.AddInParameter(command, "Actuales", DbType.Int32, defectosExternos.Actuales);
                    this.BaseDeDatos.AddInParameter(command, "Abiertos", DbType.Int32, defectosExternos.Abiertos);
                    this.BaseDeDatos.AddInParameter(command, "Densidad", DbType.Decimal, defectosExternos.Densidad);
                    this.BaseDeDatos.AddInParameter(command, "Observaciones", DbType.String, defectosExternos.Observaciones);

                    this.BaseDeDatos.ExecuteNonQuery(command);
                }
            }


        }

        public void Eliminar(int idMetricaAgil)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspDefectosExternosDeletePorId"))
            {
                this.BaseDeDatos.AddInParameter(command, "idMetricaAgil", DbType.Int32, idMetricaAgil);

                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }
    }
}

