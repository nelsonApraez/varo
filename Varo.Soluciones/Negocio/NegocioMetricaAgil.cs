namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Constantes;
    using Varo.Transversales.Excepciones;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Transactions;

    public class NegocioMetricaAgil : NegocioBase, INegocioMetricaAgil
    {
        private readonly IRepositorioMetricaAgil repositorioMetricasAgiles;
        private readonly IRepositorioHistoriayEsfuerzo repositorioHistoriayEsfuerzo;
        private readonly IRepositorioHistoria repositorioHistoria;
        private readonly IRepositorioDefectoInterno repositorioDefectoInterno;
        private readonly IRepositorioDefectoExterno repositorioDefectoExterno;
        private readonly IRepositorioIncendio repositorioIncendio;
        private readonly IRepositorioCalidadCodigo repositorioCalidadCodigo;
        private readonly IRepositorioAccionMejora repositorioAccionMejora;
        private readonly IRepositorioSeguimiento repositorioSeguimiento;
        private readonly IRepositorioSolucion repositorioSolucion;
        public NegocioMetricaAgil() : this(
            new RepositorioBase(),
            new RepositorioMetricaAgil(),
            new RepositorioHistoriayEsfuerzo(),
            new RepositorioHistoria(),
            new RepositorioDefectoInterno(),
            new RepositorioDefectoExterno(),
            new RepositorioIncendio(),
            new RepositorioCalidadCodigo(),
            new RepositorioAccionMejora(),
            new RepositorioSeguimiento(),
            new RepositorioSolucion())
        { }

        public NegocioMetricaAgil(IRepositorioBase repositorioBase,
                                IRepositorioMetricaAgil repositorioMetricasAgiles,
                                IRepositorioHistoriayEsfuerzo repositorioHistoriayEsfuerzo,
                                IRepositorioHistoria repositorioHistoria,
                                IRepositorioDefectoInterno repositorioDefectoInterno,
                                IRepositorioDefectoExterno repositorioDefectoExterno,
                                IRepositorioIncendio repositorioIncendio,
                                IRepositorioCalidadCodigo repositorioCalidadCodigo,
                                IRepositorioAccionMejora repositorioAccionMejora,
                                IRepositorioSeguimiento repositorioSeguimiento,
                                IRepositorioSolucion repositorioSolucion) : base(repositorioBase)
        {
            this.repositorioMetricasAgiles = repositorioMetricasAgiles;
            this.repositorioHistoriayEsfuerzo = repositorioHistoriayEsfuerzo;
            this.repositorioHistoria = repositorioHistoria;
            this.repositorioDefectoInterno = repositorioDefectoInterno;
            this.repositorioDefectoExterno = repositorioDefectoExterno;
            this.repositorioIncendio = repositorioIncendio;
            this.repositorioCalidadCodigo = repositorioCalidadCodigo;
            this.repositorioAccionMejora = repositorioAccionMejora;
            this.repositorioSeguimiento = repositorioSeguimiento;
            this.repositorioSolucion = repositorioSolucion;
        }

        public IList<MetricasAgiles> Consultar(Guid idSolucion)
        {
            return this.repositorioMetricasAgiles.Consultar(idSolucion);
        }

        public void Crear(MetricasAgiles metricasAgiles)
        {
            if (metricasAgiles != null)
            {

                if (metricasAgiles.ListaMetricasAgiles.Select(i => new { i.Sprint, i.IdEquipo }).Distinct().Count() !=
                    metricasAgiles.ListaMetricasAgiles.Select(i => new { i.Sprint, i.IdEquipo }).Count() ||
                    metricasAgiles.ListaMetricasAgiles.Select(i => new { i.FechaInicial, i.IdEquipo }).Distinct().Count() !=
                    metricasAgiles.ListaMetricasAgiles.Select(i => new { i.FechaInicial, i.IdEquipo }).Count() ||
                    metricasAgiles.ListaMetricasAgiles.Select(i => new { i.FechaFinal, i.IdEquipo }).Distinct().Count() !=
                    metricasAgiles.ListaMetricasAgiles.Select(i => new { i.FechaFinal, i.IdEquipo }).Count())
                {
                    throw new NegocioExcepcion(Recursos.Lenguaje.MensajeFechasDuplicadas);
                }
                var listaSprintNuevos = metricasAgiles.ListaMetricasAgiles;

                for (int i = 0; i < listaSprintNuevos.Count; i++)
                {
                    for (int j = i + 1; j < listaSprintNuevos.Count; j++)
                    {
                        if (listaSprintNuevos[i].FechaInicial < listaSprintNuevos[j].FechaFinal &&
                            listaSprintNuevos[j].FechaInicial < listaSprintNuevos[i].FechaFinal &&
                            listaSprintNuevos[i].IdEquipo == listaSprintNuevos[j].IdEquipo)
                        {
                            throw new NegocioExcepcion(Recursos.Lenguaje.MensajeFechaNoConcuerda);
                        }
                    }

                }

                metricasAgiles.ListaMetricasAgiles.ToList().ForEach(c => c.IdSolucion = metricasAgiles.IdSolucion);
                IList<MetricasAgiles> listaMetricasAgiles;
                listaMetricasAgiles = this.repositorioMetricasAgiles.Consultar(metricasAgiles.IdSolucion);
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    foreach (var itemMetrica in listaMetricasAgiles)
                    {
                        if (metricasAgiles.ListaMetricasAgiles.Any(i => i.Id == itemMetrica.Id))
                        {
                            this.repositorioMetricasAgiles.Actualizar(metricasAgiles.ListaMetricasAgiles.FirstOrDefault(i => i.Id == itemMetrica.Id));
                        }
                        if (!metricasAgiles.ListaMetricasAgiles.Any(i => i.Id == itemMetrica.Id))
                        {
                            var historias = this.repositorioHistoria.ObtenerPorMetricaAgil(itemMetrica.Id);
                            if (historias.Count > 0)
                            {
                                throw new NegocioExcepcion(Recursos.Lenguaje.MensajeErrorEliminarMetrica);
                            }
                            this.repositorioHistoriayEsfuerzo.Eliminar(itemMetrica.Id);
                            this.repositorioHistoria.Eliminar(itemMetrica.Id);
                            this.repositorioDefectoInterno.Eliminar(itemMetrica.Id);
                            this.repositorioDefectoExterno.Eliminar(itemMetrica.Id);
                            if (this.repositorioSolucion.ObtenerIdMarcoTrabajo(itemMetrica.Id) == NumerosConstantes.IdScrumban)
                            {
                                this.repositorioIncendio.Eliminar(itemMetrica.Id);
                            }

                            this.repositorioCalidadCodigo.Eliminar(itemMetrica.Id);
                            var listaAccionesMejoraExistentes = this.repositorioAccionMejora.ObtenerPorMetricaAgil(itemMetrica.Id);
                            foreach (var itemAccionMejora in listaAccionesMejoraExistentes)
                            {
                                this.repositorioSeguimiento.Eliminar(itemAccionMejora.Id);
                                this.repositorioAccionMejora.Eliminar(itemAccionMejora.Id);
                            }

                            this.repositorioMetricasAgiles.Eliminar(itemMetrica.Id);
                        }
                    }
                    foreach (var itemMetrica in metricasAgiles.ListaMetricasAgiles.Where(i => i.Id == 0))
                    {
                        this.repositorioMetricasAgiles.Crear(itemMetrica);
                    }
                    transactionScope.Complete();
                }
            }
        }

        public void Actualizar(HistoriasyEsfuerzos historiasyEsfuerzos
                              , Historias historias
                              , DefectosInternos defectosInternos
                              , DefectosExternos defectosExternos
                              , Incendios incendios
                              , CalidadCodigo calidadCodigo
                              , AccionesMejora accionesMejora)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                this.repositorioHistoriayEsfuerzo.Eliminar(historiasyEsfuerzos.IdMetricaAgil);
                this.repositorioHistoriayEsfuerzo.Crear(historiasyEsfuerzos);
                this.repositorioHistoria.Eliminar(historias.IdMetricaAgil);
                this.repositorioHistoria.Crear(historias);
                this.repositorioDefectoInterno.Eliminar(defectosInternos.IdMetricaAgil);
                this.repositorioDefectoInterno.Crear(defectosInternos);
                this.repositorioDefectoExterno.Eliminar(defectosExternos.IdMetricaAgil);
                this.repositorioDefectoExterno.Crear(defectosExternos);

                if (this.repositorioSolucion.ObtenerIdMarcoTrabajo(historiasyEsfuerzos.IdMetricaAgil) == NumerosConstantes.IdScrumban)
                {
                    this.repositorioIncendio.Eliminar(incendios.IdMetricaAgil);
                    this.repositorioIncendio.Crear(incendios);
                }

                this.repositorioCalidadCodigo.Eliminar(calidadCodigo.IdMetricaAgil);
                this.repositorioCalidadCodigo.Crear(calidadCodigo);

                var listaAccionesMejoraExistente = this.repositorioAccionMejora.ObtenerPorMetricaAgil(accionesMejora.IdMetricaAgil);
                foreach (var itemAccionMejora in listaAccionesMejoraExistente)
                {
                    if (accionesMejora.ListaAccionesMejora.Any(i => i.Id == itemAccionMejora.Id))
                    {
                        this.repositorioAccionMejora.Editar(accionesMejora.ListaAccionesMejora.FirstOrDefault(i => i.Id == itemAccionMejora.Id));
                    }
                    else
                    {
                        this.repositorioSeguimiento.Eliminar(itemAccionMejora.Id);
                        this.repositorioAccionMejora.Eliminar(itemAccionMejora.Id);
                    }
                }

                foreach (var itemAccionMejora in accionesMejora.ListaAccionesMejora.Where(i => i.Id == 0))
                {
                    this.repositorioAccionMejora.Crear(itemAccionMejora);
                }

                transactionScope.Complete();
            }
        }

        public IList<MetricasAgiles> ConsultarPorParametro(Guid idSolucion, string parametro)
        {
            return this.repositorioMetricasAgiles.ConsultarPorParametro(idSolucion, parametro);
        }
    }
}

