
namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Negocio;
    using System;
    using System.Collections.Generic;
    public interface INegocioEquipoSolucion : INegocioBase
    {
        void Crear(EquipoSolucion equipoSolucion);

        void Eliminar(Guid idSolucion);

        IList<EquipoSolucion> Consultar(Guid idSolucion);
    }
}

