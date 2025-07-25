
namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Constantes;
    using Varo.Transversales.Repositorio;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    public class RepositorioNotificaciones : RepositorioBase, IRepositorioNotificaciones
    {
        public IList<Notificaciones> Consultar(string lenguaje)
        {
            IList<Notificaciones> listaCorreosNotificaciones = new List<Notificaciones>();
            using (DbCommand command = this.BaseDeDatos.GetStoredProcCommand("uspNotificacionesSelect"))
            {

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    Notificaciones correoNotificaciones = null;

                    while (dataReader.Read())
                    {
                        correoNotificaciones = new Notificaciones
                        {
                            Id = dataReader.ToByte("Id"),
                            Valor = dataReader.ToString("Valor"),
                            Nombre = dataReader.ToString(lenguaje == TransversalesConstantes.Espanol ? "Nombre" : "NombreEN")

                        };

                        listaCorreosNotificaciones.Add(correoNotificaciones);
                    }
                }
            }
            return listaCorreosNotificaciones;
        }

        public string ConsultarPorId(int id)
        {
            string listaCorreosNotificaciones = string.Empty;
            using (DbCommand command = this.BaseDeDatos.GetStoredProcCommand("uspNotificacionesSelectPorIdTipo"))
            {
                this.BaseDeDatos.AddInParameter(command, "Id", DbType.Int32, id);
                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        listaCorreosNotificaciones = dataReader.ToString("Valor");
                    }
                }
            }
            return listaCorreosNotificaciones;
        }

        public void Editar(Notificaciones correoNotificaciones)
        {
            if (correoNotificaciones != null)
            {
                foreach (var itemNotificacion in correoNotificaciones.ListaNotificaciones)
                {
                    using (DbCommand command = this.BaseDeDatos.GetStoredProcCommand("uspNotificacionesUpdate"))
                    {
                        this.BaseDeDatos.AddInParameter(command, "id", DbType.Byte, itemNotificacion.Id);
                        this.BaseDeDatos.AddInParameter(command, "valor", DbType.String, itemNotificacion.Valor);

                        this.BaseDeDatos.ExecuteNonQuery(command);
                    }
                }
            }
        }

    }
}

