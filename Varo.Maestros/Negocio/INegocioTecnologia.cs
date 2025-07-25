namespace Varo.Maestros.Negocio
{
    using Varo.Maestros.Entidades;
    using Varo.Transversales.Negocio;
    using System.Collections.Generic;

    public interface INegocioTecnologia : INegocioBase
    {
        IList<Tecnologia> ConsultarPorTipoDeTecnologia(byte tipoDeTecnologia);
    }
}

