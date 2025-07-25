namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using System.Collections.Generic;

    public interface INegocioSeguimiento
    {
        IList<Seguimiento> Consultar(int idAccionMejora);

        void Crear(Seguimiento seguimiento);
    }
}

