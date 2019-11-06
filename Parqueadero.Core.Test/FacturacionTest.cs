using System;
using Parqueadero.Core.Domain;
using Parqueadero.Core.Domain.Enumerations;
using Xunit;

namespace Parqueadero.Core.Test
{
    public class FacturacionTest
    {
        [Theory]
        [InlineData(VehicleType.Carro, 1600, 1, 1)]
        [InlineData(VehicleType.Moto, 200, 2, 2)]
        [InlineData(VehicleType.Moto, 1000, 1, 6)]
        public void CalcularPrecioAPagarTest(VehicleType tipoVehiculo,int cilindraje, int numeroDiasACobrar, int numeroHorasACobrar) {
            // arrange
            Vehiculo vehiculo = new Vehiculo(tipoVehiculo, cilindraje, "CBD432", DateTime.Now.AddDays(-numeroDiasACobrar).AddHours(-numeroHorasACobrar));
            // act
            int precioAPagar = vehiculo.CalcularPrecioAPagar(numeroDiasACobrar, numeroHorasACobrar);
            // assert
            Assert.Equal(9000, precioAPagar);
        }
    }
}
