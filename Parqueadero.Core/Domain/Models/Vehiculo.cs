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

        public bool ObtenerAutorizacionDeAccesoAlParqueadero()
        {
            string LetraRestringida = "A";
            string[] DiasDeAccesoPermitido = { "Lunes", "Domingo" };
            string PrimeraLetraDePlaca = Placa != null ? Placa.Substring(0, 1) : string.Empty;
            DateTime FechaActual = DateTime.Now;
            DateTimeFormatInfo DateTimeFormat = new CultureInfo("es-ES").DateTimeFormat;
            string DiaActual = FechaActual.ToString("dddd", DateTimeFormat);
            if (String.Equals(PrimeraLetraDePlaca, LetraRestringida, StringComparison.OrdinalIgnoreCase)) {
                return Array.Exists(DiasDeAccesoPermitido, DiaPermitido => DiaPermitido.Equals(DiaActual, StringComparison.OrdinalIgnoreCase));
            }
            return true;
        }

        public bool VerificarDisponibilidadDeEspacioLibreEnParqueadero(int numeroCarrosEnParqueadero, int numeroMotosEnParqueadero, VehicleType tipoDeVehiculo)
        {
            return (tipoDeVehiculo.Equals(VehicleType.Carro) && (numeroCarrosEnParqueadero < LimiteDeCarros))
                || (tipoDeVehiculo.Equals(VehicleType.Moto) && (numeroMotosEnParqueadero < LimiteDeMotos));
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
