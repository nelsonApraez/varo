namespace Varo.Consultorias.Repositorio
{
    using Varo.Consultorias.Entidades;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Globalization;

    public class RepositorioConsultoria : RepositorioBase, IRepositorioConsultoria
    {
        public IList<ConsultoriaInformacionBasica> Consultar(int numeroPagina, int tamanoPagina, string CheckEnEjecucion)
        {
            IList<ConsultoriaInformacionBasica> listaConsultorias = new List<ConsultoriaInformacionBasica>();

            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspConsultoriasSelectPage"))
            {
                AdicionarParametrosDelPaginador(numeroPagina, tamanoPagina, command);

                this.BaseDeDatos.AddInParameter(command, "enEjecucion", DbType.Int16, CheckEnEjecucion == "checked" ? 1 : 0);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    ConsultoriaInformacionBasica consultoria = null;

                    while (dataReader.Read())
                    {
                        consultoria = new ConsultoriaInformacionBasica
                        {
                            Id = dataReader.ToGuid("Id"),
                            Nombre = dataReader.ToString("Nombre")
                        };
                        consultoria.Cliente.Id = dataReader.ToInt("IdCliente");
                        consultoria.UsuarioRedGerente = dataReader.ToString("UsuarioRedGerente");
                        consultoria.UsuarioRedConsultor = dataReader.ToString("UsuarioRedConsultor");
                        consultoria.UrlDocumentacion = dataReader.ToString("UrlDocumentacion");
                        consultoria.UrlGestionAseguramientoCalidad = dataReader.ToString("UrlGestionAseguramientoCalidad");
                        consultoria.UrlLeccionesAprendidas = dataReader.ToString("UrlLeccionesAprendidas");
                        consultoria.Oficina.Id = dataReader.ToByte("IdOficina");
                        consultoria.Oficina.Nombre = dataReader.ToString("NombreOficina");
                        consultoria.Estado.Id = dataReader.ToByte("IdEstado");
                        consultoria.Estado.Nombre = dataReader.ToString("NombreEstado");
                        consultoria.LineaConsultoria.Id = dataReader.ToByte("IdLineaConsultoria");
                        consultoria.LineaConsultoria.Nombre = dataReader.ToString("NombreLineaConsultoria");
                        consultoria.ConteoTotalFilas = dataReader.ToInt("ConteoTotalFilas");

                        listaConsultorias.Add(consultoria);
                    }
                }
            }

            return listaConsultorias;
        }

        public IList<ConsultoriaInformacionBasica> ConsultarPorParametro(int numeroPagina, int tamanoPagina,
          string[] vectorDeBusqueda, string CheckEnEjecucion)
        {
            IList<ConsultoriaInformacionBasica> listaConsultoria = new List<ConsultoriaInformacionBasica>();

            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspConsultoriasSelectPageByParam"))
            {
                AdicionarParametrosDelPaginador(numeroPagina, tamanoPagina, command);

                this.BaseDeDatos.AddInParameter(command, "enEjecucion", DbType.Int16, CheckEnEjecucion == "checked" ? 1 : 2);

                if (vectorDeBusqueda != null)
                {
                    this.BaseDeDatos.AddInParameter(command, "nombre", DbType.String, vectorDeBusqueda[0]);
                    this.BaseDeDatos.AddInParameter(command, "usuarioRedGerente", DbType.String, vectorDeBusqueda[0]);
                    this.BaseDeDatos.AddInParameter(command, "usuarioRedConsultor", DbType.String, vectorDeBusqueda[0]);
                    this.BaseDeDatos.AddInParameter(command, "nombreLineaConsultoria", DbType.String, vectorDeBusqueda[0]);
                    this.BaseDeDatos.AddInParameter(command, "nombreLineaNegocio", DbType.String, vectorDeBusqueda[0]);
                    this.BaseDeDatos.AddInParameter(command, "nombreEstado", DbType.String, vectorDeBusqueda[0]);
                    this.BaseDeDatos.AddInParameter(command, "nombreOficina", DbType.String, vectorDeBusqueda[0]);
                    this.BaseDeDatos.AddInParameter(command, "nombreContactoCliente", DbType.String, vectorDeBusqueda[0]);
                    this.BaseDeDatos.AddInParameter(command, "idPais", DbType.String, vectorDeBusqueda[3]);
                    this.BaseDeDatos.AddInParameter(command, "idCiudad", DbType.String, vectorDeBusqueda[1]);
                    this.BaseDeDatos.AddInParameter(command, "idCliente", DbType.String, vectorDeBusqueda[2]);
                }

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    ConsultoriaInformacionBasica consultoria = null;

                    while (dataReader.Read())
                    {
                        consultoria = new ConsultoriaInformacionBasica
                        {
                            Id = dataReader.ToGuid("Id"),
                            Nombre = dataReader.ToString("Nombre")
                        };
                        consultoria.Cliente.Id = dataReader.ToInt("IdCliente");
                        consultoria.UsuarioRedGerente = dataReader.ToString("UsuarioRedGerente");
                        consultoria.UsuarioRedConsultor = dataReader.ToString("UsuarioRedConsultor");
                        consultoria.UrlDocumentacion = dataReader.ToString("UrlDocumentacion");
                        consultoria.UrlGestionAseguramientoCalidad = dataReader.ToString("UrlGestionAseguramientoCalidad");
                        consultoria.UrlLeccionesAprendidas = dataReader.ToString("UrlLeccionesAprendidas");
                        consultoria.Oficina.Id = dataReader.ToByte("IdOficina");
                        consultoria.Oficina.Nombre = dataReader.ToString("NombreOficina");
                        consultoria.Estado.Id = dataReader.ToByte("IdEstado");
                        consultoria.Estado.Nombre = dataReader.ToString("NombreEstado");
                        consultoria.LineaConsultoria.Id = dataReader.ToByte("IdLineaConsultoria");
                        consultoria.LineaConsultoria.Nombre = dataReader.ToString("NombreLineaConsultoria");
                        consultoria.ConteoTotalFilas = dataReader.ToInt("ConteoTotalFilas");

                        listaConsultoria.Add(consultoria);
                    }
                }

            }

            return listaConsultoria;
        }

        public IList<Consultoria> Consultar()
        {
            IList<Consultoria> listaConsultoria = new List<Consultoria>();
            Consultoria consultoria;

            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspConsultoriaSelect"))
            {

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        consultoria = new Consultoria();

                        consultoria.Id = dataReader.ToGuid("Id");
                        consultoria.Nombre = dataReader.ToString("Nombre");
                        consultoria.Oficina.Id = dataReader.ToByte("IdOficina");
                        consultoria.Cliente.Id = dataReader.ToInt("IdCliente");
                        consultoria.Estado.Id = dataReader.ToByte("IdEstado");
                        consultoria.Estado.Nombre = dataReader.ToString("NombreEstadosConsultoria");
                        consultoria.Gsdc.Id = dataReader.ToByte("IdGsdc");
                        consultoria.Gsdc.Nombre = dataReader.ToString("NombreGsdc");

                        listaConsultoria.Add(consultoria);
                    }
                }
            }
            return listaConsultoria;
        }

        public IList<Consultoria> Listar()
        {
            IList<Consultoria> listaConsultorias = new List<Consultoria>();
            Consultoria consultoria;

            using (DbCommand command = this.BaseDeDatos.GetStoredProcCommand("uspConsultoriaSelect"))
            {
                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        consultoria = new Consultoria();

                        consultoria.Id = dataReader.ToGuid("Id");
                        consultoria.Nombre = dataReader.ToString("Nombre");
                        consultoria.Estado.Id = dataReader.ToByte("IdEstado");
                        consultoria.Estado.Nombre = dataReader.ToString("NombreEstado");
                        consultoria.LineaNegocio.Id = dataReader.ToByte("IdLineaNegocio");
                        consultoria.LineaNegocio.Nombre = dataReader.ToString("NombreLineaNegocio");
                        consultoria.Oficina.Id = dataReader.ToByte("IdOficina");
                        consultoria.Oficina.Nombre = dataReader.ToString("NombreOficina");
                        consultoria.Cliente.Id = dataReader.ToInt("IdCliente");
                        consultoria.UsuarioRedGerente = dataReader.ToString("UsuarioRedGerente");
                        consultoria.UsuarioRedConsultor = dataReader.ToString("UsuarioRedConsultor");

                        listaConsultorias.Add(consultoria);
                    }
                }
            }
            return listaConsultorias;
        }

        public Consultoria Obtener(Guid id)
        {
            Consultoria consultoriaDetalle = new Consultoria();

            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspConsultoriasSelectPorId"))
            {
                this.BaseDeDatos.AddInParameter(command, "id", DbType.Guid, id);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        consultoriaDetalle.Id = dataReader.ToGuid("Id");
                        consultoriaDetalle.Nombre = dataReader.ToString("Nombre");
                        consultoriaDetalle.UsuarioRedGerente = dataReader.ToString("UsuarioRedGerente");
                        consultoriaDetalle.UsuarioRedConsultor = dataReader.ToString("UsuarioRedConsultor");
                        consultoriaDetalle.LineaConsultoria.Id = dataReader.ToByte("IdLineaConsultoria");
                        consultoriaDetalle.LineaConsultoria.Nombre = dataReader.ToString("NombreLineaConsultoria");
                        consultoriaDetalle.LineaNegocio.Id = dataReader.ToByte("IdLineaNegocio");
                        consultoriaDetalle.LineaNegocio.Nombre = dataReader.ToString("NombreLineaNegocio");
                        consultoriaDetalle.Estado.Id = dataReader.ToByte("IdEstado");
                        consultoriaDetalle.Estado.Nombre = dataReader.ToString("NombreEstadosConsultoria");
                        consultoriaDetalle.Oficina.Id = dataReader.ToByte("IdOficina");
                        consultoriaDetalle.Oficina.Nombre = dataReader.ToString("NombreOficina");
                        consultoriaDetalle.Cliente.Id = dataReader.ToInt("IdCliente");
                        consultoriaDetalle.Pais.Id = dataReader.ToByte("IdPais");
                        consultoriaDetalle.UrlDocumentacion = dataReader.ToString("UrlDocumentacion");
                        consultoriaDetalle.UrlDiseno = dataReader.ToString("UrlDiseno");
                        consultoriaDetalle.UrlGestionTareas = dataReader.ToString("UrlGestionTareas");
                        consultoriaDetalle.UrlGestionIncidentes = dataReader.ToString("UrlGestionIncidentes");
                        consultoriaDetalle.UrlGestionAseguramientoCalidad = dataReader.ToString("UrlGestionAseguramientoCalidad");
                        consultoriaDetalle.UrlLeccionesAprendidas = dataReader.ToString("UrlLeccionesAprendidas");
                        consultoriaDetalle.UrlOportunidadCrm = dataReader.ToString("UrlOportunidadCrm");
                        consultoriaDetalle.UrlProyectoPsa = dataReader.ToString("UrlProyectoPsa");
                        consultoriaDetalle.NombreContactoCliente = dataReader.ToString("NombreContactoCliente");
                        consultoriaDetalle.CorreoContactoCliente = dataReader.ToString("CorreoContactoCliente");
                        consultoriaDetalle.TelefonoContactoCliente = dataReader.ToString("TelefonoContactoCliente");
                        consultoriaDetalle.Observacion = dataReader.ToString("Observacion");
                        consultoriaDetalle.Descripcion = dataReader.ToString("Descripcion");
                        consultoriaDetalle.Etiqueta = dataReader.ToString("Etiqueta");
                        consultoriaDetalle.HorasEstimadas = dataReader.ToInt("HorasEstimadas");
                        consultoriaDetalle.HorasEjecutadas = dataReader.ToInt("HorasEjecutadas");
                        consultoriaDetalle.FechaCreacion = dataReader.ToDateTime("FechaCreacion");
                        consultoriaDetalle.FechaCierre = dataReader.ToDateTime("FechaCierre");
                        consultoriaDetalle.UsoComercial.Id = dataReader.ToByte("IdUsosComerciales");
                        consultoriaDetalle.UsoComercial.Nombre = dataReader.ToString("NombreUsosComerciales");
                        consultoriaDetalle.Gsdc.Id = dataReader.ToByte("IdGsdc");
                        consultoriaDetalle.Gsdc.Nombre = dataReader.ToString("NombreGsdc");
                        consultoriaDetalle.ObjetivoNegocio = dataReader.ToInt("ObjetivoNegocio");
                    }
                }
            }
            return consultoriaDetalle;
        }

        public Guid Crear(Consultoria consultoria)
        {
            Guid nuevoIdConsultoria = Guid.NewGuid();
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspConsultoriasInsert"))
            {
                this.BaseDeDatos.AddInParameter(command, "id", DbType.Guid, nuevoIdConsultoria);
                this.BaseDeDatos.AddInParameter(command, "nombre", DbType.String, consultoria.Nombre);
                this.BaseDeDatos.AddInParameter(command, "usuarioRedGerente", DbType.String, consultoria.UsuarioRedGerente);
                this.BaseDeDatos.AddInParameter(command, "usuarioRedConsultor", DbType.String, consultoria.UsuarioRedConsultor);
                this.BaseDeDatos.AddInParameter(command, "idLineaConsultoria", DbType.Byte, consultoria.LineaConsultoria.Id);
                this.BaseDeDatos.AddInParameter(command, "idLineaNegocio", DbType.Byte, consultoria.LineaNegocio.Id);
                this.BaseDeDatos.AddInParameter(command, "idEstado", DbType.Byte, consultoria.Estado.Id);
                this.BaseDeDatos.AddInParameter(command, "idOficina", DbType.Byte, consultoria.Oficina.Id);
                this.BaseDeDatos.AddInParameter(command, "idCliente", DbType.Int16, consultoria.Cliente.Id);
                this.BaseDeDatos.AddInParameter(command, "idPais", DbType.Byte, consultoria.Pais.Id);
                this.BaseDeDatos.AddInParameter(command, "urlDocumentacion", DbType.String, consultoria.UrlDocumentacion.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlDiseno", DbType.String, consultoria.UrlDiseno.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlGestionTareas", DbType.String, consultoria.UrlGestionTareas.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlGestionIncidentes", DbType.String, consultoria.UrlGestionIncidentes.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlGestionAseguramientoCalidad", DbType.String, consultoria.UrlGestionAseguramientoCalidad.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlLeccionesAprendidas", DbType.String, consultoria.UrlLeccionesAprendidas.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlOportunidadCrm", DbType.String, consultoria.UrlOportunidadCrm.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlProyectoPsa", DbType.String, consultoria.UrlProyectoPsa.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "nombreContactoCliente", DbType.String, consultoria.NombreContactoCliente);
                this.BaseDeDatos.AddInParameter(command, "correoContactoCliente", DbType.String, consultoria.CorreoContactoCliente);
                this.BaseDeDatos.AddInParameter(command, "telefonoContactoCliente", DbType.String, consultoria.TelefonoContactoCliente);
                this.BaseDeDatos.AddInParameter(command, "usuarioRedCreacionModificacion", DbType.String, consultoria.UsuarioRedLogueado);
                this.BaseDeDatos.AddInParameter(command, "Observacion", DbType.String, consultoria.Observacion);
                this.BaseDeDatos.AddInParameter(command, "Descripcion", DbType.String, consultoria.Descripcion);
                this.BaseDeDatos.AddInParameter(command, "FechaCreacion", DbType.DateTime, consultoria.FechaCreacion);
                if (consultoria.FechaCierre == Convert.ToDateTime("01/01/0001", CultureInfo.CurrentCulture))
                {
                    this.BaseDeDatos.AddInParameter(command, "FechaCierre", DbType.DateTime, null);
                }
                else
                {
                    this.BaseDeDatos.AddInParameter(command, "FechaCierre", DbType.DateTime, consultoria.FechaCierre);
                }
                this.BaseDeDatos.AddInParameter(command, "etiqueta", DbType.String, consultoria.Etiqueta);
                this.BaseDeDatos.AddInParameter(command, "HorasEstimadas", DbType.Int32, consultoria.HorasEstimadas);
                this.BaseDeDatos.AddInParameter(command, "HorasEjecutadas", DbType.Int32, consultoria.HorasEjecutadas);
                this.BaseDeDatos.AddInParameter(command, "idUsosComerciales", DbType.Byte, consultoria.UsoComercial.Id);
                this.BaseDeDatos.AddInParameter(command, "objetivoNegocio", DbType.Int32, consultoria.ObjetivoNegocio);

                this.BaseDeDatos.ExecuteNonQuery(command);

                return nuevoIdConsultoria;
            }
        }

        public void Editar(Consultoria consultoria)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspConsultoriasUpdate"))
            {
                this.BaseDeDatos.AddInParameter(command, "id", DbType.Guid, consultoria.Id);
                this.BaseDeDatos.AddInParameter(command, "nombre", DbType.String, consultoria.Nombre);
                this.BaseDeDatos.AddInParameter(command, "usuarioRedGerente", DbType.String, consultoria.UsuarioRedGerente);
                this.BaseDeDatos.AddInParameter(command, "usuarioRedConsultor", DbType.String, consultoria.UsuarioRedConsultor);
                this.BaseDeDatos.AddInParameter(command, "idLineaConsultoria", DbType.Byte, consultoria.LineaConsultoria.Id);
                this.BaseDeDatos.AddInParameter(command, "idLineaNegocio", DbType.Byte, consultoria.LineaNegocio.Id);
                this.BaseDeDatos.AddInParameter(command, "idEstado", DbType.Byte, consultoria.Estado.Id);
                this.BaseDeDatos.AddInParameter(command, "idOficina", DbType.Byte, consultoria.Oficina.Id);
                this.BaseDeDatos.AddInParameter(command, "idCliente", DbType.Int16, consultoria.Cliente.Id);
                this.BaseDeDatos.AddInParameter(command, "idPais", DbType.Byte, consultoria.Pais.Id);
                this.BaseDeDatos.AddInParameter(command, "urlDocumentacion", DbType.String, consultoria.UrlDocumentacion.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlDiseno", DbType.String, consultoria.UrlDiseno.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlGestionTareas", DbType.String, consultoria.UrlGestionTareas.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlGestionIncidentes", DbType.String, consultoria.UrlGestionIncidentes.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlGestionAseguramientoCalidad", DbType.String, consultoria.UrlGestionAseguramientoCalidad.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlLeccionesAprendidas", DbType.String, consultoria.UrlLeccionesAprendidas.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlOportunidadCrm", DbType.String, consultoria.UrlOportunidadCrm.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "urlProyectoPsa", DbType.String, consultoria.UrlProyectoPsa.ToString(CultureInfo.CurrentCulture));
                this.BaseDeDatos.AddInParameter(command, "nombreContactoCliente", DbType.String, consultoria.NombreContactoCliente);
                this.BaseDeDatos.AddInParameter(command, "correoContactoCliente", DbType.String, consultoria.CorreoContactoCliente);
                this.BaseDeDatos.AddInParameter(command, "telefonoContactoCliente", DbType.String, consultoria.TelefonoContactoCliente);
                this.BaseDeDatos.AddInParameter(command, "usuarioRedCreacionModificacion", DbType.String, consultoria.UsuarioRedLogueado);
                this.BaseDeDatos.AddInParameter(command, "Observacion", DbType.String, consultoria.Observacion);
                this.BaseDeDatos.AddInParameter(command, "Descripcion", DbType.String, consultoria.Descripcion);
                this.BaseDeDatos.AddInParameter(command, "FechaCreacion", DbType.DateTime, consultoria.FechaCreacion);
                if (consultoria.FechaCierre == Convert.ToDateTime("01/01/0001", CultureInfo.CurrentCulture))
                {
                    this.BaseDeDatos.AddInParameter(command, "FechaCierre", DbType.DateTime, null);
                }
                else
                {
                    this.BaseDeDatos.AddInParameter(command, "FechaCierre", DbType.DateTime, consultoria.FechaCierre);
                }
                this.BaseDeDatos.AddInParameter(command, "etiqueta", DbType.String, consultoria.Etiqueta);
                this.BaseDeDatos.AddInParameter(command, "HorasEstimadas", DbType.Int32, consultoria.HorasEstimadas);
                this.BaseDeDatos.AddInParameter(command, "HorasEjecutadas", DbType.Int32, consultoria.HorasEjecutadas);
                this.BaseDeDatos.AddInParameter(command, "idUsosComerciales", DbType.Byte, consultoria.UsoComercial.Id);
                this.BaseDeDatos.AddInParameter(command, "objetivoNegocio", DbType.Int32, consultoria.ObjetivoNegocio);
                this.BaseDeDatos.ExecuteNonQuery(command);

            }
        }

        public void Eliminar(Guid id)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspConsultoriaDelete"))
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

