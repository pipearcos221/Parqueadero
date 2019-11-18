using System;
using Parqueadero.Core.Domain;
using Parqueadero.Core.Domain.Enumerations;
using Xunit;

namespace Parqueadero.Core.Test
{
    public class FacturacionTest
    {
        [Fact]
        public void CalcularPrecioAPagarParaUnCarroConEstadiaDeUnDia() {
            // Arrange
            Vehiculo vehiculo = new Vehiculo(VehicleType.Carro, 1600, "BLA433", DateTime.Now.AddDays(-1));

            // Act
            int precioAPagar = vehiculo.CalcularPrecioAPagar(numeroDiasACobrar, numeroHorasACobrar);

            // Assert
            Assert.Equal(9000, precioAPagar);
        }

        [Theory]
        [InlineData(VehicleType.Carro, 1600, 1, 1)]
        [InlineData(VehicleType.Moto, 200, 2, 2)]
        [InlineData(VehicleType.Moto, 1000, 1, 6)]
        public void CalcularPrecioAPagarParaUnCarroQueNoExcedeElNumeroDeHorasParaCobroPorDia(VehicleType tipoVehiculo,int cilindraje, int numeroDiasACobrar, int numeroHorasACobrar) {
            // Arrange
            Vehiculo vehiculo = new Vehiculo(tipoVehiculo, cilindraje, "CBD432", DateTime.Now.AddDays(-numeroDiasACobrar).AddHours(-numeroHorasACobrar));

            // Act
            int precioAPagar = vehiculo.CalcularPrecioAPagar(numeroDiasACobrar, numeroHorasACobrar);

            // Assert
            Assert.Equal(9000, precioAPagar);
        }
    }
}
