namespace Varo.Maestros.Test
{
    using Varo.Maestros.Entidades;
    using Varo.Maestros.Negocio;
    using Varo.Maestros.SistemasExternos;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Collections.Generic;

    /// <summary>
    /// Summary description for SolucionesConsultarClientesPorIdPaisTest
    /// </summary>
    [TestClass]
    public class ClienteTest
    {
        private Mock<IAdaptadorClientes> adaptadorClientes = null;
        private INegocioClientes negocioClientes = null;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.adaptadorClientes = new Mock<IAdaptadorClientes>();

            this.negocioClientes =
                new NegocioClientes(this.adaptadorClientes.Object);
        }

        [TestMethod]
        public void ConsultarClientesTest()
        {
            IList<Cliente> clientesActual;
            IList<Cliente> clientesEsperado = new List<Cliente>()
            {
                new Cliente
                {
                    Id = 1,
                    Name = "Cliente 1"
                }
            };

            this.adaptadorClientes.Setup(
                it => it
                .ConsultarClientes())
                .Returns(
                    new List<Cliente>()
                    {
                        new Cliente
                        {
                            Id = 1,
                            Name = "Cliente 1"
                        }
                    }
                );

            clientesActual = this.negocioClientes.ConsultarClientes();

            Assert.AreEqual(clientesEsperado.Count, clientesActual.Count);
            Assert.AreEqual(clientesEsperado[0].Id, clientesActual[0].Id);
        }

        [TestMethod]
        public void ConsultarClientesSinResultadoTest()
        {
            IList<Cliente> clientesActual;
            IList<Cliente> clientesEsperado = new List<Cliente>();

            this.adaptadorClientes.Setup(
                it => it
                .ConsultarClientes())
                .Returns(
                    new List<Cliente>()
                );

            clientesActual = this.negocioClientes.ConsultarClientes();

            Assert.AreEqual(clientesEsperado.Count, clientesActual.Count);
        }

        [TestMethod]
        public void ObtenerClientePorIdTest()
        {
            byte idCliente = 1;
            Cliente clienteActual;
            Cliente clienteEsperado = new Cliente
            {
                Id = 1,
                Name = "Cliente 1"
            };

            this.adaptadorClientes.Setup(
                it => it
                .ConsultarClientes())
                .Returns(
                    new List<Cliente>()
                    {
                        new Cliente
                        {
                            Id = 1,
                            Name = "Cliente 1"
                        },
                        new Cliente
                        {
                            Id = 2,
                            Name = "Cliente 2"
                        }
                    }
                );

            clienteActual = this.negocioClientes.ObtenerClientePorId(idCliente);

            Assert.AreEqual(clienteEsperado.Id, clienteActual.Id);
        }

        [TestMethod]
        public void ObtenerClientePorIdSinClienteTest()
        {
            byte idCliente = 3;
            Cliente clienteActual;

            this.adaptadorClientes.Setup(
                it => it
                .ConsultarClientes())
                .Returns(
                    new List<Cliente>()
                    {
                        new Cliente
                        {
                            Id = 1,
                            Name = "Cliente 1"
                        },
                        new Cliente
                        {
                            Id = 2,
                            Name = "Cliente 2"
                        }
                    }
                );

            clienteActual = this.negocioClientes.ObtenerClientePorId(idCliente);

            Assert.IsNull(clienteActual);
        }

        [TestMethod]
        public void ObtenerClientePorNombreTest()
        {
            string nombreCliente = "Cliente 1";
            IList<string> clienteActual;
            IList<string> clienteEsperado = new List<string> { "1" };

            this.adaptadorClientes.Setup(
                it => it
                .ConsultarClientes())
                .Returns(
                    new List<Cliente>()
                    {
                        new Cliente
                        {
                            Id = 1,
                            Name = "Cliente 1"
                        },
                        new Cliente
                        {
                            Id = 2,
                            Name = "Cliente 2"
                        }
                    }
                );

            clienteActual = this.negocioClientes.ObtenerIdClientePorNombre(nombreCliente);

            Assert.AreEqual(clienteEsperado.Count, clienteActual.Count);
            Assert.AreEqual(clienteEsperado[0], clienteActual[0]);
        }

        [TestMethod]
        public void ObtenerClientePorNombreSinClienteTest()
        {
            string nombreCliente = "Cliente 3";
            IList<string> clienteActual;
            IList<string> clienteEsperado = new List<string>();

            this.adaptadorClientes.Setup(
                it => it
                .ConsultarClientes())
                .Returns(
                    new List<Cliente>()
                    {
                        new Cliente
                        {
                            Id = 1,
                            Name = "Cliente 1"
                        },
                        new Cliente
                        {
                            Id = 2,
                            Name = "Cliente 2"
                        }
                    }
                );

            clienteActual = this.negocioClientes.ObtenerIdClientePorNombre(nombreCliente);

            Assert.AreEqual(clienteEsperado.Count, clienteActual.Count);
        }
    }
}

