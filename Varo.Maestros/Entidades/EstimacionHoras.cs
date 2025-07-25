namespace Varo.Maestros.Entidades
{
    using System;

    /// <summary>
    /// Proporciona las propiedades necesarias para la clase EstimacionHoras
    /// </summary>
    public class EstimacionHoras
    {
        public Guid Id { get; set; }
        public string Concepto { get; set; }
        public int HorasEstimadas { get; set; }
        public int HorasEjecutadas { get; set; }
    }
}

