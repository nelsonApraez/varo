// -------------------------------------------------------------------------------
// <copyright file="NegocioSoluciones.cs" company="Company S.A.">
//     COPYRIGHT(C) 2018, Company S.A.
// </copyright>
// <author>Developer</author>
// <email>developer@company.com</email>
// <date>09/08/2018</date>
// <summary>Implementa las funcionalidades de negocio para las soluciones.</summary>
// -------------------------------------------------------------------------------

namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.SistemasExternos;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;

    public class NegocioInspeccionContinua : NegocioBase, INegocioInspeccionContinua
    {
        private readonly IAdaptadorInspeccionTecnica adapatadorInspeccionTecnica;

        public NegocioInspeccionContinua() :
            this(
                new RepositorioBase(),
                new AdaptadorInspeccionTecnica())
        { }

        public NegocioInspeccionContinua(
            IRepositorioBase repositorioBase,
            IAdaptadorInspeccionTecnica adaptadorInspeccionTecnica) :
            base(repositorioBase)
        {
            this.adapatadorInspeccionTecnica = adaptadorInspeccionTecnica;
        }

        public IList<InspeccionesContinuas> Consultar()
        {
            return this.adapatadorInspeccionTecnica.ConsultarProyectos();
        }

        public ValorMetricaSolucion ConsultarValorMetricaPorSolucion(Guid idSolucion)
        {
            ValorMetricaSolucion valorMetricaSolucion = this.adapatadorInspeccionTecnica.ConsultarValorMetricaPorSolucion(idSolucion);

            return valorMetricaSolucion;
        }

    }
}

