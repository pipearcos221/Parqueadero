using System;
using Parqueadero.Core.Domain;
using Parqueadero.Core.Domain.Enumerations;
using Xunit;

namespace Parqueadero.Core.Test
{
    public class TiempoDeEstadiaTest
    {
        [Fact]
        public void ObtenerNumeroDeDiasDeEstadiaTest()
        {
            // arrange
            Vehiculo vehiculo = new Vehiculo(VehicleType.Moto, 125, "CBD432", DateTime.Now.AddDays(-2));
            // act
            int diasACobrar = vehiculo.ObtenerNumeroDeDiasDeEstadia();
            // assert
            Assert.Equal(2, diasACobrar);
        }

        [Fact(DisplayName = "cobro de dia extra por exceso de 9 horas")]
        public void ObtenerNumeroDeDiasDeEstadiaConDiaExtraTest()
        {
            // arrange
            Vehiculo vehiculo = new Vehiculo(VehicleType.Moto, 125, "CBD432", DateTime.Now.AddDays(-2).AddHours(-10));
            // act
            int diasACobrar = vehiculo.ObtenerNumeroDeDiasDeEstadia();
            // assert
            Assert.Equal(3, diasACobrar);
        }

        [Fact]
        public void ObtenerNumeroDeHorasDeEstadiaTest()
        {
            // arrange
            Vehiculo vehiculo = new Vehiculo(VehicleType.Moto, 125, "CBD432", DateTime.Now.AddDays(-2).AddHours(-8));
            // act
            int horasACobrar = vehiculo.ObtenerNumeroDeHorasDeEstadia();
            // assert
            Assert.Equal(8, horasACobrar);
        }
    }
}
