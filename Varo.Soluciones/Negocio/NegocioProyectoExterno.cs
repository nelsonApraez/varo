
namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.SistemasExternos;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System.Collections.Generic;

    public class NegocioProyectoExterno : NegocioBase, INegocioProyectoExterno
    {
        private readonly IAdaptadorSonarExterno adaptadorSonarExterno;
        public NegocioProyectoExterno() :
            this(new RepositorioBase(), new AdaptadorSonarExterno())
        { }

        public NegocioProyectoExterno(IRepositorioBase repositorioBase
            , IAdaptadorSonarExterno adaptadorSonarExterno) : base(repositorioBase)
        {
            this.adaptadorSonarExterno = adaptadorSonarExterno;
        }

        public IList<Proyecto> ConsultarProyectos()
        {
            return this.adaptadorSonarExterno.ConsultarProyectos();
        }

        public void CrearProyecto(Proyecto proyecto)
        {

            this.adaptadorSonarExterno.CrearProyecto(proyecto);
        }

        public void InactivarProyecto(Proyecto proyecto)
        {
            this.adaptadorSonarExterno.InactivarProyecto(proyecto);
        }

        public void EditarProyecto(Proyecto proyecto)
        {
            this.adaptadorSonarExterno.ActualizarProyecto(proyecto);
        }

        public IList<Proyecto> ConsultarProyectosPorParametro(FiltroProyecto filtroProyecto)
        {
            return this.adaptadorSonarExterno.ConsultarProyectoPorParametro(filtroProyecto);
        }

    }
}

