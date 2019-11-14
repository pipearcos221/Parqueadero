using System.Collections.Generic;
using Parqueadero.Core.Data.Entity;
using Parqueadero.Core.Domain.Enumerations;

namespace Parqueadero.Core.Domain.Repository
{
    public interface IVehiculoRepository
    {
        void RegistrarVehiculo(Vehiculo vehiculo);

        List<Vehiculo> ListarVehiculosPorTipo(int tipo);

        void EliminarVehiculoPorPlaca(string placa);
    }
}
