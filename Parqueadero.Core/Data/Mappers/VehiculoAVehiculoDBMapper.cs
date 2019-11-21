using Parqueadero.Core.Data.Entity;
using Parqueadero.Core.Domain;

namespace Parqueadero.Core.Data.Mappers
{
    public class VehiculoAVehiculoDBMapper
    {
        public VehiculoDB Mapear(Vehiculo vehiculo) {
            return new VehiculoDB {
                Tipo = (int)vehiculo.Tipo,
                Cilindraje = vehiculo.Cilindraje,
                Placa = vehiculo.Placa,
                FechaIngreso = vehiculo.FechaIngreso.ToString()
            };
        }
    }
}
