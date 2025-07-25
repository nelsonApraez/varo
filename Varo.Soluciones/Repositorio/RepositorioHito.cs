namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Constantes;
    using Varo.Transversales.Entidades;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    public class RepositorioHito : RepositorioBase, IRepositorioHito
    {
        public IList<Hito> Obtener(Guid idSolucion, string lenguaje)
        {
            IList<Hito> listaHitos = new List<Hito>();
            using (DbCommand command = this.BaseDeDatos.GetStoredProcCommand("uspHitoSelectPorIdSolucion"))
            {
                this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, idSolucion);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    Hito hito = null;

                    while (dataReader.Read())
                    {
                        hito = new Hito
                        {
                            Id = dataReader.ToGuid("Id"),
                            IdSolucion = dataReader.ToGuid("IdSolucion"),
                            Tipo = new ItemMaestro
                            {
                                Id = dataReader.ToByte("IdTipo"),
                                Nombre = dataReader.ToString(lenguaje == TransversalesConstantes.Espanol ? "TipoHito" : "TipoHitoEN")
                            },
                            Descripcion = dataReader.ToString("Descripcion"),
                            FechaCierre = dataReader.ToDateTime("FechaCierre"),
                            Estado = new ItemMaestro
                            {
                                Id = dataReader.ToByte("IdEstado"),
                                Nombre = dataReader.ToString(lenguaje == TransversalesConstantes.Espanol ? "Estado" : "EstadoEN")
                            },
                            Observaciones = dataReader.ToString("Observaciones")
                        };

                        listaHitos.Add(hito);
                    }
                }
            }
            return listaHitos;

        }

        public void Crear(Hito hito)
        {
            if (hito != null)
            {
                foreach (var itemHito in hito.ListaHitos)
                {
                    using (DbCommand command = this.BaseDeDatos.GetStoredProcCommand("uspHitoInsert"))
                    {
                        this.BaseDeDatos.AddInParameter(command, "IdSolucion", DbType.Guid, itemHito.IdSolucion);
                        this.BaseDeDatos.AddInParameter(command, "IdTipo", DbType.Byte, itemHito.Tipo.Id);
                        this.BaseDeDatos.AddInParameter(command, "Descripcion", DbType.String, itemHito.Descripcion);
                        this.BaseDeDatos.AddInParameter(command, "FechaCierre", DbType.DateTime, itemHito.FechaCierre);
                        this.BaseDeDatos.AddInParameter(command, "IdEstado", DbType.Byte, itemHito.Estado.Id);
                        this.BaseDeDatos.AddInParameter(command, "Observaciones", DbType.String, itemHito.Observaciones);

                        this.BaseDeDatos.ExecuteNonQuery(command);
                    }
                }
            }
        }

        public void Eliminar(Guid idSolucion)
        {
            using (DbCommand command = this.BaseDeDatos.GetStoredProcCommand("uspHitoDeletePorIdSolucion"))
            {
                this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, idSolucion);
                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }
    }
}

