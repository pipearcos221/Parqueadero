using System.Collections.Generic;
using System.Threading.Tasks;
using Parqueadero.Core.Data;
using Parqueadero.Core.Domain.Enumerations;
using Parqueadero.Core.Domain.Exceptions;
using Parqueadero.Core.Domain.Repository;
using Parqueadero.Core.Resources;

namespace Parqueadero.Core.Domain.Services
{
    public class ServiceDomain
    {
        public void RegistrarIngresoDeVehiculo(Vehiculo vehiculo)
        {
            IVehiculoRepository accessData = new VehiculoRepository();
            int numeroDeCarrosEnParqueadero;
            int numeroDeMotosEnParqueadero;

            List<Vehiculo> listaDeCarros = accessData.ListarVehiculosPorTipo((int)VehicleType.Carro) != null ? accessData.ListarVehiculosPorTipo((int)VehicleType.Carro) : new List<Vehiculo>();
            List<Vehiculo> listaDeMotos = accessData.ListarVehiculosPorTipo((int)VehicleType.Moto) != null ? accessData.ListarVehiculosPorTipo((int)VehicleType.Moto) : new List<Vehiculo>();

            numeroDeCarrosEnParqueadero = listaDeCarros.Count;
            numeroDeMotosEnParqueadero = listaDeMotos.Count;

            bool disponibilidadDeEspacio = vehiculo.VerificarDisponibilidadDeEspacioLibreEnParqueadero(numeroDeCarrosEnParqueadero, numeroDeMotosEnParqueadero);
            if (disponibilidadDeEspacio is false)
            {
                throw new ParkingAccessException(MensajesGenerales.SinEspacionEnParqueadero);
            }

            bool autorizacionDeIngreso = vehiculo.VerificarAutorizacionDeAccesoAlParqueadero();
            if (autorizacionDeIngreso is false)
            {
                throw new ParkingAccessException(MensajesGenerales.SinAutorizacionParaAccesoAParqueadero);
            }

            accessData.RegistrarVehiculo(vehiculo);
        }

    }
}
