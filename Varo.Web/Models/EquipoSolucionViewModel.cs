namespace Varo.Web.Models
{
    using Varo.Soluciones.Entidades;
    using System;
    public class EquipoSolucionViewModel
    {
        public EquipoSolucionViewModel()
        {
            this.EquipoSolucion = new EquipoSolucion();
        }
        public Guid Id { get; set; }
        public Guid IdSolucion { get; set; }
        public string Nombre { get; set; }
        public EquipoSolucion EquipoSolucion { get; set; }
    }
}
