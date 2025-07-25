//// --------------------------------------------------------------------------------
//// <copyright file="DesplieguesContinuos.cs">Company S.A.</copyright>
//// <author>Nelson Apraez</author>
//// <email>developer@company.com</email>
//// <date>09/09/2018</date>
//// <summary>Proporciona las propiedades necesarias para la clase DesplieguesContinuos</summary>
//// --------------------------------------------------------------------------------

namespace Varo.Soluciones.Entidades
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proporciona las propiedades necesarias para la clase DesplieguesContinuos
    /// </summary>
    public class DesplieguesContinuos
    {
        public Guid Id { get; set; }

        public Guid IdSolucion { get; set; }

        public string Nombre { get; set; }

        public string UrlDespliegue { get; set; }

        public IList<DesplieguesContinuos> ListaDeplieguesContinuos { get; set; }
    }
}

