using System;
using Parqueadero.Core.Domain;
using Parqueadero.Core.Domain.Enumerations;
using Xunit;
namespace Parqueadero.Core.Test
{
    public class DisponibilidadDeEspacioTest
    {
        [Fact]
        public void VerificarDisponibilidadDeEspacioDeParqueoCuandoEsUnCarroYNoHayEspacio()
        {
            // Arrange
            Vehiculo vehiculo = new Vehiculo(VehicleType.Carro, 125, "CBD432", DateTime.Now);
            int numeroDeCarrosEnParqueadero = 20;
            int numeroDeMotosEnParqueadero = 10;

            // Act
            bool respuesta = vehiculo.VerificarDisponibilidadDeEspacioLibreEnParqueadero(numeroDeCarrosEnParqueadero, numeroDeMotosEnParqueadero);

            // Assert
            Assert.False(respuesta);
        }

        [Fact]
        public void VerificarDisponibilidadDeEspacioDeParqueoCuandoEsUnCarroYSiHayEspacio()
        {
            // Arrange
            Vehiculo vehiculo = new Vehiculo(VehicleType.Carro, 125, "CBD432", DateTime.Now);
            int numeroDeCarrosEnParqueadero = 10;
            int numeroDeMotosEnParqueadero = 10;

            // Act
            bool respuesta = vehiculo.VerificarDisponibilidadDeEspacioLibreEnParqueadero(numeroDeCarrosEnParqueadero, numeroDeMotosEnParqueadero);

            // Assert
            Assert.True(respuesta);
        }

        [Fact]
        public void VerificarDisponibilidadDeEspacioDeParqueoCuandoEsUnaMotoYNoHayEspacio()
        {
            // Arrange
            Vehiculo vehiculo = new Vehiculo(VehicleType.Moto, 125, "CBD432", DateTime.Now);
            int numeroDeCarrosEnParqueadero = 20;
            int numeroDeMotosEnParqueadero = 10;

            // Act
            bool respuesta = vehiculo.VerificarDisponibilidadDeEspacioLibreEnParqueadero(numeroDeCarrosEnParqueadero, numeroDeMotosEnParqueadero);

            // Assert
            Assert.False(respuesta);
        }

        [Fact]
        public void VerificarDisponibilidadDeEspacioDeParqueoCuandoEsUnaMotoYSiHayEspacio()
        {
            // Arrange
            Vehiculo vehiculo = new Vehiculo(VehicleType.Moto, 125, "CBD432", DateTime.Now);
            int numeroDeCarrosEnParqueadero = 10;
            int numeroDeMotosEnParqueadero = 5;

            // Act
            bool respuesta = vehiculo.VerificarDisponibilidadDeEspacioLibreEnParqueadero(numeroDeCarrosEnParqueadero, numeroDeMotosEnParqueadero);

            // Assert
            Assert.True(respuesta);
        }
    }
}
