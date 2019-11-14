using System;
using Parqueadero.Core.Data.Entity;
using Parqueadero.Core.Domain;
using Parqueadero.Core.Domain.Enumerations;

namespace Parqueadero.Core.Data.Mappers
{
    public class VehiculoDBAVehiculoMapper
    {
        public Vehiculo Mapear(VehiculoDB vehiculodb)
        {
            return new Vehiculo(
                tipo: (VehicleType)vehiculodb.Tipo,
                cilindraje: vehiculodb.Cilindraje,
                placa: vehiculodb.Placa,
                fechaIngreso: Convert.ToDateTime(vehiculodb.FechaIngreso)
                );
        }
    }
}
