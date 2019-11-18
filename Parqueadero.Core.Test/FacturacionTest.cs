using System;
using Parqueadero.Core.Domain;
using Parqueadero.Core.Domain.Enumerations;
using Xunit;

namespace Parqueadero.Core.Test
{
    public class FacturacionTest
    {
        [Fact]
        public void CalcularPrecioAPagarParaUnCarroConEstadiaDeUnDia()
        {
            // Arrange
            Vehiculo vehiculo = new Vehiculo(VehicleType.Carro, 1600, "BLA433", DateTime.Now.AddDays(-1));
            int numeroDiasACobrar = 1;
            int numeroHorasACobrar = 0;

            // Act
            int precioAPagar = vehiculo.CalcularPrecioAPagar(numeroDiasACobrar, numeroHorasACobrar);

            // Assert
            Assert.Equal(8000, precioAPagar);
        }

        [Fact]
        public void CalcularPrecioAPagarParaUnCarroConEstadiaDeUnaHora()
        {
            // Arrange
            Vehiculo vehiculo = new Vehiculo(VehicleType.Carro, 1600, "BLA433", DateTime.Now.AddHours(-1));
            int numeroDiasACobrar = 0;
            int numeroHorasACobrar = 1;

            // Act
            int precioAPagar = vehiculo.CalcularPrecioAPagar(numeroDiasACobrar, numeroHorasACobrar);

            // Assert
            Assert.Equal(1000, precioAPagar);
        }

        [Fact]
        public void CalcularPrecioAPagarParaUnaMotoConEstadiaDeUnDiaSinExcedentePorCilindraje()
        {
            // Arrange
            Vehiculo vehiculo = new Vehiculo(VehicleType.Moto, 200, "Pk205R", DateTime.Now.AddDays(-1));
            int numeroDiasACobrar = 1;
            int numeroHorasACobrar = 0;

            // Act
            int precioAPagar = vehiculo.CalcularPrecioAPagar(numeroDiasACobrar, numeroHorasACobrar);

            // Assert
            Assert.Equal(4000, precioAPagar);
        }

        [Fact]
        public void CalcularPrecioAPagarParaUnaMotoConEstadiaDeUnaHoraSinExcedentePorCilindraje()
        {
            // Arrange
            Vehiculo vehiculo = new Vehiculo(VehicleType.Moto, 200, "Pk205R", DateTime.Now.AddHours(-1));
            int numeroDiasACobrar = 0;
            int numeroHorasACobrar = 1;

            // Act
            int precioAPagar = vehiculo.CalcularPrecioAPagar(numeroDiasACobrar, numeroHorasACobrar);

            // Assert
            Assert.Equal(500, precioAPagar);
        }

        [Fact]
        public void CalcularPrecioAPagarParaUnaMotoConEstadiaDeUnDiaConExcedentePorCilindraje()
        {
            // Arrange
            Vehiculo vehiculo = new Vehiculo(VehicleType.Moto, 600, "Pk205R", DateTime.Now.AddDays(-1));
            int numeroDiasACobrar = 1;
            int numeroHorasACobrar = 0;

            // Act
            int precioAPagar = vehiculo.CalcularPrecioAPagar(numeroDiasACobrar, numeroHorasACobrar);

            // Assert
            Assert.Equal(6000, precioAPagar);
        }

        [Fact]
        public void CalcularPrecioAPagarParaUnaMotoConEstadiaDeUnaHoraConExcedentePorCilindraje()
        {
            // Arrange
            Vehiculo vehiculo = new Vehiculo(VehicleType.Moto, 600, "Pk205R", DateTime.Now.AddHours(-1));
            int numeroDiasACobrar = 0;
            int numeroHorasACobrar = 1;

            // Act
            int precioAPagar = vehiculo.CalcularPrecioAPagar(numeroDiasACobrar, numeroHorasACobrar);

            // Assert
            Assert.Equal(2500, precioAPagar);
        }
    }
}
