namespace Varo.Web.Models
{
    using Varo.Transversales.Constantes;
    using System;

    public class Paginador
    {
        public int TotalDeRegistros { get; private set; }

        public int NumeroDePaginaActual { get; private set; }

        public int CantidadDeRegistrosPorPagina { get; private set; }

        public int NumeroTotalDePaginas { get; private set; }

        public int NumeroDePaginaInicial { get; private set; }

        public int NumeroDePaginaFinal { get; private set; }

        public string FiltroActual { get; private set; }

        public string EnEjecucion { get; private set; }

        public Paginador(string filtroActual, string enEjecucion, int totalDeRegistros, int? paginaActual, int cantidadDeRegistrosPorPagina)
        {
            int totalDePaginasCalculadas =
                (int)Math.Ceiling((decimal)totalDeRegistros / (decimal)cantidadDeRegistrosPorPagina);
            var numeroDePaginaActual = paginaActual.HasValue ? (int)paginaActual : NumerosConstantes.Numero1;
            var numeroDePaginaInicial = numeroDePaginaActual - NumerosConstantes.Numero5;
            var numeroDePaginaFinal = numeroDePaginaActual + NumerosConstantes.Numero4;

            if (numeroDePaginaInicial <= (int)default)
            {
                numeroDePaginaFinal -= (numeroDePaginaInicial - NumerosConstantes.Numero1);
                numeroDePaginaInicial = NumerosConstantes.Numero1;
            }

            if (numeroDePaginaFinal > totalDePaginasCalculadas)
            {
                numeroDePaginaFinal = totalDePaginasCalculadas;

                if (numeroDePaginaFinal > NumerosConstantes.Numero10)
                {
                    numeroDePaginaInicial = numeroDePaginaFinal - NumerosConstantes.Numero9;
                }
            }

            TotalDeRegistros = totalDeRegistros;
            NumeroDePaginaActual = numeroDePaginaActual;
            CantidadDeRegistrosPorPagina = cantidadDeRegistrosPorPagina;
            NumeroTotalDePaginas = totalDePaginasCalculadas;
            NumeroDePaginaInicial = numeroDePaginaInicial;
            NumeroDePaginaFinal = numeroDePaginaFinal;
            FiltroActual = filtroActual;
            EnEjecucion = enEjecucion;
        }
    }
}
