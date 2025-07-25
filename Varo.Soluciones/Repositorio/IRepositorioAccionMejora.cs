namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using System;
    using System.Collections.Generic;

    public interface IRepositorioAccionMejora
    {
        IList<AccionesMejora> ObtenerPorMetricaAgil(int idMetricaAgil, string lenguaje);

        IList<AccionesMejora> ObtenerPorMetricaAgil(int idMetricaAgil);
        IList<AccionesMejora> ConsultarPorSolucion(Guid idSolucion, string lenguaje);
        void Crear(AccionesMejora accionesMejora);
        void Editar(AccionesMejora accionesMejora);
        void Eliminar(int idAccionMejora);
        IList<AccionesMejora> ConsultarPorSolucionParametroBusqueda(Guid idSolucion, string parametro, string lenguaje);
    }
}

