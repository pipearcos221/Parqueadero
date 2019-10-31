using System;
namespace Parqueadero.Core.Domain.Interfaces
{
    public class DisponibilidadDeEspacioImpl : IDisponibilidadDeEspacio
    {
        public bool VerificarDisponibilidadDeEspacioDeParqueo(int numeroCarrosEnParqueadero, int numeroMotosEnParqueadero, int tipoDeVehiculo)
        {
            if (tipoDeVehiculo.Equals(Constantes.TIPO_CARRO) && numeroCarrosEnParqueadero >= Constantes.limiteDeCarros
                || tipoDeVehiculo.Equals(Constantes.TIPO_MOTO) && numeroMotosEnParqueadero >= Constantes.limiteDeMotos) return false;
            return true;
        }
    }
}
