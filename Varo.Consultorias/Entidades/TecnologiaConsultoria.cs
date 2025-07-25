namespace Varo.Consultorias.Entidades
{
    using Varo.Maestros.Entidades;
    using System;
    using System.Collections.Generic;

    public class TecnologiaConsultoria
    {
        public Guid IdConsultoria { get; set; }
        public IList<Tecnologia> Tecnologias { get; set; }
    }
}

