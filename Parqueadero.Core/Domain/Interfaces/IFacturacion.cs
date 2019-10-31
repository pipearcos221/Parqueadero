using System;
namespace Parqueadero.Core.Domain.Interfaces
{
    public interface IFacturacion
    {
        int CalcularPrecioAPagar(int numeroDias, int numeroHoras, int tipoDeVehiculo, int cilindraje);
    }
}
