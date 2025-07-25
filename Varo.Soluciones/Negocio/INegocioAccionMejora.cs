namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using System;
    using System.Collections.Generic;

    public interface INegocioAccionMejora
    {
        IList<AccionesMejora> ObtenerPorMetricaAgil(int idMetricaAgil, string lenguaje);
        IList<AccionesMejora> ConsultarPorSolucion(Guid idSolucion, string lenguaje);
        void Crear(AccionesMejora accionesMejora);
        void Editar(AccionesMejora accionesMejora);
        IList<AccionesMejora> ConsultarPorSolucionParametroBusqueda(Guid idSolucion, string parametro, string lenguaje);
    }
}

