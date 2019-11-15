using System.Collections.Generic;
using System.Threading.Tasks;
using Parqueadero.Core.Data;
using Parqueadero.Core.Domain.Enumerations;
using Parqueadero.Core.Domain.Exceptions;
using Parqueadero.Core.Domain.Repository;

namespace Parqueadero.Core.Domain.Services
{
    public class ServiceDomain
    {
        public void RegistrarIngresoDeVehiculo(Vehiculo vehiculo)
        {
            IVehiculoRepository accessData = new VehiculoRepository();
            int numeroDeCarrosEnParqueadero;
            int numeroDeMotosEnParqueadero;

            List<Vehiculo> listaDeCarros = Task.Run(() => accessData.ListarVehiculosPorTipo((int)VehicleType.Carro)).Result;
            List<Vehiculo> listaDeMotos = Task.Run(() => accessData.ListarVehiculosPorTipo((int)VehicleType.Moto)).Result;

            numeroDeCarrosEnParqueadero = listaDeCarros.Count;
            numeroDeMotosEnParqueadero = listaDeMotos.Count;

            bool disponibilidadDeEspacio = vehiculo.VerificarDisponibilidadDeEspacioLibreEnParqueadero(numeroDeCarrosEnParqueadero, numeroDeMotosEnParqueadero);
            if (disponibilidadDeEspacio is false)
            {
                throw new ParkingAccessException("El parqueadero no posee espacios disponibles");
            }

            bool autorizacionDeIngreso = vehiculo.VerificarAutorizacionDeAccesoAlParqueadero();
            if (autorizacionDeIngreso is false)
            {
                throw new ParkingAccessException("Usted no esta autorizado para ingresar");
            }

            Task.Run(() =>
            {
                accessData.RegistrarVehiculo(vehiculo);
            }
            );
        }

    }
}
