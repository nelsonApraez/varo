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

    public class RepositorioAmbientes : RepositorioBase, IRepositorioAmbientes
    {
        public IList<Ambientes> Consultar(Guid idSolucion, string lenguaje)
        {
            IList<Ambientes> listaAmbientes = new List<Ambientes>();
            using (DbCommand command = this.BaseDeDatos.GetStoredProcCommand("uspAmbientesSolucionSelectPorIdSolucion"))
            {
                this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, idSolucion);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    Ambientes ambiente = null;

                    while (dataReader.Read())
                    {
                        ambiente = new Ambientes
                        {
                            Id = dataReader.ToGuid("Id"),
                            IdSolucion = dataReader.ToGuid("IdSolucion"),
                            TipoAmbiente = new ItemMaestro
                            {
                                Id = dataReader.ToByte("IdTipoAmbiente"),
                                Nombre = dataReader.ToString(lenguaje == TransversalesConstantes.Espanol ? "TipoAmbiente" : "TipoAmbienteEN")
                            },
                            Ubicacion = dataReader.ToString("Ubicacion"),
                            Responsable = dataReader.ToString("Responsable")
                        };

                        listaAmbientes.Add(ambiente);
                    }
                }
            }
            return listaAmbientes;

        }
        public void Crear(Ambientes ambientes)
        {
            if (ambientes != null)
            {
                foreach (var itemAmbiente in ambientes.ListaAmbientes)
                {
                    using (DbCommand command = this.BaseDeDatos.GetStoredProcCommand("uspAmbientesSolucionInsert"))
                    {
                        this.BaseDeDatos.AddInParameter(command, "IdSolucion", DbType.Guid, itemAmbiente.IdSolucion);
                        this.BaseDeDatos.AddInParameter(command, "IdTipoAmbiente", DbType.Byte, itemAmbiente.TipoAmbiente.Id);
                        this.BaseDeDatos.AddInParameter(command, "Ubicacion", DbType.String, itemAmbiente.Ubicacion);
                        this.BaseDeDatos.AddInParameter(command, "Responsable", DbType.String, itemAmbiente.Responsable);

                        this.BaseDeDatos.ExecuteNonQuery(command);
                    }
                }
            }
        }

        public void Eliminar(Guid idSolucion)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspAmbientesSolucionDeletePorIdSolucion"))
            {
                this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, idSolucion);
                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }
    }
}

