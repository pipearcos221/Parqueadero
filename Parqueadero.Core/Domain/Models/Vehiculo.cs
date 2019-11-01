using System;
using Parqueadero.Core.Domain.Enumerations;

namespace Parqueadero.Core.Domain
{
    public class Vehiculo
    {
        public VehicleTypes Tipo { get; private set; }
        public int Cilindraje { get; private set; }
        public string Placa { get; private set; }
        public DateTime FechaIngreso { get; private set; }

        public Vehiculo(VehicleTypes tipo, int cilindraje, string placa, DateTime fechaIngreso)
        {
            Tipo = tipo;
            Cilindraje = cilindraje;
            Placa = placa;
            FechaIngreso = fechaIngreso;
        }
    }
}
