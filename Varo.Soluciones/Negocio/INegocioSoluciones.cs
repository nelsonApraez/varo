namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Negocio;
    using System;
    using System.Collections.Generic;


    public interface INegocioSoluciones : INegocioBase
    {
        IList<SolucionInformacionBasica> Consultar(int numeroPagina, int tamanoPagina, string CheckEnEjecucion);

        IList<SolucionInformacionBasica> ConsultarPorParametro(int numeroPagina, int tamanoPagina,
                                              string valorDeBusqueda, string CheckEnEjecucion);

        IList<Solucion> Consultar();

        Solucion Obtener(Guid id);

        Guid ObtenerIdSolucion(int IdMetricaAgil);

        void Crear(Solucion solucion,
            TecnologiaSolucion tecnologia,
            DesplieguesContinuos despliegueContinuo,
            MonitoreosContinuos monitoreoContinuo,
            IntegracionesContinuas integracionContinua,
            PracticasCalidad practicasCalidad);

        void Editar(Solucion solucion,
            TecnologiaSolucion tecnologia,
            DesplieguesContinuos despliegueContinuo,
            MonitoreosContinuos monitoreoContinuo,
            IntegracionesContinuas integracionContinua,
            PracticasCalidad practicasCalidad);

        void Eliminar(Guid id);

        bool EsSolucionScrumban(Guid idSolucion);

        IList<Solucion> ConsultarPorIdCliente(int idCliente);
    }
}

