using System;
using Parqueadero.Core.Domain;
using Xunit;

namespace Parqueadero.Core.Test
{
    public class FacturacionTest
    {
        [Fact]
        public void CalcularPrecioAPagarTest() {
            // arrange
            FacturacionImpl facturacion = new FacturacionImpl();
            // act
            int precioAPagar = facturacion.CalcularPrecioAPagar(1, 1, 1, 1600);
            // assert
            Assert.Equal(9000, precioAPagar);
        }
    }
}
