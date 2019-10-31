using System;
using Parqueadero.Core.Domain.Interfaces;
using Xunit;
namespace Parqueadero.Core.Test
{
    public class DisponibilidadDeEspacioTest
    {
        [Fact]
        public void VerificarDisponibilidadDeEspacioDeParqueoTest()
        {
            // arrange
            DisponibilidadDeEspacioImpl disponibilidad = new DisponibilidadDeEspacioImpl();
            // act
            bool respuesta = disponibilidad.VerificarDisponibilidadDeEspacioDeParqueo(19, 10, 1);
            // assert
            Assert.True(respuesta);
        }
    }
}
