using System;
using Parqueadero.Core.Domain;
using Xunit;

namespace Parqueadero.Core.Test
{
    public class AutorizacionDeAccesoAParqueaderoTest
    {
        [Fact]
        public void ValidarAutorizacionParaAccederAlParqueaderoTest()
        {
            // arrange
            AutorizacionDeAccesoAParqueaderoImpl autorizacion = new AutorizacionDeAccesoAParqueaderoImpl();
            // act
            bool respuesta = autorizacion.ValidarAutorizacionParaAccederAlParqueadero("DFQ566");
            // assert
            Assert.True(respuesta);
        }
    }
}
