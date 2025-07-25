namespace Varo.Web.Models
{
    public class PaginadorViewModel<T>
    {
        public Paginador Paginador { get; set; }
        public T EntidadViewModel { get; set; }
        public int CampoSeleccionado { get; set; }
        public string UsuarioLogueado { get; set; }
    }
}

