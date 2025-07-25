namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Repositorio;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    public class RepositorioHistoria : RepositorioBase, IRepositorioHistoria
    {
        public IList<Historias> ObtenerPorMetricaAgil(int idMetricaAgil)
        {
            IList<Historias> listaHistorias;
            Historias historias;
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspHistoriasSelectPorIdMetricaAgil"))
            {
                listaHistorias = new List<Historias>();
                this.BaseDeDatos.AddInParameter(command, "IdMetricaAgil", DbType.Int32, idMetricaAgil);
                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        historias = new Historias();
                        historias.Id = dataReader.ToInt("Id");
                        historias.IdMetricaAgil = dataReader.ToInt("IdMetricaAgil");
                        historias.Numero = dataReader.ToString("Numero");
                        historias.Nombre = dataReader.ToString("Nombre");
                        historias.EsfuerzoEstimado = dataReader.ToDecimal("EsfuerzoEstimado");
                        historias.EsfuerzoReal = dataReader.ToDecimal("EsfuerzoReal");
                        historias.Observaciones = dataReader.ToString("Observaciones");
                        listaHistorias.Add(historias);
                    }
                }
            }
            return listaHistorias;
        }


        public void Crear(Historias historias)
        {
            if (historias != null)
            {
                foreach (var itemHistoria in historias.ListaHistorias)
                {
                    using (DbCommand command =
                    this.BaseDeDatos.GetStoredProcCommand("uspHistoriasInsert"))
                    {
                        this.BaseDeDatos.AddInParameter(command, "IdMetricaAgil", DbType.Int32, itemHistoria.IdMetricaAgil);
                        this.BaseDeDatos.AddInParameter(command, "Numero", DbType.String, itemHistoria.Numero);
                        this.BaseDeDatos.AddInParameter(command, "Nombre", DbType.String, itemHistoria.Nombre);
                        this.BaseDeDatos.AddInParameter(command, "EsfuerzoEstimado", DbType.Decimal, itemHistoria.EsfuerzoEstimado);
                        this.BaseDeDatos.AddInParameter(command, "EsfuerzoReal", DbType.Decimal, itemHistoria.EsfuerzoReal);
                        this.BaseDeDatos.AddInParameter(command, "Observaciones", DbType.String, itemHistoria.Observaciones);

                        this.BaseDeDatos.ExecuteNonQuery(command);
                    }
                }
            }
        }

        public void Eliminar(int idMetricaAgil)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspHistoriasDeletePorId"))
            {
                this.BaseDeDatos.AddInParameter(command, "IdMetricaAgil", DbType.Int32, idMetricaAgil);
                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }
    }
}

