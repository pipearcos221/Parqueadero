using System.Collections.Generic;
using Parqueadero.Core.Data.Entity;
using Parqueadero.Core.Domain.Enumerations;

namespace Parqueadero.Core.Domain.Repository
{
    public interface IVehiculoRepository
    {
        void RegistrarVehiculo(VehiculoDB vehiculo);

        List<VehiculoDB> ListarVehiculosPorTipo(int tipo);

        void EliminarVehiculoPorPlaca(string placa);
    }
}
