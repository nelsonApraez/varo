namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Negocio;
    using System;
    using System.Collections.Generic;

    public interface INegocioTecnologiaSolucion : INegocioBase
    {
        void Crear(TecnologiaSolucion tecnologia);

        void EliminarPorIdSolucion(Guid idSolucion);

        IList<TecnologiaSolucion> ConsultarPorIdSolucion(Guid idSolucion, string lenguaje);
    }
}

