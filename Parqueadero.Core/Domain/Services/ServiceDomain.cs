using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Parqueadero.Core.Data;
using Parqueadero.Core.Data.Entity;
using Parqueadero.Core.Domain.Enumerations;
using Parqueadero.Core.Domain.Exceptions;
using Parqueadero.Core.Domain.Repository;

namespace Parqueadero.Core.Domain.Services
{
    public class ServiceDomain
    {
        public ServiceDomain()
        {
        }

        public void RegistrarIngresoDeVehiculo(Vehiculo vehiculo)
        {
            IRepository accessData = new VehiculoRepositoryImpl();
            int numeroDeCarrosEnParqueadero;
            int numeroDeMotosEnParqueadero;

            var listaDeCarros = Task.Run(() => accessData.ListarVehiculosPorTipo((int)VehicleType.Carro));
            var listaDeMotos = Task.Run(() => accessData.ListarVehiculosPorTipo((int)VehicleType.Moto));

            numeroDeCarrosEnParqueadero = listaDeCarros.Result.Count;
            numeroDeMotosEnParqueadero = listaDeMotos.Result.Count;

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
                VehiculoDB vehiculoAIngresar = new VehiculoDB
                {
                    Tipo = (int)vehiculo.Tipo,
                    Cilindraje = vehiculo.Cilindraje,
                    Placa = vehiculo.Placa,
                    FechaIngreso = vehiculo.FechaIngreso.ToString()
                };

                accessData.RegistrarVehiculo(vehiculoAIngresar);
            }
            );
        }

    }
}
