namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    public class RepositorioPrueba : RepositorioBase, IRepositorioPrueba
    {
        public IList<Prueba> Consultar()
        {
            IList<Prueba> listaPrueba = new List<Prueba>();

            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspPruebasSolucionSelect"))

            {
                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    Prueba prueba = null;

                    while (dataReader.Read())
                    {
                        prueba = new Prueba();

                        prueba.Id = dataReader.ToGuid("Id");
                        prueba.IdSolucion = dataReader.ToGuid("IdSolucion");
                        prueba.NombreSolucion = dataReader.ToString("NombreSolucion");
                        prueba.UsuarioRedTecnico = dataReader.ToString("UsuarioRedTecnico");
                        prueba.CasosDefinidos = dataReader.ToInt("CasosDefinidos");
                        prueba.CasosAutomatizados = dataReader.ToInt("CasosAutomatizados");
                        prueba.Observaciones = dataReader.ToString("Observaciones");
                        prueba.FechaCreacion = dataReader.ToDateTime("FechaCreacion");

                        listaPrueba.Add(prueba);
                    }
                }
            }

            return listaPrueba;
        }

        public Prueba ConsultarPorIdSolucion(Guid idSolucion)
        {
            Prueba prueba = new Prueba();

            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspPruebasSolucionSelectPorIdSolucion"))

            {
                this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, idSolucion);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        prueba = new Prueba();

                        prueba.Id = dataReader.ToGuid("Id");
                        prueba.IdSolucion = dataReader.ToGuid("IdSolucion");
                        prueba.NombreSolucion = dataReader.ToString("NombreSolucion");
                        prueba.UsuarioRedTecnico = dataReader.ToString("UsuarioRedTecnico");
                        prueba.CasosDefinidos = dataReader.ToInt("CasosDefinidos");
                        prueba.CasosAutomatizar = dataReader.ToInt("CasosAutomatizar");
                        prueba.CasosAutomatizados = dataReader.ToInt("CasosAutomatizados");
                        prueba.UrlDiseñoCasos = dataReader.ToString("UrlDiseñoCasos");
                        prueba.UrlEvidencias = dataReader.ToString("UrlEvidencias");
                        prueba.UrlRepositorio = dataReader.ToString("UrlRepositorio");
                        prueba.Observaciones = dataReader.ToString("Observaciones");
                        prueba.FechaCreacion = dataReader.ToDateTime("FechaCreacion");
                        prueba.EstaenPipeline = dataReader.ToBool("EstaenPipeline");
                    }
                }
            }

            return prueba;
        }

        public Prueba Obtener(Guid id)
        {
            Prueba prueba = new Prueba();

            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspPruebasSolucionSelectPorId"))

            {
                this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, id);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        prueba = new Prueba();

                        prueba.Id = dataReader.ToGuid("Id");
                        prueba.IdSolucion = dataReader.ToGuid("IdSolucion");
                        prueba.NombreSolucion = dataReader.ToString("NombreSolucion");
                        prueba.UsuarioRedTecnico = dataReader.ToString("UsuarioRedTecnico");
                        prueba.CasosDefinidos = dataReader.ToInt("CasosDefinidos");
                        prueba.CasosAutomatizados = dataReader.ToInt("CasosAutomatizados");
                        prueba.Observaciones = dataReader.ToString("Observaciones");
                        prueba.FechaCreacion = dataReader.ToDateTime("FechaCreacion");
                    }
                }
            }

            return prueba;
        }

        public void Crear(Prueba prueba)
        {
            using (DbCommand command = this.BaseDeDatos.GetStoredProcCommand("uspPruebasSolucionInsert"))
            {
                this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, prueba.IdSolucion);
                this.BaseDeDatos.AddInParameter(command, "casosDefinidos", DbType.Int16, prueba.CasosDefinidos);
                this.BaseDeDatos.AddInParameter(command, "casosAutomatizar", DbType.Int16, prueba.CasosAutomatizar);
                this.BaseDeDatos.AddInParameter(command, "casosAutomatizados", DbType.Int16, prueba.CasosAutomatizados);
                this.BaseDeDatos.AddInParameter(command, "UrlDiseñoCasos", DbType.String, prueba.UrlDiseñoCasos);
                this.BaseDeDatos.AddInParameter(command, "UrlEvidencias", DbType.String, prueba.UrlEvidencias);
                this.BaseDeDatos.AddInParameter(command, "UrlRepositorio", DbType.String, prueba.UrlRepositorio);
                this.BaseDeDatos.AddInParameter(command, "usuarioRedTecnico", DbType.String, prueba.UsuarioRedTecnico);
                this.BaseDeDatos.AddInParameter(command, "fechaCreacion", DbType.DateTime, prueba.FechaCreacion);
                this.BaseDeDatos.AddInParameter(command, "estaenPipeline", DbType.Boolean, prueba.EstaenPipeline);
                this.BaseDeDatos.AddInParameter(command, "observaciones", DbType.String, prueba.Observaciones);

                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }

        public void Editar(Prueba prueba)
        {
            using (DbCommand command = this.BaseDeDatos.GetStoredProcCommand("uspPruebasSolucionUpdate"))
            {
                this.BaseDeDatos.AddInParameter(command, "id", DbType.Guid, prueba.Id);
                this.BaseDeDatos.AddInParameter(command, "casosDefinidos", DbType.Int16, prueba.CasosDefinidos);
                this.BaseDeDatos.AddInParameter(command, "casosAutomatizar", DbType.Int16, prueba.CasosAutomatizar);
                this.BaseDeDatos.AddInParameter(command, "casosAutomatizados", DbType.Int16, prueba.CasosAutomatizados);
                this.BaseDeDatos.AddInParameter(command, "UrlDiseñoCasos", DbType.String, prueba.UrlDiseñoCasos);
                this.BaseDeDatos.AddInParameter(command, "UrlEvidencias", DbType.String, prueba.UrlEvidencias);
                this.BaseDeDatos.AddInParameter(command, "UrlRepositorio", DbType.String, prueba.UrlRepositorio);
                this.BaseDeDatos.AddInParameter(command, "usuarioRedTecnico", DbType.String, prueba.UsuarioRedTecnico);
                this.BaseDeDatos.AddInParameter(command, "fechaCreacion", DbType.DateTime, prueba.FechaCreacion);
                this.BaseDeDatos.AddInParameter(command, "estaenPipeline", DbType.Boolean, prueba.EstaenPipeline);
                this.BaseDeDatos.AddInParameter(command, "observaciones", DbType.String, prueba.Observaciones);

                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }

        public void Eliminar(Guid id)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspPruebasSolucionDelete"))
            {
                this.BaseDeDatos.AddInParameter(command, "id", DbType.Guid, id);
                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }
    }
}

