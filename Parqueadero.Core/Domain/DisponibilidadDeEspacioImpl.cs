using System;
using Parqueadero.Core.Domain.Enumerations;

namespace Parqueadero.Core.Domain.Interfaces
{
    public class DisponibilidadDeEspacioImpl : IDisponibilidadDeEspacio
    {
        public bool VerificarDisponibilidadDeEspacioDeParqueo(int numeroCarrosEnParqueadero, int numeroMotosEnParqueadero, int tipoDeVehiculo)
        {
            return (tipoDeVehiculo.Equals(VehicleType.Carro) && numeroCarrosEnParqueadero < Constantes.limiteDeCarros)
                || (tipoDeVehiculo.Equals(VehicleType.Moto) && numeroMotosEnParqueadero < Constantes.limiteDeMotos);
        }
    }
}
