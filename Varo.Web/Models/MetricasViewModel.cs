namespace Varo.Web.Models
{
    public class MetricasViewModel
    {
        public MetricasViewModel()
        {
            this.historiasyEsfuerzosViewModel = new HistoriasyEsfuerzosViewModel();
            this.historiasViewModel = new HistoriasViewModel();
            this.defectosInternosViewModel = new DefectosInternosViewModel();
            this.defectosExternosViewModel = new DefectosExternosViewModel();
            this.incendiosViewModel = new IncendiosViewModel();
            this.calidadCodigoViewModel = new CalidadCodigoViewModel();
            this.accionesMejoraViewModel = new AccionesMejoraViewModel();
        }
        public string sprint { get; set; }
        public bool mostrarIncendios { get; set; }
        public HistoriasyEsfuerzosViewModel historiasyEsfuerzosViewModel { get; set; }
        public HistoriasViewModel historiasViewModel { get; set; }
        public DefectosInternosViewModel defectosInternosViewModel { get; set; }
        public DefectosExternosViewModel defectosExternosViewModel { get; set; }
        public IncendiosViewModel incendiosViewModel { get; set; }
        public CalidadCodigoViewModel calidadCodigoViewModel { get; set; }
        public AccionesMejoraViewModel accionesMejoraViewModel { get; set; }
    }
}
