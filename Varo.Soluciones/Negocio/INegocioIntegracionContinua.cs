namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Negocio;
    using System;
    using System.Collections.Generic;

    public interface INegocioIntegracionContinua : INegocioBase
    {
        void Crear(IntegracionesContinuas integracionContinua);

        void EliminarPorIdSolucion(Guid idSolucion);

        IList<IntegracionesContinuas> ConsultarPorIdSolucion(Guid idSolucion);

    }
}

