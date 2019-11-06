using System;
using Parqueadero.Core.Domain;
using Parqueadero.Core.Domain.Enumerations;
using Xunit;
namespace Parqueadero.Core.Test
{
    public class DisponibilidadDeEspacioTest
    {
        [Theory]
        [InlineData(VehicleType.Carro, 20, 10)]
        [InlineData(VehicleType.Carro, 19, 10)]
        [InlineData(VehicleType.Moto, 20, 10)]
        [InlineData(VehicleType.Moto, 20, 9)]
        public void VerificarDisponibilidadDeEspacioDeParqueoTest(VehicleType tipo, int numeroDeCarrosEnParqueadero, int numeroDeMotosEnParqueadero)
        {
            // arrange
            Vehiculo vehiculo = new Vehiculo(tipo, 125, "CBD432", DateTime.Now);
            // act
            bool respuesta = vehiculo.VerificarDisponibilidadDeEspacioLibreEnParqueadero(numeroDeCarrosEnParqueadero, numeroDeMotosEnParqueadero);
            // assert
            Assert.True(respuesta);
        }
    }
}
