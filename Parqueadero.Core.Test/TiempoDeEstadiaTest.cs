using System;
using Parqueadero.Core.Domain.Interfaces;
using Xunit;

namespace Parqueadero.Core.Test
{
    public class TiempoDeEstadiaTest
    {
        [Fact]
        public void ObtenerNumeroDeDiasDeEstadiaTest()
        {
            // arrange
            DateTime fechaIngreso = DateTime.Now.AddDays(-2);
            TiempoDeEstadiaImpl tiempoDeEstadia = new TiempoDeEstadiaImpl();
            // act
            int diasACobrar = tiempoDeEstadia.ObtenerNumeroDeDiasDeEstadia(fechaIngreso);
            // assert
            Assert.Equal(2, diasACobrar);
        }

        [Fact]
        public void ObtenerNumeroDeHorasDeEstadiaTest()
        {
            // arrange
            DateTime fechaIngreso = DateTime.Now.AddDays(-2).AddHours(-8);
            TiempoDeEstadiaImpl tiempoDeEstadia = new TiempoDeEstadiaImpl();
            // act
            int horasACobrar = tiempoDeEstadia.ObtenerNumeroDeHorasDeEstadia(fechaIngreso);
            // assert
            Assert.Equal(8, horasACobrar);
        }
    }
}
