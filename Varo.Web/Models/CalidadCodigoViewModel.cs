namespace Varo.Web.Models
{
    public class CalidadCodigoViewModel
    {
        public int IdCalidadCodigo { get; set; }
        public int? Bugs { get; set; }
        public int? Vulnerabilidades { get; set; }
        public string DeudaTecnica { get; set; }
        public string Cobertura { get; set; }
        public string Duplicado { get; set; }
        public string ObservacionesdeCalidadCodigo { get; set; }
    }
}
