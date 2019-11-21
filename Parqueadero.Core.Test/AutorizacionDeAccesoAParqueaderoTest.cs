using System;
using Parqueadero.Core.Domain;
using Parqueadero.Core.Domain.Enumerations;
using Xunit;

namespace Parqueadero.Core.Test
{
    public class AutorizacionDeAccesoAParqueaderoTest
    {
        [Fact]
        public void ValidarAutorizacionParaAccederAlParqueaderoCuandoLaPlacaNoEmpiezaPorA()
        {
            // Arrange
            Vehiculo vehiculo = new Vehiculo(VehicleType.Moto, 125, "DFQ566", DateTime.Now);

            // Act
            bool respuesta = vehiculo.VerificarAutorizacionDeAccesoAlParqueadero();

            // Assert
            Assert.True(respuesta);
        }

        [Fact]
        public void ValidarAutorizacionParaAccederAlParqueaderoCuandoLaPlacaEmpiezaPorAYElDiaActualEsUnDiaRestringido()
        {
            // Arrange
            DateTime diaDomingo = new DateTime(2019, 11, 10);
            Vehiculo vehiculo = new Vehiculo(VehicleType.Moto, 125, "ACQ856", diaDomingo);

            // Act
            bool respuesta = vehiculo.VerificarAutorizacionDeAccesoAlParqueadero();

            // Assert
            Assert.False(respuesta);
        }

        [Fact]
        public void ValidarAutorizacionParaAccederAlParqueaderoCuandoLaPlacaEmpiezaPorAYElDiaActualNoEsUnDiaRestringido()
        {
            // Arrange
            DateTime diaMartes = new DateTime(2019, 11, 12);
            Vehiculo vehiculo = new Vehiculo(VehicleType.Moto, 125, "ACQ856", diaMartes);

            // Act
            bool respuesta = vehiculo.VerificarAutorizacionDeAccesoAlParqueadero();

            // Assert
            Assert.True(respuesta);
        }
    }
}
