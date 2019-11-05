using System;
using System.Globalization;
using Parqueadero.Core.Domain.Enumerations;

namespace Parqueadero.Core.Domain
{
    public class Vehiculo
    {
        public VehicleType Tipo { get; private set; }
        public int Cilindraje { get; private set; }
        public string Placa { get; private set; }
        public DateTime FechaIngreso { get; private set; }

        public Vehiculo(VehicleType tipo, int cilindraje, string placa, DateTime fechaIngreso)
        {
            Tipo = tipo;
            Cilindraje = cilindraje;
            Placa = placa;
            FechaIngreso = fechaIngreso;
        }
        
        private const int LimiteDeCarros = 20;
        private const int LimiteDeMotos = 10;
        private const int ValorHoraCarro = 1000;
        private const int ValorHoraMoto = 500;
        private const int ValorDiaCarro = 8000;
        private const int ValorDiaMoto = 4000;
        private const int ValorExcedenteMoto = 2000;
        private const int CilindrajeParaExcedente = 500;
        private const int LimiteDeCobroPorHoras = 9;
    }
}
