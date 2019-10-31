using System;
using Parqueadero.Core.Domain;
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
            AutorizacionDeAccesoAParqueaderoImpl autorizacion = new AutorizacionDeAccesoAParqueaderoImpl();
            // act
            bool respuesta = autorizacion.ValidarAutorizacionParaAccederAlParqueadero(value);
            // assert
            Assert.True(respuesta);
        }
    }
}
