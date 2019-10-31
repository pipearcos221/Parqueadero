using System;
namespace Parqueadero.Core.Domain.Interfaces
{
    public interface IDisponibilidadDeEspacio
    {
        Boolean VerificarDisponibilidadDeEspacioDeParqueo(int numeroCarrosEnParqueadero, int numeroMotosEnParqueadero, int tipoDeVehiculo);
    }
}
