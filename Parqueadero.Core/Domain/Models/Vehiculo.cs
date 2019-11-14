using System;
using System.Globalization;
using Parqueadero.Core.Domain.Enumerations;

namespace Parqueadero.Core.Domain
{
    public class Vehiculo
    {
        #region Constants

        private const int limiteDeCarros = 20;
        private const int limiteDeMotos = 10;
        private const int valorHoraCarro = 1000;
        private const int valorHoraMoto = 500;
        private const int valorDiaCarro = 8000;
        private const int valorDiaMoto = 4000;
        private const int valorExcedenteMoto = 2000;
        private const int cilindrajeParaExcedente = 500;
        private const int limiteDeCobroPorHoras = 9;

        #endregion

        #region Properties

        public VehicleType Tipo { get; private set; }
        public int Cilindraje { get; private set; }
        public string Placa { get; private set; }
        public DateTime FechaIngreso { get; private set; }

        #endregion

        #region Business

        public Vehiculo(VehicleType tipo, int cilindraje, string placa, DateTime fechaIngreso)
        {
            Tipo = tipo;
            Cilindraje = cilindraje;
            Placa = placa;
            FechaIngreso = fechaIngreso;
        }

        public bool VerificarAutorizacionDeAccesoAlParqueadero()
        {
            string LetraRestringida = "A";
            string[] DiasDeAccesoPermitido = { "Lunes", "Domingo" };
            string PrimeraLetraDePlaca = Placa != null ? Placa.Substring(0, 1) : string.Empty;
            DateTime FechaActual = DateTime.Now;
            DateTimeFormatInfo DateTimeFormat = new CultureInfo("es-ES").DateTimeFormat;
            string DiaActual = FechaActual.ToString("dddd", DateTimeFormat);
            if (String.Equals(PrimeraLetraDePlaca, LetraRestringida, StringComparison.OrdinalIgnoreCase))
            {
                return Array.Exists(DiasDeAccesoPermitido, DiaPermitido => DiaPermitido.Equals(DiaActual, StringComparison.OrdinalIgnoreCase));
            }
            return true;
        }

        public bool VerificarDisponibilidadDeEspacioLibreEnParqueadero(int numeroCarrosEnParqueadero, int numeroMotosEnParqueadero)
        {
            return (Tipo.Equals(VehicleType.Carro) && (numeroCarrosEnParqueadero < limiteDeCarros))
                || (Tipo.Equals(VehicleType.Moto) && (numeroMotosEnParqueadero < limiteDeMotos));
        }

        public int ObtenerNumeroDeDiasDeEstadia()
        {
            int segundosTranscurridos = (int)DateTime.Now.Subtract(FechaIngreso).TotalSeconds;
            decimal horasTranscurridas = segundosTranscurridos / new Decimal(3600);
            decimal horasACobrar = Math.Ceiling(horasTranscurridas);
            decimal diasACobrar = Math.Floor(horasACobrar / 24);
            decimal horasParaCobroPorDia = horasACobrar % 24;
            if (horasParaCobroPorDia >= limiteDeCobroPorHoras)
            {
                diasACobrar += 1;
            }
            return decimal.ToInt32(diasACobrar);
        }

        public int ObtenerNumeroDeHorasDeEstadia()
        {
            int SegundosTranscurridos = (int)DateTime.Now.Subtract(FechaIngreso).TotalSeconds;
            decimal horasTranscurridas = SegundosTranscurridos / new Decimal(3600);
            decimal horasACobrar = Math.Ceiling(horasTranscurridas) % 24;
            if (horasACobrar >= limiteDeCobroPorHoras)
            {
                horasACobrar = 0;
            }
            return decimal.ToInt32(horasACobrar);
        }

        public int CalcularPrecioAPagar(int numeroDiasACobrar, int numeroHorasACobrar)
        {
            int valorAPagar;
            if (Tipo.Equals(VehicleType.Carro))
            {
                valorAPagar = numeroDiasACobrar * valorDiaCarro + numeroHorasACobrar * valorHoraCarro;
            }
            else
            {
                valorAPagar = numeroDiasACobrar * valorDiaMoto + numeroHorasACobrar * valorHoraMoto;
                if (Cilindraje >= cilindrajeParaExcedente)
                {
                    valorAPagar += valorExcedenteMoto;
                }
            }
            return valorAPagar;
        }

        #endregion
    }
}
