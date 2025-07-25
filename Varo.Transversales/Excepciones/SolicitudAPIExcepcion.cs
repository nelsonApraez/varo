namespace Varo.Transversales.Excepciones
{
    using System;

    [Serializable]
    public class SolicitudAPIExcepcion : Exception
    {
        public SolicitudAPIExcepcion()
        {
        }

        public SolicitudAPIExcepcion(string mensaje) : base(mensaje)
        {
        }
    }
}

