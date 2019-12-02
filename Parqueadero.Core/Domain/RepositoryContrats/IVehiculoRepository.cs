using System.Collections.Generic;

namespace Parqueadero.Core.Domain.Repository
{
    public interface IVehiculoRepository
    {
        void RegistrarVehiculo(Vehiculo vehiculo);

        List<Vehiculo> ListarVehiculosPorTipo(int tipo);

        void EliminarVehiculoPorPlaca(string placa);

        Vehiculo ObtenerVehiculoPorPlaca(string placa);
    }
}
