//// ----------------------------------------------------------------------------
//// <copyright file="RepositorioBase.cs">Company S.A.</copyright>
//// <author>Developer</author>
//// <email>developer@company.com</email>
//// <date>09/08/2018</date>
//// <summary>Contiene las funcionalidades genéricas de acceso a datos.</summary>
//// ----------------------------------------------------------------------------

namespace Varo.Transversales.Repositorio
{
    using Varo.Transversales.Constantes;
    using Varo.Transversales.Entidades;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Web.Caching;

    /// <summary>
    /// Contiene las funcionalidades genéricas de acceso a datos.
    /// </summary>
    public class RepositorioBase : IRepositorioBase
    {
        /// <summary>
        /// Define la conexión con la base de datos.
        /// </summary>
        public Database BaseDeDatos { get; set; }


        /// <summary>
        /// Define el almacenamientos de la cache
        /// </summary>
        private readonly Cache cache;
        /// <summary>
        /// Inicializa una instancia de tipo <see cref="RepositorioBase"/> especificando
        /// el nombre de la base de datos Shard Map Manager y el identificador de las particiones.
        /// </summary>
        public RepositorioBase()
        {
            DatabaseProviderFactory factoriaBaseDeDatos = new DatabaseProviderFactory();
            this.BaseDeDatos = factoriaBaseDeDatos.CreateDefault();
            this.cache = new Cache();
        }

        public IEnumerable<ItemMaestro> ConsultarPorMaestro(string nombreMaestro, string lenguaje)
        {
            if (!(this.cache.Get(nombreMaestro + lenguaje) is List<ItemMaestro> informacionMaestro))
            {
                informacionMaestro = new List<ItemMaestro>();

                using (DbCommand command =
                    this.BaseDeDatos.GetStoredProcCommand("uspMaestroSelect"))
                {
                    this.BaseDeDatos.AddInParameter(command, "nombreMaestro", DbType.String, nombreMaestro);

                    using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                    {
                        ItemMaestro registroMaestro = null;

                        while (dataReader.Read())
                        {
                            registroMaestro = new ItemMaestro();

                            registroMaestro.Id = dataReader.ToByte("Id");
                            registroMaestro.Nombre = dataReader.ToString(lenguaje == TransversalesConstantes.Espanol ? "Nombre" : "NombreEN");

                            informacionMaestro.Add(registroMaestro);
                        }
                    }
                }

                this.cache.Add(
                    nombreMaestro + lenguaje,
                    informacionMaestro,
                    null,
                    DateTime.Now.AddDays(1),
                    TimeSpan.Zero,
                    CacheItemPriority.High,
                    null);
            }

            return informacionMaestro;
        }

        public ItemMaestro ConsultarPorMaestroId(string nombreMaestro, byte id, string lenguaje)
        {
            List<ItemMaestro> informacionMaestro = new List<ItemMaestro>();

            using (DbCommand command = this.BaseDeDatos.GetStoredProcCommand("uspMaestroSelect"))
            {
                this.BaseDeDatos.AddInParameter(command, "nombreMaestro", DbType.String, nombreMaestro);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    ItemMaestro registroMaestro = null;

                    while (dataReader.Read())
                    {
                        registroMaestro = new ItemMaestro
                        {
                            Id = dataReader.ToByte("Id"),
                            Nombre = dataReader.ToString(lenguaje == TransversalesConstantes.Espanol ? "Nombre" : "NombreEN")
                        };

                        informacionMaestro.Add(registroMaestro);
                    }
                }
            }

            ItemMaestro itemMaestro = informacionMaestro.Find(x => x.Id.Equals(id));

            return itemMaestro;
        }
    }
}

