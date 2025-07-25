
namespace Varo.Soluciones.Entidades
{
    using System;
    using System.Collections.Generic;

    public class IntegracionesContinuas
    {
        public Guid Id { get; set; }

        public Guid IdSolucion { get; set; }

        public string Nombre { get; set; }

        public string UrlCompilacion { get; set; }

        public int IdProyectoInspeccion { get; set; }

        public string NombreProyectoInspeccion { get; set; }

        public IList<IntegracionesContinuas> ListaIntegracionesContinuas { get; set; }
    }
}

