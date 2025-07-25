namespace Varo.Maestros.Repositorio
{
    using Varo.Maestros.Entidades;
    using Varo.Transversales.Repositorio;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    public class RepositorioTecnologia : RepositorioBase, IRepositorioTecnologia
    {
        public IList<Tecnologia> ConsultarPorTipoDeTecnologia(byte tipoDeTecnologia)
        {
            IList<Tecnologia> listaTecnologia = new List<Tecnologia>();

            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspTecnologiasSelectPorTipoDeTecnologia"))
            {
                this.BaseDeDatos.AddInParameter(command, "idTipoTecnologia", DbType.Byte, tipoDeTecnologia);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    Tecnologia tecnologia = null;

                    while (dataReader.Read())
                    {
                        tecnologia = new Tecnologia();

                        tecnologia.Id = dataReader.ToGuid("Id");
                        tecnologia.Nombre = dataReader.ToString("Nombre");
                        tecnologia.Logo = dataReader.ToString("Logo");

                        listaTecnologia.Add(tecnologia);
                    }
                }
            }

            return listaTecnologia;
        }
    }
}

