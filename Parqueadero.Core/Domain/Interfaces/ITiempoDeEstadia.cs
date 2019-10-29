using System;
namespace Parqueadero.Core.Domain.Interfaces
{
    public interface ITiempoDeEstadia
    {
        int ObtenerNumeroDeDiasDeEstadia(DateTime fechaIngreso);

        int ObtenerNumeroDeHorasDeEstadia(DateTime fechaIngreso);
    }
}
