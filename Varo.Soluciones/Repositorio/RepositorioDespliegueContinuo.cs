namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Globalization;

    public class RepositorioDespligueContinuo : RepositorioBase, IRepositorioDespliegueContinuo
    {
        public void Crear(DesplieguesContinuos despliegueContinuo)
        {
            if (despliegueContinuo != null)
            {
                foreach (var itemDespliegueContinuo in despliegueContinuo.ListaDeplieguesContinuos)
                {
                    using (DbCommand command =
                        this.BaseDeDatos.GetStoredProcCommand("uspDesplieguesContinuosInsert"))
                    {
                        this.BaseDeDatos.AddInParameter(command, "id", DbType.Guid, Guid.NewGuid());
                        this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, itemDespliegueContinuo.IdSolucion);
                        this.BaseDeDatos.AddInParameter(command, "nombre", DbType.String, itemDespliegueContinuo.Nombre);
                        this.BaseDeDatos.AddInParameter(command, "urlDespliegue", DbType.String, itemDespliegueContinuo.UrlDespliegue.ToString(CultureInfo.CurrentCulture) ?? "");

                        this.BaseDeDatos.ExecuteNonQuery(command);
                    }
                }
            }
        }

        public void EliminarPorIdSolucion(Guid idSolucion)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspDesplieguesContinuosDeletePorIdSolucion"))
            {
                this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, idSolucion);
                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }

        public IList<DesplieguesContinuos> ConsultarPorIdSolucion(Guid idSolucion)
        {
            IList<DesplieguesContinuos> listaDesplieguesContinuos = new List<DesplieguesContinuos>();
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspDesplieguesContinuosSelectPorIdSolucion"))
            {
                this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, idSolucion);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    DesplieguesContinuos desplieguesContinuos = null;

                    while (dataReader.Read())
                    {
                        desplieguesContinuos = new DesplieguesContinuos();

                        desplieguesContinuos.Id = dataReader.ToGuid("Id");
                        desplieguesContinuos.Nombre = dataReader.ToString("Nombre");
                        if (dataReader.ToString("UrlDespliegue") != "")
                        {
                            desplieguesContinuos.UrlDespliegue = dataReader.ToString("UrlDespliegue");
                        }

                        listaDesplieguesContinuos.Add(desplieguesContinuos);
                    }
                }
            }
            return listaDesplieguesContinuos;
        }
    }
}

