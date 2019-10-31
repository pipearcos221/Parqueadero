using System;
using Parqueadero.Core.Domain.Interfaces;

namespace Parqueadero.Core.Domain
{
    public class FacturacionImpl : IFacturacion
    {
        public int CalcularPrecioAPagar(int numeroDias, int numeroHoras, int tipoDeVehiculo, int cilindraje)
        {
            int valorAPagar;
            if (tipoDeVehiculo.Equals(Constantes.TIPO_CARRO))
            {
                valorAPagar = numeroDias * Constantes.valorDiaCarro + numeroHoras * Constantes.valorHoraCarro;
            }
            else
            {
                valorAPagar = numeroDias * Constantes.valorDiaMoto + numeroHoras * Constantes.valorHoraMoto;
                if (cilindraje >= Constantes.cilindrajeParaExcedente) valorAPagar += Constantes.valorExcedenteMoto;
            }
            return valorAPagar;
        }
    }
}
