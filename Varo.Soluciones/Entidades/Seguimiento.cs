namespace Varo.Soluciones.Entidades
{
    using System;
    using System.Collections.Generic;

    public class Seguimiento
    {
        public int Id { get; set; }

        public int IdAccionesMejora { get; set; }

        public string Observacion { get; set; }

        public DateTime Fecha { get; set; }

        public String Usuario { get; set; }
        public IList<Seguimiento> ListaSeguimiento { get; set; }
    }
}

