//// ----------------------------------------------------------------------
//// <copyright file="HelperMensajes.cs">
////     COPYRIGHT(C) 2018, Company S.A
//// </copyright>
//// <author>Developer</author>
//// <email>developer@company.com</email>
//// <date>09/08/2018</date>
//// <summary>Define un control de mensajes Html personalizado.</summary>
//// ----------------------------------------------------------------------

namespace Varo.Web.Helpers
{
    // using Company.Framework.Mensajes; // Commented out during sanitization
    using System.Web.Mvc;

    /// <summary>
    /// Define un control de mensajes Html personalizado.
    /// </summary>
    public static class HelperMensajes
    {
        /// <summary>
        /// Establece el mensaje de negocio en la variable TempData.
        /// </summary>
        private const string MensajeNegocio = "MensajeNegocio";

        /// <summary>
        /// Establece el submensaje de negocio en la variable TempData.
        /// </summary>
        private const string SubMensajeNegocio = "SubMensajeNegocio";

        /// <summary>
        /// Obtiene establece el texto del bot�n a visualizar en el modal. Por defecto, es ACEPTAR.
        /// </summary>
        public static string TextoBoton { get; set; }

        /// <summary>
        /// Visualiza un mensaje de advertencia.
        /// </summary>
        /// <param name="controlador">Controlador que almacena el mensaje.</param>
        /// <param name="mensaje">Mensaje a visualizar. Primera l�nea.</param>
        public static void MostrarMensaje(this ControllerBase controlador, string mensaje)
        {
            if (mensaje != null)
            {
                GenerarMensaje(controlador, mensaje, null);
            }
        }

        /// <summary>
        /// Visualiza un mensaje de advertencia.
        /// </summary>
        /// <param name="controlador">Controlador que almacena el mensaje.</param>
        /// <param name="mensaje">Mensaje a visualizar. Primera línea.</param>
        /* public static void MostrarMensaje(this ControllerBase controlador, Mensaje mensaje)
        {
            if (mensaje != null)
            {
                GenerarMensaje(controlador, mensaje.Texto, null);
            }
        } */ // Commented out during sanitization

        /// <summary>
        /// Visualiza un mensaje de advertencia.
        /// </summary>
        /// <param name="controlador">Controlador que almacena el mensaje.</param>
        /// <param name="mensaje">Mensaje a visualizar. Primera l�nea.</param>
        /// <param name="submensaje">Submensaje a visualizar. Segunda l�nea.</param>
        public static void MostrarMensaje(this ControllerBase controlador, string mensaje, string submensaje)
        {
            GenerarMensaje(controlador, mensaje, submensaje);
        }

        /// <summary>
        /// Visualiza un mensaje de advertencia.
        /// </summary>
        /// <param name="controlador">Controlador que almacena el mensaje.</param>
        /// <param name="mensaje">Mensaje a visualizar. Primera línea.</param>
        /// <param name="submensaje">Submensaje a visualizar. Segunda línea.</param>
        /* public static void MostrarMensaje(this ControllerBase controlador, Mensaje mensaje, string submensaje)
        {
            if (mensaje != null)
            {
                GenerarMensaje(controlador, mensaje.Texto, submensaje);
            }
        } */ // Commented out during sanitization

        /// <summary>
        /// Devuelve un mensaje especificado en el TempData del control actual.
        /// </summary>
        /// <param name="helper">Representa la compatibilidad para representar los controles HTML en una vista.</param>
        /// <returns>Mensaje especificado.</returns>
        public static MvcHtmlString MensajeExtender(this HtmlHelper helper)
        {
            string mensaje = string.Empty;
            var submensaje = string.Empty;

            if (helper != null)
            {
                if (!ReferenceEquals(helper.ViewContext.TempData[MensajeNegocio], null))
                {
                    mensaje = helper.ViewContext.TempData[MensajeNegocio].ToString();

                    if (!ReferenceEquals(helper.ViewContext.TempData[SubMensajeNegocio], null))
                    {
                        submensaje = helper.ViewContext.TempData[SubMensajeNegocio].ToString();
                    }
                }
            }

            string textBoton = string.IsNullOrEmpty(TextoBoton) ? "ACEPTAR" : TextoBoton;

            return new MvcHtmlString(GenerarEstructuraMensajeHtml(mensaje, submensaje, textBoton));
        }

        /// <summary>
        /// Determina el tipo de mensaje a generar.
        /// </summary>
        /// <param name="controlador">Controlador que almacena el mensaje.</param>
        /// <param name="mensaje">Mensaje a visualizar. Primera l�nea.</param>
        /// <param name="submensaje">Submensaje a visualizar. Segunda l�nea.</param>
        private static void GenerarMensaje(this ControllerBase controlador, string mensaje, string submensaje)
        {
            controlador.TempData[MensajeNegocio] = mensaje.Equals("MensajeControlado") ? Recursos.Lenguaje.MensajeControlado : mensaje;
            controlador.TempData[SubMensajeNegocio] = submensaje;
        }

        /// <summary>
        /// Genera la estructura html del mensaje de negocio.
        /// </summary>
        /// <param name="mensajePrincipal">Mensaje principal a visualizar. Primera l�nea.</param>
        /// <param name="submensaje">Mensaje secundario a visualizar. Segunda l�nea.</param>
        /// <param name="textoBoton">Texto del bot�n que cierra la modal.</param>
        /// <returns>Estructura Html del mensaje a renderizar.</returns>
        private static string GenerarEstructuraMensajeHtml(
            string mensajePrincipal,
            string submensaje,
            string textoBoton)
        {
            if (!string.IsNullOrEmpty(mensajePrincipal))
            {
                TagBuilder mensajeUsuario = new TagBuilder("div");

                mensajeUsuario.MergeAttribute("id", "modalMensajes");
                mensajeUsuario.MergeAttribute("class", "modal modal-wide fade");
                mensajeUsuario.MergeAttribute("data-keyboard", "false");
                mensajeUsuario.MergeAttribute("data-backdrop", "static");
                mensajeUsuario.MergeAttribute("id", "mensajeNegocio");
                mensajeUsuario.InnerHtml = ModalDialog(mensajePrincipal, submensaje, textoBoton);

                return mensajeUsuario.ToString();
            }

            return string.Empty;
        }

        private static string ModalDialog(string textoMensajePrincipal, string textoSubmensaje, string textoBoton)
        {
            TagBuilder modalDialog = new TagBuilder("div");
            modalDialog.MergeAttribute("class", "modal-dialog");
            modalDialog.InnerHtml = ModalContent(textoMensajePrincipal, textoSubmensaje, textoBoton);

            return modalDialog.ToString();
        }

        private static string ModalContent(string textoMensajePrincipal, string textoSubmensaje, string textoBoton)
        {
            TagBuilder modalContent = new TagBuilder("div");
            modalContent.MergeAttribute("class", "modal-content");
            modalContent.InnerHtml = ModalBody(textoMensajePrincipal, textoSubmensaje, textoBoton);

            return modalContent.ToString();
        }

        private static string ModalBody(string textoMensajePrincipal, string textoSubmensaje, string textoBoton)
        {
            TagBuilder modalBody = new TagBuilder("div");
            modalBody.MergeAttribute("class", "modal-body");
            modalBody.InnerHtml = ContenidoModal(textoMensajePrincipal, textoSubmensaje, textoBoton);

            return modalBody.ToString();
        }

        private static string ContenidoModal(string textoMensajePrincipal, string textoSubmensaje, string textoBoton)
        {
            TagBuilder modalMensaje = new TagBuilder("div");
            modalMensaje.MergeAttribute("class", "mensaje");

            TagBuilder mensajePrincipal = new TagBuilder("p");
            mensajePrincipal.MergeAttribute("class", "txtTitulo-mensaje");
            mensajePrincipal.SetInnerText(textoMensajePrincipal);
            modalMensaje.InnerHtml += mensajePrincipal;

            TagBuilder submensaje = new TagBuilder("p");
            submensaje.MergeAttribute("class", "txtNormal-mensaje");
            submensaje.SetInnerText(textoSubmensaje);
            modalMensaje.InnerHtml += submensaje;

            modalMensaje.InnerHtml += FilaBotones(textoBoton);

            return modalMensaje.ToString();
        }

        private static string FilaBotones(string textoBoton)
        {
            TagBuilder bloqueGeneral = new TagBuilder("div");
            bloqueGeneral.MergeAttribute("class", "row center-block");

            TagBuilder bloqueIzquierdo = new TagBuilder("div");
            bloqueIzquierdo.MergeAttribute("class", "col-md-4");
            bloqueGeneral.InnerHtml += bloqueIzquierdo;

            TagBuilder bloqueIntermedio = new TagBuilder("div");
            bloqueIntermedio.MergeAttribute("class", "col-md-4");
            bloqueIntermedio.InnerHtml = ContenidoBotonesModal(textoBoton);
            bloqueGeneral.InnerHtml += bloqueIntermedio;

            TagBuilder bloqueDerecho = new TagBuilder("div");
            bloqueDerecho.MergeAttribute("class", "col-md-4");
            bloqueGeneral.InnerHtml += bloqueDerecho;

            return bloqueGeneral.ToString();
        }

        private static string ContenidoBotonesModal(string textoBoton)
        {
            TagBuilder filaBotones = new TagBuilder("div");
            filaBotones.MergeAttribute("class", "row");

            TagBuilder bloqueIzquierdo = new TagBuilder("div");
            bloqueIzquierdo.MergeAttribute("class", "col-md-4");
            filaBotones.InnerHtml += bloqueIzquierdo;

            TagBuilder bloqueIntermedio = new TagBuilder("div");
            bloqueIntermedio.MergeAttribute("class", "col-md-4");

            TagBuilder boton = new TagBuilder("button");
            boton.MergeAttribute("type", "button");
            boton.MergeAttribute("class", "btn btn-green btn-block");
            boton.MergeAttribute("data-dismiss", "modal");
            boton.SetInnerText(textoBoton);
            bloqueIntermedio.InnerHtml = boton.ToString();
            filaBotones.InnerHtml += bloqueIntermedio;

            TagBuilder bloqueDerecho = new TagBuilder("div");
            bloqueDerecho.MergeAttribute("class", "col-md-4");
            filaBotones.InnerHtml += bloqueDerecho;

            return filaBotones.ToString();
        }
    }
}
