namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Negocio;
    using System;
    using System.Collections.Generic;

    public interface INegocioAmbientes : INegocioBase
    {
        IList<Ambientes> Consultar(Guid idSolucion, string lenguaje);

        void Crear(Ambientes ambientes);
    }
}

