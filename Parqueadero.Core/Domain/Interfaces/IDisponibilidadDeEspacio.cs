using System;
namespace Parqueadero.Core.Domain.Interfaces
{
    public interface IDisponibilidadDeEspacio
    {
        bool VerificarDisponibilidadDeEspacioDeParqueo(int numeroCarrosEnParqueadero, int numeroMotosEnParqueadero, int tipoDeVehiculo);
    }
}
