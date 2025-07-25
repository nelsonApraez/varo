namespace Varo.Web.Models
{
    using System.ComponentModel;

    public class IncendiosViewModel
    {
        public int IdIncendios { get; set; }
        [DefaultValue(true)]
        public int? ReportadosIncendios { get; set; }
        [DefaultValue(true)]
        public int? SolucionadosIncendios { get; set; }
        public string ObservacionesIncendios { get; set; }
    }
}
