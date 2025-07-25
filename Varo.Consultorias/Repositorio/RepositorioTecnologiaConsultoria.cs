namespace Varo.Consultorias.Repositorio
{
    using Varo.Consultorias.Entidades;
    using Varo.Maestros.Entidades;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    public class RepositorioTecnologiaConsultoria : RepositorioBase, IRepositorioTecnologiaConsultoria
    {

        public void Crear(TecnologiaConsultoria tecnologiaConsultoria)
        {
            if (tecnologiaConsultoria != null)
            {
                foreach (var itemTecnologia in tecnologiaConsultoria.Tecnologias)
                {
                    using (DbCommand command =
                    this.BaseDeDatos.GetStoredProcCommand("uspTecnologiasPorConsultoriasInsert"))
                    {
                        this.BaseDeDatos.AddInParameter(command, "idConsultoria", DbType.Guid, tecnologiaConsultoria.IdConsultoria);
                        this.BaseDeDatos.AddInParameter(command, "idTecnologia", DbType.Guid, itemTecnologia.Id);

                        this.BaseDeDatos.ExecuteNonQuery(command);
                    }
                }
            }
        }

        public void EliminarPorIdConsultoria(Guid idConsultoria)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspTecnologiasPorConsultoriaDeletePorIdConsultoria"))
            {
                this.BaseDeDatos.AddInParameter(command, "idConsultoria", DbType.Guid, idConsultoria);

                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }

        public IList<Tecnologia> ConsultarPorIdConsultoria(Guid idConsultoria)
        {
            IList<Tecnologia> listaTecnologia = new List<Tecnologia>();
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspTecnologiasPorConsutoriaSelectPorIdConsultoria"))
            {
                this.BaseDeDatos.AddInParameter(command, "idConsultoria", DbType.Guid, idConsultoria);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    Tecnologia tecnologia = null;

                    while (dataReader.Read())
                    {
                        tecnologia = new Tecnologia();

                        tecnologia.Id = dataReader.ToGuid("IdTecnologia");
                        tecnologia.TipoTecnologia.Id = dataReader.ToByte("IdTipoTecnologia");
                        tecnologia.TipoTecnologia.Nombre = dataReader.ToString("NombreTipo");
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

