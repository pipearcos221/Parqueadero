using System.Collections.Generic;
using Parqueadero.Core.Data;
using Parqueadero.Core.Domain.Enumerations;
using Parqueadero.Core.Domain.Exceptions;
using Parqueadero.Core.Domain.Repository;
using Parqueadero.Core.Resources;

namespace Parqueadero.Core.Domain.Services
{
    public class ServiceDomain
    {
        private readonly IVehiculoRepository vehiculoRepository;

        public ServiceDomain(IVehiculoRepository vehiculoRepository)
        {
            this.vehiculoRepository = vehiculoRepository;
        }

        public void RegistrarIngresoDeVehiculo(Vehiculo vehiculo)
        {
            int numeroDeCarrosEnParqueadero;
            int numeroDeMotosEnParqueadero;

            List<Vehiculo> listaDeCarros = vehiculoRepository.ListarVehiculosPorTipo((int)VehicleType.Carro) != null ? vehiculoRepository.ListarVehiculosPorTipo((int)VehicleType.Carro) : new List<Vehiculo>();
            List<Vehiculo> listaDeMotos = vehiculoRepository.ListarVehiculosPorTipo((int)VehicleType.Moto) != null ? vehiculoRepository.ListarVehiculosPorTipo((int)VehicleType.Moto) : new List<Vehiculo>();

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

            vehiculoRepository.RegistrarVehiculo(vehiculo);
        }

        public Vehiculo ObtenerVehiculoPorPlaca(string placa)
        {
            Vehiculo vehiculo = vehiculoRepository.ObtenerVehiculoPorPlaca(placa);
            if (vehiculo.Placa == null)
            {
                throw new ParkingAccessException(MensajesGenerales.VehiculoNoEncontrado);
            }
            return vehiculo;
        }

        public void RealizarPagoDeFactura(string placa)
        {
            vehiculoRepository.EliminarVehiculoPorPlaca(placa);
        }
    }
}
