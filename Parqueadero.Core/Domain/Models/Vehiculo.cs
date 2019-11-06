﻿using System;
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

        public bool VerificarDisponibilidadDeEspacioLibreEnParqueadero(int numeroCarrosEnParqueadero, int numeroMotosEnParqueadero)
        {
            return (Tipo.Equals(VehicleType.Carro) && (numeroCarrosEnParqueadero < LimiteDeCarros))
                || (Tipo.Equals(VehicleType.Moto) && (numeroMotosEnParqueadero < LimiteDeMotos));
        }

        public int ObtenerNumeroDeDiasDeEstadia()
        {
            int segundosTranscurridos = (int)DateTime.Now.Subtract(FechaIngreso).TotalSeconds;
            decimal horasTranscurridas = segundosTranscurridos / new Decimal(3600);
            decimal horasACobrar = Math.Ceiling(horasTranscurridas);
            decimal diasACobrar = Math.Floor(horasACobrar / 24);
            decimal horasParaCobroPorDia = horasACobrar % 24;
            if (horasParaCobroPorDia >= LimiteDeCobroPorHoras)
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
            if (horasACobrar >= LimiteDeCobroPorHoras)
            {
                horasACobrar = 0;
            }
            return decimal.ToInt32(horasACobrar);
        }

        public int CalcularPrecioAPagar(int numeroDias, int numeroHoras)
        {
            int valorAPagar;
            if (Tipo.Equals(VehicleType.Carro))
            {
                valorAPagar = numeroDias * ValorDiaCarro + numeroHoras * ValorHoraCarro;
            }
            else
            {
                valorAPagar = numeroDias * ValorDiaMoto + numeroHoras * ValorHoraMoto;
                if (Cilindraje >= CilindrajeParaExcedente)
                {
                    valorAPagar += ValorExcedenteMoto;
                }
            }
            return valorAPagar;
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
