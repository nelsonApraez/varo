
namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using System.Collections.Generic;

    public interface INegocioProyectoExterno
    {
        IList<Proyecto> ConsultarProyectos();

        void InactivarProyecto(Proyecto proyecto);

        void CrearProyecto(Proyecto proyecto);

        void EditarProyecto(Proyecto proyecto);

        IList<Proyecto> ConsultarProyectosPorParametro(FiltroProyecto filtroProyecto);
    }
}

