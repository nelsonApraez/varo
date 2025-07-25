namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Excepciones;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Transactions;
    public class NegocioEquipoSolucion : NegocioBase, INegocioEquipoSolucion
    {
        private readonly IRepositorioEquipoSolucion repositorioEquipoSolucion;

        public NegocioEquipoSolucion() :
            this(
                new RepositorioBase(),
                new RepositorioEquipoSolucion())
        { }

        public NegocioEquipoSolucion(
            IRepositorioBase repositorioBase,
            IRepositorioEquipoSolucion repositorioEquipoSolucion) :
            base(repositorioBase)
        {
            this.repositorioEquipoSolucion = repositorioEquipoSolucion;
        }

        public void Crear(EquipoSolucion equipoSolucion)
        {
            IList<EquipoSolucion> listaEquipos;
            listaEquipos = this.repositorioEquipoSolucion.Consultar(equipoSolucion.IdSolucion);
            using (TransactionScope transactionScope = new TransactionScope())
            {
                foreach (var itemEquipo in listaEquipos)
                {
                    if (equipoSolucion.ListaEquipoSolucion.Any(i => i.Id == itemEquipo.Id))
                    {
                        this.repositorioEquipoSolucion.Editar(equipoSolucion.ListaEquipoSolucion.FirstOrDefault(i => i.Id == itemEquipo.Id));
                    }
                    if (!equipoSolucion.ListaEquipoSolucion.Any(i => i.Id == itemEquipo.Id))
                    {
                        var listaMetricas = this.repositorioEquipoSolucion.ConsultarMetricaPorIdEquipo(itemEquipo.Id);
                        if (listaMetricas.Count > 0)
                        {
                            throw new NegocioExcepcion(Recursos.Lenguaje.MensajeErrorEliminarEquipo);
                        }

                        this.repositorioEquipoSolucion.Eliminar(itemEquipo.Id);
                    }
                }
                foreach (var itemMetrica in equipoSolucion.ListaEquipoSolucion.Where(i => i.Id == Guid.Empty))
                {
                    itemMetrica.IdSolucion = equipoSolucion.IdSolucion;
                    this.repositorioEquipoSolucion.Crear(itemMetrica);
                }
                transactionScope.Complete();
            }

        }

        public IList<EquipoSolucion> Consultar(Guid idSolucion)
        {
            return this.repositorioEquipoSolucion.Consultar(idSolucion);
        }


        public void Eliminar(Guid idSolucion)
        {
            this.repositorioEquipoSolucion.EliminarPorIdSolucion(idSolucion);
        }
    }
}

