namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Globalization;

    public class RepositorioSolucion : RepositorioBase, IRepositorioSolucion
    {
        public IList<SolucionInformacionBasica> Consultar(int numeroPagina, int tamanoPagina, string CheckEnEjecucion)
        {
            IList<SolucionInformacionBasica> listaSolucion = new List<SolucionInformacionBasica>();

            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspSolucionesSelectPage"))
            {
                AdicionarParametrosDelPaginador(numeroPagina, tamanoPagina, command);

                this.BaseDeDatos.AddInParameter(command, "enEjecucion", DbType.Int16, CheckEnEjecucion == "checked" ? 1 : 2);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    SolucionInformacionBasica solucion = null;

                    while (dataReader.Read())
                    {
                        solucion = new SolucionInformacionBasica
                        {
                            Id = dataReader.ToGuid("Id"),
                            Nombre = dataReader.ToString("Nombre")
                        };
                        solucion.Cliente.Id = dataReader.ToInt("IdCliente");
                        solucion.UsuarioRedGerente = dataReader.ToString("UsuarioRedGerente");
                        solucion.UsuarioRedResponsable = dataReader.ToString("UsuarioRedResponsable");
                        solucion.UsuarioRedScrumMaster = dataReader.ToString("UsuarioRedScrumMaster");
                        solucion.UrlRepositorioCodigoFuente = dataReader.ToString("UrlRepositorioCodigoFuente");
                        solucion.UrlDocumentacion = dataReader.ToString("UrlDocumentacion");
                        solucion.UrlInspeccion = dataReader.ToString("UrlInspeccion");
                        solucion.UrlLeccionesAprendidas = dataReader.ToString("UrlLeccionesAprendidas");
                        solucion.UrlGestionAseguramientoCalidad = dataReader.ToString("UrlGestionAseguramientoCalidad");
                        solucion.Oficina.Id = dataReader.ToByte("IdOficina");
                        solucion.Oficina.Nombre = dataReader.ToString("NombreOficina");
                        solucion.Tipo.Id = dataReader.ToByte("IdTipo");
                        solucion.Tipo.Nombre = dataReader.ToString("NombreTipo");
                        solucion.Estado.Id = dataReader.ToByte("IdEstado");
                        solucion.Estado.Nombre = dataReader.ToString("NombreEstado");
                        solucion.LineaSolucion.Id = dataReader.ToByte("IdLineaSolucion");
                        solucion.LineaSolucion.Nombre = dataReader.ToString("NombreLineaSolucion");
                        solucion.ConteoTotalFilas = dataReader.ToInt("ConteoTotalFilas");

                        listaSolucion.Add(solucion);
                    }
                }
            }

            return listaSolucion;
        }

        public IList<SolucionInformacionBasica> ConsultarPorParametro(int numeroPagina, int tamanoPagina,
           string[] vectorDeBusqueda, string CheckEnEjecucion)
        {
            IList<SolucionInformacionBasica> listaSolucion = new List<SolucionInformacionBasica>();

            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspSolucionesSelectPageByParam"))
            {
                AdicionarParametrosDelPaginador(numeroPagina, tamanoPagina, command);

                this.BaseDeDatos.AddInParameter(command, "enEjecucion", DbType.Int16, CheckEnEjecucion == "checked" ? 1 : 2);

                if (vectorDeBusqueda != null)
                {
                    this.BaseDeDatos.AddInParameter(command, "idPais", DbType.String, vectorDeBusqueda[3]);
                    this.BaseDeDatos.AddInParameter(command, "idCiudad", DbType.String, vectorDeBusqueda[1]);
                    this.BaseDeDatos.AddInParameter(command, "idCliente", DbType.String, vectorDeBusqueda[2]);

                    this.BaseDeDatos.AddInParameter(command, "usuarioRedResponsable", DbType.String, vectorDeBusqueda[0]);
                    this.BaseDeDatos.AddInParameter(command, "usuarioRedGerente", DbType.String, vectorDeBusqueda[0]);
                    this.BaseDeDatos.AddInParameter(command, "usuarioRedScrumMaster", DbType.String, vectorDeBusqueda[0]);
                    this.BaseDeDatos.AddInParameter(command, "nombreOficina", DbType.String, vectorDeBusqueda[0]);
                    this.BaseDeDatos.AddInParameter(command, "nombre", DbType.String, vectorDeBusqueda[0]);
                    this.BaseDeDatos.AddInParameter(command, "nombreTipo", DbType.String, vectorDeBusqueda[0]);
                    this.BaseDeDatos.AddInParameter(command, "nombreLineaSolucion", DbType.String, vectorDeBusqueda[0]);
                    this.BaseDeDatos.AddInParameter(command, "nombreLineaNegocio", DbType.String, vectorDeBusqueda[0]);
                    this.BaseDeDatos.AddInParameter(command, "nombreMarcoTrabajo", DbType.String, vectorDeBusqueda[0]);
                    this.BaseDeDatos.AddInParameter(command, "nombreEstado", DbType.String, vectorDeBusqueda[0]);
                }

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    SolucionInformacionBasica solucion = null;

                    while (dataReader.Read())
                    {
                        solucion = new SolucionInformacionBasica
                        {
                            Id = dataReader.ToGuid("Id"),
                            Nombre = dataReader.ToString("Nombre")
                        };
                        solucion.Cliente.Id = dataReader.ToInt("IdCliente");
                        solucion.UsuarioRedGerente = dataReader.ToString("UsuarioRedGerente");
                        solucion.UsuarioRedResponsable = dataReader.ToString("UsuarioRedResponsable");
                        solucion.UsuarioRedScrumMaster = dataReader.ToString("UsuarioRedScrumMaster");
                        solucion.UrlRepositorioCodigoFuente = dataReader.ToString("UrlRepositorioCodigoFuente");
                        solucion.UrlDocumentacion = dataReader.ToString("UrlDocumentacion");
                        solucion.UrlInspeccion = dataReader.ToString("UrlInspeccion");
                        solucion.UrlLeccionesAprendidas = dataReader.ToString("UrlLeccionesAprendidas");
                        solucion.UrlGestionAseguramientoCalidad = dataReader.ToString("UrlGestionAseguramientoCalidad");
                        solucion.Oficina.Id = dataReader.ToByte("IdOficina");
                        solucion.Oficina.Nombre = dataReader.ToString("NombreOficina");
                        solucion.Tipo.Id = dataReader.ToByte("IdTipo");
                        solucion.Tipo.Nombre = dataReader.ToString("NombreTipo");
                        solucion.Estado.Id = dataReader.ToByte("IdEstado");
                        solucion.Estado.Nombre = dataReader.ToString("NombreEstado");
                        solucion.LineaSolucion.Id = dataReader.ToByte("IdLineaSolucion");
                        solucion.LineaSolucion.Nombre = dataReader.ToString("NombreLineaSolucion");
                        solucion.ConteoTotalFilas = dataReader.ToInt("ConteoTotalFilas");

                        listaSolucion.Add(solucion);
                    }
                }

            }

            return listaSolucion;
        }

        public IList<Solucion> Consultar()
        {
            IList<Solucion> listaSolucion = new List<Solucion>();
            Solucion solucion;

            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspSolucionesSelect"))
            {

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        solucion = new Solucion();

                        solucion.Id = dataReader.ToGuid("Id");
                        solucion.Nombre = dataReader.ToString("Nombre");
                        solucion.Descripcion = dataReader.ToString("Descripcion");
                        solucion.Observacion = dataReader.ToString("Observacion");
                        solucion.Tipo.Id = dataReader.ToByte("IdTipo");
                        solucion.Tipo.Nombre = dataReader.ToString("NombreTipoSolucion");
                        solucion.MarcoTrabajo.Id = dataReader.ToByte("IdMarcoTrabajo");
                        solucion.MarcoTrabajo.Nombre = dataReader.ToString("NombreMarcosTrabajo");
                        solucion.LineaSolucion.Id = dataReader.ToByte("IdLineaSolucion");
                        solucion.LineaSolucion.Nombre = dataReader.ToString("NombreLineaSolucion");
                        solucion.LineaNegocio.Id = dataReader.ToByte("IdLineaNegocio");
                        solucion.LineaNegocio.Nombre = dataReader.ToString("NombreLineaNegocio");
                        solucion.Estado.Id = dataReader.ToByte("IdEstado");
                        solucion.Estado.Nombre = dataReader.ToString("NombreEstadosSolucion");
                        solucion.Oficina.Id = dataReader.ToByte("IdOficina");
                        solucion.Oficina.Nombre = dataReader.ToString("NombreOficina");
                        solucion.Cliente.Id = dataReader.ToInt("IdCliente");
                        solucion.UsoComercial.Id = dataReader.ToByte("IdUsosComerciales");
                        solucion.UsoComercial.Nombre = dataReader.ToString("NombreUsosComerciales");
                        solucion.Gsdc.Id = dataReader.ToByte("IdGsdc");
                        solucion.Gsdc.Nombre = dataReader.ToString("NombreGsdc");
                        solucion.UsuarioRedGerente = dataReader.ToString("UsuarioRedGerente");
                        solucion.UsuarioRedResponsable = dataReader.ToString("UsuarioRedResponsable");
                        solucion.UsuarioRedScrumMaster = dataReader.ToString("UsuarioRedScrumMaster");
                        solucion.UrlDocumentacion = dataReader.ToString("UrlDocumentacion");
                        solucion.FechaCierre = dataReader.ToNullableDateTime("FechaCierre");
                        solucion.FechaCreacion = dataReader.ToDateTime("FechaCreacion");
                        listaSolucion.Add(solucion);
                    }
                }
            }
            return listaSolucion;
        }

        public IList<Solucion> ConsultarPorIdCliente(int idCliente)
        {
            IList<Solucion> listaSolucion = new List<Solucion>();
            Solucion solucion;

            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspSolucionesSelectPorIdCliente"))
            {
                this.BaseDeDatos.AddInParameter(command, "idCliente", DbType.Int32, idCliente);
                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        solucion = new Solucion();

                        solucion.Id = dataReader.ToGuid("Id");
                        solucion.Nombre = dataReader.ToString("Nombre");
                        solucion.Cliente.Id = dataReader.ToInt("IdCliente");

                        listaSolucion.Add(solucion);
                    }
                }
            }
            return listaSolucion;
        }

        public Solucion Obtener(Guid id)
        {
            Solucion solucionDetalle = new Solucion();

            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspSolucionesSelectPorId"))
            {
                this.BaseDeDatos.AddInParameter(command, "id", DbType.Guid, id);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        solucionDetalle.Id = dataReader.ToGuid("Id");
                        solucionDetalle.Nombre = dataReader.ToString("Nombre");
                        solucionDetalle.UsuarioRedGerente = dataReader.ToString("UsuarioRedGerente");
                        solucionDetalle.UsuarioRedResponsable = dataReader.ToString("UsuarioRedResponsable");
                        solucionDetalle.UsuarioRedScrumMaster = dataReader.ToString("UsuarioRedScrumMaster");
                        solucionDetalle.Tipo.Id = dataReader.ToByte("IdTipo");
                        solucionDetalle.Tipo.Nombre = dataReader.ToString("NombreTipoSolucion");
                        solucionDetalle.MarcoTrabajo.Id = dataReader.ToByte("IdMarcoTrabajo");
                        solucionDetalle.MarcoTrabajo.Nombre = dataReader.ToString("NombreMarcosTrabajo");
                        solucionDetalle.LineaSolucion.Id = dataReader.ToByte("IdLineaSolucion");
                        solucionDetalle.LineaSolucion.Nombre = dataReader.ToString("NombreLineaSolucion");
                        solucionDetalle.LineaNegocio.Id = dataReader.ToByte("IdLineaNegocio");
                        solucionDetalle.LineaNegocio.Nombre = dataReader.ToString("NombreLineaNegocio");
                        solucionDetalle.Estado.Id = dataReader.ToByte("IdEstado");
                        solucionDetalle.Estado.Nombre = dataReader.ToString("NombreEstadosSolucion");
                        solucionDetalle.Oficina.Id = dataReader.ToByte("IdOficina");
                        solucionDetalle.Oficina.Nombre = dataReader.ToString("NombreOficina");
                        solucionDetalle.Cliente.Id = dataReader.ToInt("IdCliente");
                        solucionDetalle.Pais.Id = dataReader.ToByte("IdPais");
                        solucionDetalle.UrlRepositorioCodigoFuente = dataReader.ToString("UrlRepositorioCodigoFuente");
                        solucionDetalle.UrlDocumentacion = dataReader.ToString("UrlDocumentacion");
                        solucionDetalle.UrlInspeccion = dataReader.ToString("UrlInspeccion");
                        solucionDetalle.UrlDiseno = dataReader.ToString("UrlDiseno");
                        solucionDetalle.UrlGestionTareas = dataReader.ToString("UrlGestionTareas");
                        solucionDetalle.UrlGestionIncidentes = dataReader.ToString("UrlGestionIncidentes");
                        solucionDetalle.UrlGestionAseguramientoCalidad = dataReader.ToString("UrlGestionAseguramientoCalidad");
                        solucionDetalle.UrlLeccionesAprendidas = dataReader.ToString("UrlLeccionesAprendidas");
                        solucionDetalle.UrlOportunidadCrm = dataReader.ToString("UrlOportunidadCrm");
                        solucionDetalle.UrlProyectoPsa = dataReader.ToString("UrlProyectoPsa");
                        solucionDetalle.NombreContactoCliente = dataReader.ToString("NombreContactoCliente");
                        solucionDetalle.CorreoContactoCliente = dataReader.ToString("CorreoContactoCliente");
                        solucionDetalle.TelefonoContactoCliente = dataReader.ToString("TelefonoContactoCliente");
                        solucionDetalle.Observacion = dataReader.ToString("Observacion");
                        solucionDetalle.Descripcion = dataReader.ToString("Descripcion");
                        solucionDetalle.FechaCreacion = dataReader.ToDateTime("FechaCreacion");
                        solucionDetalle.FechaCierre = dataReader.ToDateTime("FechaCierre");
                        solucionDetalle.ExperienciaUsuario = dataReader.ToBool("ExperienciaUsuario");
                        solucionDetalle.Etiqueta = dataReader.ToString("Etiqueta");
                        solucionDetalle.HorasEstimadas = dataReader.ToInt("HorasEstimadas");
                        solucionDetalle.HorasEjecutadas = dataReader.ToInt("HorasEjecutadas");
                        solucionDetalle.UsoComercial.Id = dataReader.ToByte("IdUsosComerciales");
                        solucionDetalle.UsoComercial.Nombre = dataReader.ToString("NombreUsosComerciales");
                        solucionDetalle.Gsdc.Id = dataReader.ToByte("IdGsdc");
                        solucionDetalle.Gsdc.Nombre = dataReader.ToString("NombreGsdc");
                        solucionDetalle.IdConsultoria = dataReader.ToGuid("IdConsultoria");
                        solucionDetalle.ObjetivoNegocio = dataReader.ToInt("ObjetivoNegocio");
                    }
                }
            }
            return solucionDetalle;
        }

        public Guid ObtenerIdSolucion(int idMetricaAgil)
        {
            Guid IdSolucion = Guid.NewGuid();

            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspSolucionSelectPorIdMetricaAgil"))
            {
                this.BaseDeDatos.AddInParameter(command, "IdMetricaAgil", DbType.Int32, idMetricaAgil);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    if (dataReader.Read())
                    {
                        IdSolucion = dataReader.ToGuid("IdSolucion");
                    }
                }
            }
            return IdSolucion;
        }

        public int ObtenerIdMarcoTrabajo(int idMetricaAgil)
        {
            int IdMarcoTrabajo = (int)default;

            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspMarcosTrabajoSelectPorIdMetricasAgiles"))
            {
                this.BaseDeDatos.AddInParameter(command, "IdMetricaAgil", DbType.Int32, idMetricaAgil);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    if (dataReader.Read())
                    {
                        IdMarcoTrabajo = dataReader.ToByte("Id");
                    }
                }
            }
            return IdMarcoTrabajo;
        }

        public Guid Crear(Solucion solucion)
        {
            Guid nuevoIdSolucion = Guid.NewGuid();
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspSolucionesInsert"))
            {
                this.BaseDeDatos.AddInParameter(command, "id", DbType.Guid, nuevoIdSolucion);
                this.BaseDeDatos.AddInParameter(command, "nombre", DbType.String, solucion.Nombre);
                this.BaseDeDatos.AddInParameter(command, "usuarioRedGerente", DbType.String, solucion.UsuarioRedGerente);
                this.BaseDeDatos.AddInParameter(command, "usuarioRedResponsable", DbType.String, solucion.UsuarioRedResponsable);
                this.BaseDeDatos.AddInParameter(command, "usuarioRedScrumMaster", DbType.String, solucion.UsuarioRedScrumMaster);
                this.BaseDeDatos.AddInParameter(command, "idTipo", DbType.Byte, solucion.Tipo.Id);
                this.BaseDeDatos.AddInParameter(command, "idMarcoTrabajo", DbType.Byte, solucion.MarcoTrabajo.Id);
                this.BaseDeDatos.AddInParameter(command, "idLineaSolucion", DbType.Byte, solucion.LineaSolucion.Id);
                this.BaseDeDatos.AddInParameter(command, "idLineaNegocio", DbType.Byte, solucion.LineaNegocio.Id);
                this.BaseDeDatos.AddInParameter(command, "idEstado", DbType.Byte, solucion.Estado.Id);
                this.BaseDeDatos.AddInParameter(command, "idOficina", DbType.Byte, solucion.Oficina.Id);
                this.BaseDeDatos.AddInParameter(command, "idCliente", DbType.Int16, solucion.Cliente.Id);
                this.BaseDeDatos.AddInParameter(command, "idPais", DbType.Byte, solucion.Pais.Id);
                this.BaseDeDatos.AddInParameter(command, "urlRepositorioCodigoFuente", DbType.String, solucion.UrlRepositorioCodigoFuente.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlDocumentacion", DbType.String, solucion.UrlDocumentacion.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlInspeccion", DbType.String, solucion.UrlInspeccion);
                this.BaseDeDatos.AddInParameter(command, "urlDiseno", DbType.String, solucion.UrlDiseno.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlGestionTareas", DbType.String, solucion.UrlGestionTareas.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlGestionIncidentes", DbType.String, solucion.UrlGestionIncidentes.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlGestionAseguramientoCalidad", DbType.String, solucion.UrlGestionAseguramientoCalidad.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlLeccionesAprendidas", DbType.String, solucion.UrlLeccionesAprendidas.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlOportunidadCrm", DbType.String, solucion.UrlOportunidadCrm.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlProyectoPsa", DbType.String, solucion.UrlProyectoPsa.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "nombreContactoCliente", DbType.String, solucion.NombreContactoCliente);
                this.BaseDeDatos.AddInParameter(command, "correoContactoCliente", DbType.String, solucion.CorreoContactoCliente);
                this.BaseDeDatos.AddInParameter(command, "telefonoContactoCliente", DbType.String, solucion.TelefonoContactoCliente);
                this.BaseDeDatos.AddInParameter(command, "usuarioRedCreacionModificacion", DbType.String, solucion.UsuarioRedLogueado);
                this.BaseDeDatos.AddInParameter(command, "Observacion", DbType.String, solucion.Observacion);
                this.BaseDeDatos.AddInParameter(command, "Descripcion", DbType.String, solucion.Descripcion);
                this.BaseDeDatos.AddInParameter(command, "FechaCreacion", DbType.DateTime, solucion.FechaCreacion);
                if (solucion.FechaCierre == Convert.ToDateTime("01/01/0001", CultureInfo.CurrentCulture))
                {
                    this.BaseDeDatos.AddInParameter(command, "FechaCierre", DbType.DateTime, null);
                }
                else
                {
                    this.BaseDeDatos.AddInParameter(command, "FechaCierre", DbType.DateTime, solucion.FechaCierre);
                }
                this.BaseDeDatos.AddInParameter(command, "experienciaUsuario", DbType.Boolean, solucion.ExperienciaUsuario);
                this.BaseDeDatos.AddInParameter(command, "etiqueta", DbType.String, solucion.Etiqueta);
                this.BaseDeDatos.AddInParameter(command, "horasEstimadas", DbType.Int32, solucion.HorasEstimadas);
                this.BaseDeDatos.AddInParameter(command, "horasEjecutadas", DbType.Int32, solucion.HorasEjecutadas);
                this.BaseDeDatos.AddInParameter(command, "idUsosComerciales", DbType.Byte, solucion.UsoComercial.Id);
                this.BaseDeDatos.AddInParameter(command, "idConsultoria", DbType.Guid, solucion.IdConsultoria);
                this.BaseDeDatos.AddInParameter(command, "objetivoNegocio", DbType.Int32, solucion.ObjetivoNegocio);

                this.BaseDeDatos.ExecuteNonQuery(command);

                return nuevoIdSolucion;
            }
        }

        public void Editar(Solucion solucion)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspSolucionesUpdate"))
            {
                this.BaseDeDatos.AddInParameter(command, "id", DbType.Guid, solucion.Id);
                this.BaseDeDatos.AddInParameter(command, "nombre", DbType.String, solucion.Nombre);
                this.BaseDeDatos.AddInParameter(command, "usuarioRedGerente", DbType.String, solucion.UsuarioRedGerente);
                this.BaseDeDatos.AddInParameter(command, "usuarioRedResponsable", DbType.String, solucion.UsuarioRedResponsable);
                this.BaseDeDatos.AddInParameter(command, "usuarioRedScrumMaster", DbType.String, solucion.UsuarioRedScrumMaster);
                this.BaseDeDatos.AddInParameter(command, "idTipo", DbType.Byte, solucion.Tipo.Id);
                this.BaseDeDatos.AddInParameter(command, "idMarcoTrabajo", DbType.Byte, solucion.MarcoTrabajo.Id);
                this.BaseDeDatos.AddInParameter(command, "idLineaSolucion", DbType.Byte, solucion.LineaSolucion.Id);
                this.BaseDeDatos.AddInParameter(command, "idLineaNegocio", DbType.Byte, solucion.LineaNegocio.Id);
                this.BaseDeDatos.AddInParameter(command, "idEstado", DbType.Byte, solucion.Estado.Id);
                this.BaseDeDatos.AddInParameter(command, "idOficina", DbType.Byte, solucion.Oficina.Id);
                this.BaseDeDatos.AddInParameter(command, "idCliente", DbType.Int16, solucion.Cliente.Id);
                this.BaseDeDatos.AddInParameter(command, "idPais", DbType.Byte, solucion.Pais.Id);
                this.BaseDeDatos.AddInParameter(command, "urlRepositorioCodigoFuente", DbType.String, solucion.UrlRepositorioCodigoFuente.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlDocumentacion", DbType.String, solucion.UrlDocumentacion.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlInspeccion", DbType.String, solucion.UrlInspeccion);
                this.BaseDeDatos.AddInParameter(command, "urlDiseno", DbType.String, solucion.UrlDiseno.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlGestionTareas", DbType.String, solucion.UrlGestionTareas.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlGestionIncidentes", DbType.String, solucion.UrlGestionIncidentes.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlGestionAseguramientoCalidad", DbType.String, solucion.UrlGestionAseguramientoCalidad.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlLeccionesAprendidas", DbType.String, solucion.UrlLeccionesAprendidas.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlOportunidadCrm", DbType.String, solucion.UrlOportunidadCrm.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlProyectoPsa", DbType.String, solucion.UrlProyectoPsa.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "nombreContactoCliente", DbType.String, solucion.NombreContactoCliente);
                this.BaseDeDatos.AddInParameter(command, "correoContactoCliente", DbType.String, solucion.CorreoContactoCliente);
                this.BaseDeDatos.AddInParameter(command, "telefonoContactoCliente", DbType.String, solucion.TelefonoContactoCliente);
                this.BaseDeDatos.AddInParameter(command, "usuarioRedCreacionModificacion", DbType.String, solucion.UsuarioRedLogueado);
                this.BaseDeDatos.AddInParameter(command, "Observacion", DbType.String, solucion.Observacion);
                this.BaseDeDatos.AddInParameter(command, "Descripcion", DbType.String, solucion.Descripcion);
                this.BaseDeDatos.AddInParameter(command, "FechaCreacion", DbType.DateTime, solucion.FechaCreacion);
                if (solucion.FechaCierre == Convert.ToDateTime("01/01/0001", CultureInfo.CurrentCulture))
                {
                    this.BaseDeDatos.AddInParameter(command, "FechaCierre", DbType.DateTime, null);
                }
                else
                {
                    this.BaseDeDatos.AddInParameter(command, "FechaCierre", DbType.DateTime, solucion.FechaCierre);
                }
                this.BaseDeDatos.AddInParameter(command, "experienciaUsuario", DbType.Boolean, solucion.ExperienciaUsuario);
                this.BaseDeDatos.AddInParameter(command, "etiqueta", DbType.String, solucion.Etiqueta);
                this.BaseDeDatos.AddInParameter(command, "horasEstimadas", DbType.Int32, solucion.HorasEstimadas);
                this.BaseDeDatos.AddInParameter(command, "horasEjecutadas", DbType.Int32, solucion.HorasEjecutadas);
                this.BaseDeDatos.AddInParameter(command, "idUsosComerciales", DbType.Byte, solucion.UsoComercial.Id);
                this.BaseDeDatos.AddInParameter(command, "idConsultoria", DbType.Guid, solucion.IdConsultoria);
                this.BaseDeDatos.AddInParameter(command, "objetivoNegocio", DbType.Int32, solucion.ObjetivoNegocio);

                this.BaseDeDatos.ExecuteNonQuery(command);

            }
        }

        public void Eliminar(Guid id)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspSolucionesDelete"))
            {
                this.BaseDeDatos.AddInParameter(command, "id", DbType.Guid, id);
                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }

        private void AdicionarParametrosDelPaginador(int numeroPagina, int tamanoPagina, DbCommand command)
        {
            this.BaseDeDatos.AddInParameter(command, "NumeroPagina", DbType.Int16, numeroPagina);
            this.BaseDeDatos.AddInParameter(command, "TamanoPagina", DbType.Int16, tamanoPagina);
        }
    }
}

