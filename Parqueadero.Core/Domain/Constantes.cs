using System;
namespace Parqueadero.Core.Domain
{
    public static class Constantes
    {
        public static readonly int TIPO_CARRO = 1;
        public static readonly int TIPO_MOTO = 2;

        public static readonly int limiteDeCarros = 20;
        public static readonly int limiteDeMotos = 10;

        public static readonly int valorHoraCarro = 1000;
        public static readonly int valorHoraMoto = 500;
        public static readonly int valorDiaCarro = 8000;
        public static readonly int valorDiaMoto = 4000;
        public static readonly int valorExcedenteMoto = 2000;

        public static readonly int cilindrajeParaExcedente = 500;

        public static readonly int limiteDeCobroPorHoras = 9;
    }
}
