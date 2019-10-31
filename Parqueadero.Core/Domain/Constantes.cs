using System;
namespace Parqueadero.Core.Domain
{
    public static class Constantes
    {
        public const int TIPO_CARRO = 1;
        public const int TIPO_MOTO = 2;

        public const int limiteDeCarros = 20;
        public const int limiteDeMotos = 10;

        public const int valorHoraCarro = 1000;
        public const int valorHoraMoto = 500;
        public const int valorDiaCarro = 8000;
        public const int valorDiaMoto = 4000;
        public const int valorExcedenteMoto = 2000;

        public const int cilindrajeParaExcedente = 500;

        public const int limiteDeCobroPorHoras = 9;
    }
}
