namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Repositorio;
    using System.Data;
    using System.Data.Common;

    public class RepositorioCalidadCodigo : RepositorioBase, IRepositorioCalidadCodigo
    {
        public CalidadCodigo ObtenerPorMetricaAgil(int idMetricaAgil)
        {
            CalidadCodigo CalidadCodigo;
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspCalidadCodigoSelectPorIdMetricaAgil"))
            {
                CalidadCodigo = new CalidadCodigo();
                this.BaseDeDatos.AddInParameter(command, "IdMetricaAgil", DbType.Int32, idMetricaAgil);
                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        CalidadCodigo.Id = dataReader.ToInt("Id");
                        CalidadCodigo.IdMetricaAgil = dataReader.ToInt("IdMetricaAgil");
                        CalidadCodigo.Bugs = dataReader.ToInt("Bugs");
                        CalidadCodigo.Vulnerabilidades = dataReader.ToInt("Vulnerabilidades");
                        CalidadCodigo.DeudaTecnica = dataReader.ToDecimal("DeudaTecnica");
                        CalidadCodigo.Cobertura = dataReader.ToDecimal("Cobertura");
                        CalidadCodigo.Duplicado = dataReader.ToDecimal("Duplicado");
                        CalidadCodigo.Observaciones = dataReader.ToString("Observaciones");
                    }
                }
            }
            return CalidadCodigo;
        }


        public void Crear(CalidadCodigo calidadCodigo)
        {
            if (calidadCodigo != null)
            {
                using (DbCommand command =
                    this.BaseDeDatos.GetStoredProcCommand("uspCalidadCodigoInsert"))
                {
                    this.BaseDeDatos.AddInParameter(command, "IdMetricaAgil", DbType.Int32, calidadCodigo.IdMetricaAgil);
                    this.BaseDeDatos.AddInParameter(command, "Bugs", DbType.Int32, calidadCodigo.Bugs);
                    this.BaseDeDatos.AddInParameter(command, "Vulnerabilidades", DbType.Int32, calidadCodigo.Vulnerabilidades);
                    this.BaseDeDatos.AddInParameter(command, "DeudaTecnica", DbType.Decimal, calidadCodigo.DeudaTecnica);
                    this.BaseDeDatos.AddInParameter(command, "Cobertura", DbType.Decimal, calidadCodigo.Cobertura);
                    this.BaseDeDatos.AddInParameter(command, "Duplicado", DbType.Decimal, calidadCodigo.Duplicado);
                    this.BaseDeDatos.AddInParameter(command, "Observaciones", DbType.String, calidadCodigo.Observaciones);

                    this.BaseDeDatos.ExecuteNonQuery(command);
                }
            }


        }

        public void Eliminar(int idMetricaAgil)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspCalidadCodigoDeletePorId"))
            {
                this.BaseDeDatos.AddInParameter(command, "idMetricaAgil", DbType.Int32, idMetricaAgil);

                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }
    }
}

