namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using System;
    using System.Collections.Generic;

    public interface IRepositorioSolucion
    {
        IList<SolucionInformacionBasica> Consultar(int numeroPagina, int tamanoPagina, string CheckEnEjecucion);

        IList<SolucionInformacionBasica> ConsultarPorParametro(int numeroPagina, int tamanoPagina,
            string[] vectorDeBusqueda, string CheckEnEjecucion);

        IList<Solucion> Consultar();

        Solucion Obtener(Guid id);

        Guid ObtenerIdSolucion(int idMetricaAgil);

        int ObtenerIdMarcoTrabajo(int idMetricaAgil);

        Guid Crear(Solucion solucion);

        void Editar(Solucion solucion);

        void Eliminar(Guid id);

        IList<Solucion> ConsultarPorIdCliente(int idCliente);
    }
}

