namespace Varo.Maestros.Repositorio
{
    using Varo.Transversales.Entidades;
    using Varo.Transversales.Repositorio;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    public class RepositorioOficinas : RepositorioBase, IRepositorioOficinas
    {
        public IList<ItemMaestro> ConsultarOficinaPorIdGsdc(byte idGsdc)
        {
            IList<ItemMaestro> listaOficina = new List<ItemMaestro>();
            ItemMaestro oficina;

            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspOficinaSelectPorIdGsdc"))
            {
                this.BaseDeDatos.AddInParameter(command, "idGsdc", DbType.Byte, idGsdc);
                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        oficina = new ItemMaestro();

                        oficina.Id = dataReader.ToByte("Id");
                        oficina.Nombre = dataReader.ToString("Nombre");

                        listaOficina.Add(oficina);
                    }
                }
            }
            return listaOficina;
        }
    }
}

