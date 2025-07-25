namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Negocio;
    using System;

    public interface INegocioPracticaCalidad : INegocioBase
    {
        PracticasCalidad ConsultarPorIdSolucion(Guid idSolucion);
        void EstablecerPracticas(PracticasCalidad practicasCalidad);

        string ObtenerImagenNivelMadurez();
    }
}

