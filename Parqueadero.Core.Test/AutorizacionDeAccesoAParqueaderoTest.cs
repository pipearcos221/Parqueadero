using System;
using Parqueadero.Core.Domain;
using Parqueadero.Core.Domain.Enumerations;
using Xunit;

namespace Parqueadero.Core.Test
{
    public class AutorizacionDeAccesoAParqueaderoTest
    {
        [Theory]
        [InlineData("DFQ566")]
        [InlineData("ACQ856")]
        public void ValidarAutorizacionParaAccederAlParqueaderoTest(string value)
        {
            // arrange
            Vehiculo vehiculo = new Vehiculo(VehicleType.Moto, 125, value, DateTime.Now.AddDays(-2));
            // act
            bool respuesta = vehiculo.VerificarAutorizacionDeAccesoAlParqueadero();
            // assert
            Assert.True(respuesta);
        }
    }
}
