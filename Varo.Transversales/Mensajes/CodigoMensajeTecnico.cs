//// -----------------------------------------------------------------
//// <copyright file="CodigoMensajeTecnico.cs" company="Company S.A.">
////     COPYRIGHT(C) 2018, Company S.A.
//// </copyright>
//// <author>Developer</author>
//// <email>developer@company.com</email>
//// <date>09/08/2018</date>
//// <summary>Define el código para los mensajes de negocio.</summary>
//// -----------------------------------------------------------------

namespace Varo.Transversales.Mensajes
{
    /// <summary>
    /// Define el código para los mensajes técnicos.
    /// </summary>
    public abstract class CodigoMensajeTecnico
    {
        protected CodigoMensajeTecnico()
        {

        }

        /// <summary>
        /// Ups. Ocurrió un error inesperado. Contacta al administrador del sistema.
        /// </summary>
        public static int ErrorInesperado
        {
            get
            {
                return 1000;
            }
        }
    }
}

