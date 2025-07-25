namespace Varo.Transversales.Excepciones
{
    using System;

    [Serializable]
    public class JsonVacioExcepcion : Exception
    {
        public JsonVacioExcepcion()
        {
        }

        public JsonVacioExcepcion(string mensaje) : base(mensaje)
        {
        }
    }
}

