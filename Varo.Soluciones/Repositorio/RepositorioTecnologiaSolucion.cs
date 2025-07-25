namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Constantes;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    public class RepositorioTecnologiaSolucion : RepositorioBase, IRepositorioTecnologiaSolucion
    {
        public void Crear(TecnologiaSolucion tecnologia)
        {
            if (tecnologia != null)
            {
                foreach (var itemTecnologia in tecnologia.Tecnologias)
                {
                    using (DbCommand command =
                    this.BaseDeDatos.GetStoredProcCommand("uspTecnologiasPorSolucionInsert"))
                    {
                        this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, itemTecnologia.IdSolucion);
                        this.BaseDeDatos.AddInParameter(command, "idTecnologia", DbType.Guid, itemTecnologia.Id);

                        this.BaseDeDatos.ExecuteNonQuery(command);
                    }
                }
            }
        }

        public void EliminarPorIdSolucion(Guid idSolucion)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspTecnologiasPorSolucionDeletePorIdSolucion"))
            {
                this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, idSolucion);

                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }

        public IList<TecnologiaSolucion> ConsultarPorIdSolucion(Guid idSolucion, string lenguaje)
        {
            IList<TecnologiaSolucion> listaTecnologia = new List<TecnologiaSolucion>();
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspTecnologiasPorSolucionSelectPorIdSolucion"))
            {
                this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, idSolucion);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    TecnologiaSolucion tecnologia = null;

                    while (dataReader.Read())
                    {
                        tecnologia = new TecnologiaSolucion();

                        tecnologia.Id = dataReader.ToGuid("IdTecnologia");
                        tecnologia.TipoTecnologia.Id = dataReader.ToByte("IdTipoTecnologia");
                        tecnologia.Nombre = dataReader.ToString("Nombre");
                        tecnologia.TipoTecnologia.Nombre = tecnologia.TipoTecnologia.Nombre = dataReader.ToString(
                            lenguaje == TransversalesConstantes.Espanol ? "NombreTipo" : "NombreTipoEN");
                        tecnologia.Logo = dataReader.ToString("Logo");

                        listaTecnologia.Add(tecnologia);
                    }
                }
            }
            return listaTecnologia;
        }
    }
}

