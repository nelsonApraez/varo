namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Negocio;
    using System;
    using System.Collections.Generic;

    public interface INegocioDespliegueContinuo : INegocioBase
    {
        void Crear(DesplieguesContinuos despliegueContinuo);

        void EliminarPorIdSolucion(Guid idSolucion);

        IList<DesplieguesContinuos> ConsultarPorIdSolucion(Guid idSolucion);

    }
}

