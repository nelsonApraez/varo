namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Data;
    using System.Data.Common;

    public class RepositorioPracticaCalidad : RepositorioBase, IRepositorioPracticaCalidad
    {
        public void Crear(PracticasCalidad practicasCalidad)
        {
            if (practicasCalidad != null)
            {
                using (DbCommand command =
                    this.BaseDeDatos.GetStoredProcCommand("uspPracticasCalidadInsert"))
                {

                    this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, practicasCalidad.id);
                    this.BaseDeDatos.AddInParameter(command, "controlDocumentacion", DbType.Boolean, practicasCalidad.controlDocumentacion);
                    this.BaseDeDatos.AddInParameter(command, "gestionTareas", DbType.Boolean, practicasCalidad.gestionTareas);
                    this.BaseDeDatos.AddInParameter(command, "gestionErrores", DbType.Boolean, practicasCalidad.gestionErrores);
                    this.BaseDeDatos.AddInParameter(command, "controlCodigo", DbType.Boolean, practicasCalidad.controlCodigo);
                    this.BaseDeDatos.AddInParameter(command, "pruebasUnitariasAutomatizadas", DbType.Boolean, practicasCalidad.pruebasUnitariasAutomatizadas);
                    this.BaseDeDatos.AddInParameter(command, "pruebasFuncionalesAutomatizadas", DbType.Boolean, practicasCalidad.pruebasFuncionalesAutomatizadas);
                    this.BaseDeDatos.AddInParameter(command, "inspeccionContinua", DbType.Boolean, practicasCalidad.inspeccionContinua);
                    this.BaseDeDatos.AddInParameter(command, "integracionContinua", DbType.Boolean, practicasCalidad.integracionContinua);
                    this.BaseDeDatos.AddInParameter(command, "despliegueContinuo", DbType.Boolean, practicasCalidad.despliegueContinuo);
                    this.BaseDeDatos.AddInParameter(command, "monitoreoContinuo", DbType.Boolean, practicasCalidad.monitoreoContinuo);
                    this.BaseDeDatos.AddInParameter(command, "seguridadContinua", DbType.Boolean, practicasCalidad.seguridadContinua);
                    this.BaseDeDatos.AddInParameter(command, "rendimientoContinuo", DbType.Boolean, practicasCalidad.rendimientoContinuo);
                    this.BaseDeDatos.AddInParameter(command, "infraestructuraComoCodigo", DbType.Boolean, practicasCalidad.infraestructuraComoCodigo);
                    this.BaseDeDatos.AddInParameter(command, "notasControlDocumentacion", DbType.String, practicasCalidad.notasControlDocumentacion);
                    this.BaseDeDatos.AddInParameter(command, "notasGestionTareas", DbType.String, practicasCalidad.notasGestionTareas);
                    this.BaseDeDatos.AddInParameter(command, "notasGestionErrores", DbType.String, practicasCalidad.notasGestionErrores);
                    this.BaseDeDatos.AddInParameter(command, "notasControlCodigo", DbType.String, practicasCalidad.notasControlCodigo);
                    this.BaseDeDatos.AddInParameter(command, "notasPruebasUnitariasAutomatizadas", DbType.String, practicasCalidad.notasPruebasUnitariasAutomatizadas);
                    this.BaseDeDatos.AddInParameter(command, "notasPruebasFuncionalesAutomatizadas", DbType.String, practicasCalidad.notasPruebasFuncionalesAutomatizadas);
                    this.BaseDeDatos.AddInParameter(command, "notasInspeccionContinua", DbType.String, practicasCalidad.notasInspeccionContinua);
                    this.BaseDeDatos.AddInParameter(command, "notasIntegracionContinua", DbType.String, practicasCalidad.notasIntegracionContinua);
                    this.BaseDeDatos.AddInParameter(command, "notasDespliegueContinuo", DbType.String, practicasCalidad.notasDespliegueContinuo);
                    this.BaseDeDatos.AddInParameter(command, "notasMonitoreoContinuo", DbType.String, practicasCalidad.notasMonitoreoContinuo);
                    this.BaseDeDatos.AddInParameter(command, "notasSeguridadContinua", DbType.String, practicasCalidad.notasSeguridadContinua);
                    this.BaseDeDatos.AddInParameter(command, "notasRendimientoContinuo", DbType.String, practicasCalidad.notasRendimientoContinuo);
                    this.BaseDeDatos.AddInParameter(command, "notasInfraestructuraComoCodigo", DbType.String, practicasCalidad.notasInfraestructuraComoCodigo);

                    this.BaseDeDatos.ExecuteNonQuery(command);
                }
            }
        }

        public void EliminarPorIdSolucion(Guid idSolucion)
        {
            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspPracticasCalidadDeletePorIdSolucion"))
            {
                this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, idSolucion);
                this.BaseDeDatos.ExecuteNonQuery(command);
            }
        }

        public PracticasCalidad ConsultarPorIdSolucion(Guid idSolucion)
        {
            PracticasCalidad practicasCalidad = new PracticasCalidad();

            using (DbCommand command =
                this.BaseDeDatos.GetStoredProcCommand("uspPracticasCalidadSelectPorIdSolucion"))
            {
                this.BaseDeDatos.AddInParameter(command, "idSolucion", DbType.Guid, idSolucion);

                using (IDataReader dataReader = this.BaseDeDatos.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        practicasCalidad.controlDocumentacion = dataReader.ToNullableBool("ControlDocumentacion");
                        practicasCalidad.gestionTareas = dataReader.ToNullableBool("GestionTareas");
                        practicasCalidad.gestionErrores = dataReader.ToNullableBool("GestionErrores");
                        practicasCalidad.controlCodigo = dataReader.ToNullableBool("ControlCodigo");
                        practicasCalidad.pruebasUnitariasAutomatizadas = dataReader.ToNullableBool("PruebasUnitariasAutomatizadas");
                        practicasCalidad.pruebasFuncionalesAutomatizadas = dataReader.ToNullableBool("PruebasFuncionalesAutomatizadas");
                        practicasCalidad.inspeccionContinua = dataReader.ToNullableBool("InspeccionContinua");
                        practicasCalidad.integracionContinua = dataReader.ToNullableBool("IntegracionContinua");
                        practicasCalidad.despliegueContinuo = dataReader.ToNullableBool("DespliegueContinuo");
                        practicasCalidad.monitoreoContinuo = dataReader.ToNullableBool("MonitoreoContinuo");
                        practicasCalidad.seguridadContinua = dataReader.ToNullableBool("SeguridadContinua");
                        practicasCalidad.rendimientoContinuo = dataReader.ToNullableBool("RendimientoContinuo");
                        practicasCalidad.infraestructuraComoCodigo = dataReader.ToNullableBool("InfraestructuraComoCodigo");
                        practicasCalidad.notasControlDocumentacion = dataReader.ToString("NotasControlDocumentacion");
                        practicasCalidad.notasGestionTareas = dataReader.ToString("NotasGestionTareas");
                        practicasCalidad.notasGestionErrores = dataReader.ToString("NotasGestionErrores");
                        practicasCalidad.notasControlCodigo = dataReader.ToString("NotasControlCodigo");
                        practicasCalidad.notasPruebasUnitariasAutomatizadas = dataReader.ToString("NotasPruebasUnitariasAutomatizadas");
                        practicasCalidad.notasPruebasFuncionalesAutomatizadas = dataReader.ToString("NotasPruebasFuncionalesAutomatizadas");
                        practicasCalidad.notasInspeccionContinua = dataReader.ToString("NotasInspeccionContinua");
                        practicasCalidad.notasIntegracionContinua = dataReader.ToString("NotasIntegracionContinua");
                        practicasCalidad.notasDespliegueContinuo = dataReader.ToString("NotasDespliegueContinuo");
                        practicasCalidad.notasMonitoreoContinuo = dataReader.ToString("NotasMonitoreoContinuo");
                        practicasCalidad.notasSeguridadContinua = dataReader.ToString("NotasSeguridadContinua");
                        practicasCalidad.notasRendimientoContinuo = dataReader.ToString("NotasRendimientoContinuo");
                        practicasCalidad.notasInfraestructuraComoCodigo = dataReader.ToString("NotasInfraestructuraComoCodigo");
                    }
                }
            }
            return practicasCalidad;
        }
    }
}

