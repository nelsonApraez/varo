// -------------------------------------------------------------------
// <copyright file="NegocioExcepcion.cs" company="Company S.A.">
//     COPYRIGHT(C) 2018, Company S.A.
// </copyright>
// <author>Developer</author>
// <email>developer@company.com</email>
// <date>09/08/2018</date>
// <summary>Representa una excepci�n de negocio.</summary>
// -------------------------------------------------------------------

namespace Varo.Transversales.Excepciones
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Representa una excepci�n de negocio.
    /// </summary>
    [Serializable]
    public class NegocioExcepcion : Exception
    {
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public NegocioExcepcion()
        {
        }

        /// <summary>
        /// Constructor con mensaje.
        /// </summary>
        /// <param name="message">Mensaje para la excepci�n.</param>
        public NegocioExcepcion(string message)
            : base(message)
        {
        }

        /// <summary>Constructor excepci�n.</summary>
        /// <param name="message">Mensaje a utilizar.</param>
        /// <param name="innerException">Excepci�n de detalle.</param>
        public NegocioExcepcion(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Constructor serializaci�n.
        /// </summary>
        /// <param name="info">Datos serializaci�n.</param>
        /// <param name="context">Contexto para la serializaci�n.</param>
        protected NegocioExcepcion(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

