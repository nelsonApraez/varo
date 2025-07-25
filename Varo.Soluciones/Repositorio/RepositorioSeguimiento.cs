namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Repositorio;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    public class RepositorioSeguimiento : RepositorioBase, IRepositorioSeguimiento
    {
        public IList<Seguimiento> Consultar(int idAccionesMejora)
        {
            IList<Seguimiento> listaSeguimiento;
            Seguimiento seguimiento;
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspSeguimientoSelectPorIdAccionesMejora"))
            {
                listaSeguimiento = new List<Seguimiento>();
                this.BaseDeDatos.AddInParameter(command, "IdAccionesMejora", DbType.Int32, idAccionesMejora);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        seguimiento = new Seguimiento();
                        seguimiento.Id = dataReader.ToInt("Id");
                        seguimiento.IdAccionesMejora = dataReader.ToInt("IdAccionesMejora");
                        seguimiento.Observacion = dataReader.ToString("Observacion");
                        seguimiento.Fecha = dataReader.ToDateTime("Fecha");
                        seguimiento.Usuario = dataReader.ToString("Usuario");

                        listaSeguimiento.Add(seguimiento);
                    }
                }
            }
            return listaSeguimiento;

        }


        public void Crear(Seguimiento seguimiento)
        {
            if (seguimiento != null)
            {
                foreach (var itemSeguimiento in seguimiento.ListaSeguimiento)
                {
                    using (DbCommand command =
                        this.BaseDeDatos.GetStoredProcCommand("uspSeguimientoInsert"))
                    {
                        this.BaseDeDatos.AddInParameter(command, "idAccionesMejora", DbType.Int32, itemSeguimiento.IdAccionesMejora);
                        this.BaseDeDatos.AddInParameter(command, "Observacion", DbType.String, itemSeguimiento.Observacion);
                        this.BaseDeDatos.AddInParameter(command, "Fecha", DbType.DateTime, itemSeguimiento.Fecha);
                        this.BaseDeDatos.AddInParameter(command, "Usuario", DbType.String, itemSeguimiento.Usuario);

                        this.BaseDeDatos.ExecuteNonQuery(command);
                    }
                }
            }


        }

        public void Eliminar(int idAccionesMejora)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspSeguimientoDeletePorIdAccionesMejora"))
            {
                this.BaseDeDatos.AddInParameter(command, "idAccionesMejora", DbType.Int32, idAccionesMejora);
                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }
    }
}

