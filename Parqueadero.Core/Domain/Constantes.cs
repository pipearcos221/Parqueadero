using System;
namespace Parqueadero.Core.Domain
{
    public static class Constantes
    {
        public static int TIPO_CARRO = 1;
        public static int TIPO_MOTO = 2;

        public static int limiteDeCarros = 20;
        public static int limiteDeMotos = 10;

        public static int valorHoraCarro = 1000;
        public static int valorHoraMoto = 500;
        public static int valorDiaCarro = 8000;
        public static int valorDiaMoto = 4000;
        public static int valorExcedenteMoto = 2000;

        public static int cilindrajeParaExcedente = 500;

        public static int limiteDeCobroPorHoras = 9;
    }
}
