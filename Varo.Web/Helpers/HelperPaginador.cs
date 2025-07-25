namespace Varo.Web.Helpers
{
    using Varo.Transversales;
    using Varo.Web.Models;
    using System.Globalization;
    using System.Web.Mvc;

    public static class HelperPaginador
    {
        private const string nombreDelParametroNumeroPaginaActual = "numeroPaginaActual";
        private const string nombreDelParametroFiltroActual = "filtroActual";
        private const string nombreDelParametroEnEjecucion = "enEjecucion";

        public static MvcHtmlString Paginador(this HtmlHelper helper, Paginador informacionDeLaVista)
        {
            TagBuilder etiquetaListaPrincipal = new TagBuilder("ul");

            if (informacionDeLaVista != null)
            {
                etiquetaListaPrincipal.AddCssClass("pagination");

                if (informacionDeLaVista.NumeroDePaginaActual > 1)
                {
                    etiquetaListaPrincipal.InnerHtml =
                        GenerarHtmlBotonesDeNavegacionHaciaAtras(helper, informacionDeLaVista);
                }

                etiquetaListaPrincipal.InnerHtml +=
                    GenerarHtmlBotonesDeCadaPagina(helper, informacionDeLaVista);

                if (informacionDeLaVista.NumeroDePaginaActual < informacionDeLaVista.NumeroTotalDePaginas)
                {
                    etiquetaListaPrincipal.InnerHtml +=
                        GenerarHtmlBotonesDeNavegacionHaciaAdelante(helper, informacionDeLaVista);
                }
            }

            return new MvcHtmlString(etiquetaListaPrincipal.ToString());
        }

        private static string GenerarHtmlBotonesDeNavegacionHaciaAtras(
            HtmlHelper helper,
            Paginador informacionDeLaVista)
        {
            return string.Format(CultureInfo.CurrentCulture, "{0}\n{1}",
                GenerarHtmlBotonPrimeraPagina(helper, informacionDeLaVista),
                GenerarHtmlBotonPaginaAnterior(helper, informacionDeLaVista));
        }

        private static string GenerarHtmlBotonPrimeraPagina(HtmlHelper helper, Paginador informacionDeLaVista)
        {
            TagBuilder etiquetaEnlaceBotonPrimerPagina = new TagBuilder("a");
            etiquetaEnlaceBotonPrimerPagina.SetInnerText(ParametrosGenerales.PrimeraPagina);

            etiquetaEnlaceBotonPrimerPagina.MergeAttribute(
                "href",
                string.Format(CultureInfo.CurrentCulture, "/{0}/{1}?{2}={3}&{4}={5}",
                ObtenerControladorDeLaUrl(helper),
                ObtenerAccionDeLaUrl(helper),
                nombreDelParametroFiltroActual,
                informacionDeLaVista.FiltroActual,
                nombreDelParametroEnEjecucion,
                informacionDeLaVista.EnEjecucion));

            TagBuilder etiquetaItemListaPrimeraPagina = new TagBuilder("li");
            etiquetaItemListaPrimeraPagina.InnerHtml = etiquetaEnlaceBotonPrimerPagina.ToString();

            return etiquetaItemListaPrimeraPagina.ToString();
        }

        private static string GenerarHtmlBotonPaginaAnterior(
            HtmlHelper helper,
            Paginador informacionDeLaVista)
        {
            TagBuilder etiquetaEnlaceBotonPaginaAnterior = new TagBuilder("a");
            etiquetaEnlaceBotonPaginaAnterior.SetInnerText(ParametrosGenerales.PaginaAnterior);
            etiquetaEnlaceBotonPaginaAnterior.MergeAttribute("href",
                string.Format(CultureInfo.CurrentCulture,
                    "/{0}/{1}?{2}={3}&{4}={5}&{6}={7}",
                    ObtenerControladorDeLaUrl(helper),
                    ObtenerAccionDeLaUrl(helper),
                    nombreDelParametroNumeroPaginaActual,
                    informacionDeLaVista.NumeroDePaginaActual - 1,
                    nombreDelParametroFiltroActual,
                    informacionDeLaVista.FiltroActual,
                    nombreDelParametroEnEjecucion,
                    informacionDeLaVista.EnEjecucion));

            TagBuilder etiquetaItemListaPaginaAnterior = new TagBuilder("li");
            etiquetaItemListaPaginaAnterior.InnerHtml = etiquetaEnlaceBotonPaginaAnterior.ToString();

            return etiquetaItemListaPaginaAnterior.ToString();
        }

        private static string GenerarHtmlBotonesDeCadaPagina(
            HtmlHelper helper,
            Paginador informacionDeLaVista)
        {
            string htmlConLasPaginas = string.Empty;

            for (int numeroPaginaActual = informacionDeLaVista.NumeroDePaginaInicial;
                numeroPaginaActual <= informacionDeLaVista.NumeroDePaginaFinal;
                numeroPaginaActual++)
            {
                TagBuilder etiquetaItemListaPorPagina = new TagBuilder("li");

                if (numeroPaginaActual == informacionDeLaVista.NumeroDePaginaActual)
                {
                    etiquetaItemListaPorPagina.AddCssClass("active");
                }

                etiquetaItemListaPorPagina.InnerHtml +=
                    GenerarHtmlEtiquetaPorPagina(helper, numeroPaginaActual, informacionDeLaVista);

                htmlConLasPaginas += etiquetaItemListaPorPagina;
            }

            return htmlConLasPaginas;
        }

        private static string GenerarHtmlEtiquetaPorPagina(
            HtmlHelper helper,
            int numeroPaginaActual,
            Paginador informacionDeLaVista)
        {
            TagBuilder etiquetaEnlaceBotonPorPagina = new TagBuilder("a");
            etiquetaEnlaceBotonPorPagina.SetInnerText(numeroPaginaActual.ToString(CultureInfo.CurrentCulture));

            etiquetaEnlaceBotonPorPagina.MergeAttribute("href",
                string.Format(CultureInfo.CurrentCulture,
                    "/{0}/{1}?{2}={3}&{4}={5}&{6}={7}",
                    ObtenerControladorDeLaUrl(helper),
                    ObtenerAccionDeLaUrl(helper),
                    nombreDelParametroNumeroPaginaActual,
                    numeroPaginaActual,
                    nombreDelParametroFiltroActual,
                    informacionDeLaVista.FiltroActual,
                    nombreDelParametroEnEjecucion,
                    informacionDeLaVista.EnEjecucion));

            return etiquetaEnlaceBotonPorPagina.ToString();
        }

        private static string GenerarHtmlBotonesDeNavegacionHaciaAdelante(
            HtmlHelper helper,
            Paginador informacionDeLaVista)
        {
            return string.Format(CultureInfo.CurrentCulture, "{0}\n{1}",
                GenerarHtmlBotonPaginaSiguiente(helper, informacionDeLaVista),
                GenerarHtmlBotonUltimaPagina(helper, informacionDeLaVista));
        }

        private static string GenerarHtmlBotonUltimaPagina(HtmlHelper helper, Paginador informacionDeLaVista)
        {
            TagBuilder etiquetaEnlaceBotonUltimaPagina = new TagBuilder("a");
            etiquetaEnlaceBotonUltimaPagina.SetInnerText(ParametrosGenerales.UltimaPagina);

            etiquetaEnlaceBotonUltimaPagina.MergeAttribute(
                "href",
                string.Format(CultureInfo.CurrentCulture, "/{0}/{1}?{2}={3}&{4}={5}&{6}={7}",
                ObtenerControladorDeLaUrl(helper),
                ObtenerAccionDeLaUrl(helper),
                nombreDelParametroNumeroPaginaActual,
                informacionDeLaVista.NumeroTotalDePaginas,
                nombreDelParametroFiltroActual,
                informacionDeLaVista.FiltroActual,
                nombreDelParametroEnEjecucion,
                informacionDeLaVista.EnEjecucion));

            TagBuilder etiquetaItemListaPrimeraPagina = new TagBuilder("li");
            etiquetaItemListaPrimeraPagina.InnerHtml = etiquetaEnlaceBotonUltimaPagina.ToString();

            return etiquetaItemListaPrimeraPagina.ToString();
        }

        private static string GenerarHtmlBotonPaginaSiguiente(
            HtmlHelper helper,
            Paginador informacionDeLaVista)
        {
            TagBuilder etiquetaEnlaceBotonPaginaSiguiente = new TagBuilder("a");
            etiquetaEnlaceBotonPaginaSiguiente.SetInnerText(ParametrosGenerales.PaginaSiguiente);

            etiquetaEnlaceBotonPaginaSiguiente.MergeAttribute(
                "href",
                string.Format(CultureInfo.CurrentCulture, "/{0}/{1}?{2}={3}&{4}={5}&{6}={7}",
                ObtenerControladorDeLaUrl(helper),
                ObtenerAccionDeLaUrl(helper),
                nombreDelParametroNumeroPaginaActual,
                informacionDeLaVista.NumeroDePaginaActual + 1,
                nombreDelParametroFiltroActual,
                informacionDeLaVista.FiltroActual,
                nombreDelParametroEnEjecucion,
                informacionDeLaVista.EnEjecucion));

            TagBuilder etiquetaItemListaPaginaAnterior = new TagBuilder("li");
            etiquetaItemListaPaginaAnterior.InnerHtml = etiquetaEnlaceBotonPaginaSiguiente.ToString();

            return etiquetaItemListaPaginaAnterior.ToString();
        }

        private static string ObtenerControladorDeLaUrl(HtmlHelper helper)
        {
            return helper.ViewContext.RouteData.Values["Controller"].ToString();
        }

        private static string ObtenerAccionDeLaUrl(HtmlHelper helper)
        {
            return helper.ViewContext.RouteData.Values["Action"].ToString();
        }
    }
}
