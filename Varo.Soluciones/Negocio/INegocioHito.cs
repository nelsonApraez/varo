namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Negocio;
    using System;
    using System.Collections.Generic;

    public interface INegocioHito : INegocioBase
    {
        IList<Hito> Obtener(Guid idHito, string lenguaje);
        void Crear(Hito hito);
        void EnviarCorreo(Solucion solucion, string emailArquitecto, string emailAdicionales, string lenguaje);
    }
}

