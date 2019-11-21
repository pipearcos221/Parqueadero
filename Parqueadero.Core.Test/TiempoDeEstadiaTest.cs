using System;
using Parqueadero.Core.Domain;
using Parqueadero.Core.Domain.Enumerations;
using Xunit;

namespace Parqueadero.Core.Test
{
    public class TiempoDeEstadiaTest
    {
        [Fact]
        public void ObtenerNumeroDeDiasACobrarCuandoNoExcedeLasHorasLimite()
        {
            // Arrange
            Vehiculo vehiculo = new Vehiculo(VehicleType.Carro, 1200, "CBD432", DateTime.Now.AddDays(-2));

            // Act
            int diasACobrar = vehiculo.ObtenerNumeroDeDiasDeEstadia();

            // Assert
            Assert.Equal(2, diasACobrar);
        }

        [Fact]
        public void ObtenerNumeroDeDiasACobrarCuandoSeExcedeDeLasHorasLimite()
        {
            // Arrange
            Vehiculo vehiculo = new Vehiculo(VehicleType.Carro, 1200, "CBD432", DateTime.Now.AddHours(-10));

            // Act
            int diasACobrar = vehiculo.ObtenerNumeroDeDiasDeEstadia();

            // Assert
            Assert.Equal(1, diasACobrar);
        }

        [Fact]
        public void ObtenerNumeroDeHorasDeEstadiaACobrarCuandoNoExcedeLasHorasLimite()
        {
            // Arrange
            Vehiculo vehiculo = new Vehiculo(VehicleType.Moto, 125, "CBD432", DateTime.Now.AddHours(-6));

            // Act
            int horasACobrar = vehiculo.ObtenerNumeroDeHorasDeEstadia();

            // Assert
            Assert.Equal(6, horasACobrar);
        }

        [Fact]
        public void ObtenerNumeroDeHorasDeEstadiaACobrarCuandoSeExcedeLasHorasLimite()
        {
            // Arrange
            Vehiculo vehiculo = new Vehiculo(VehicleType.Moto, 125, "CBD432", DateTime.Now.AddHours(-10));

            // Act
            int horasACobrar = vehiculo.ObtenerNumeroDeHorasDeEstadia();

            // Assert
            Assert.Equal(0, horasACobrar);
        }
    }
}
