using Varo.Soluciones.Entidades;
using Varo.Soluciones.Negocio;
using Varo.Soluciones.Repositorio;
using Varo.Transversales.Repositorio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Varo.Soluciones.Test
{
    [TestClass]
    public class CorreoNotificacionesTest
    {
        private Mock<IRepositorioBase> repositorioBase = null;
        private Mock<IRepositorioNotificaciones> repositorioCorreoNotificaciones = null;
        private INegocioNotificaciones negocioCorreoNotificaciones = null;
        private int idCorreoNotificaciones = 7;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.repositorioBase = new Mock<IRepositorioBase>();
            this.repositorioCorreoNotificaciones = new Mock<IRepositorioNotificaciones>();

            this.negocioCorreoNotificaciones =
                new NegocioNotificaciones(this.repositorioBase.Object,
                    this.repositorioCorreoNotificaciones.Object);
        }

        [TestMethod]
        public void ConsultarCorreoNotificaciones()
        {
            IList<Notificaciones> listadoNotificacionesActual;
            IList<Notificaciones> listadoNotificacionesEsperado = new List<Notificaciones>()
            {
                new Notificaciones
                {
                    Id = idCorreoNotificaciones,
                    Valor = "prueba@company.com"

                }
            };

            this.repositorioCorreoNotificaciones.Setup(
                it => it
                .Consultar(It.IsAny<string>()))
                .Returns(
                    new List<Notificaciones>()
                    {
                        new Notificaciones
                        {
                            Id = idCorreoNotificaciones,
                            Valor = "prueba@company.com"
                        }
                    }
                );

            listadoNotificacionesActual = this.negocioCorreoNotificaciones.Consultar("EN");

            Assert.AreEqual(listadoNotificacionesEsperado.Count, listadoNotificacionesActual.Count);
            Assert.AreEqual(listadoNotificacionesEsperado[0].Id, listadoNotificacionesActual[0].Id);
        }


        [TestMethod]
        public void Editar()
        {
            this.repositorioCorreoNotificaciones.Setup(
               it => it
               .Consultar(It.IsAny<string>()))
               .Returns(
                   new List<Notificaciones>()
                   {
                        new Notificaciones
                        {
                            Id = idCorreoNotificaciones,
                            Valor = "prueba@company.com"

                        }
                   }
               );

            Notificaciones notificacion = new Notificaciones
            {
                Id = idCorreoNotificaciones,
                Valor = "prueba2@company.com"

            };

            this.repositorioCorreoNotificaciones.Setup(
                it => it
                .Editar(It.IsAny<Notificaciones>()));

            this.negocioCorreoNotificaciones.Editar(notificacion);


        }

    }
}

