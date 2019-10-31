using System;
namespace Parqueadero.Core.Domain.Interfaces
{
    public class TiempoDeEstadiaImpl : ITiempoDeEstadia
    {
        public int ObtenerNumeroDeDiasDeEstadia(DateTime fechaIngreso)
        {
            int unixTimestamp = (int)DateTime.Now.Subtract(fechaIngreso).TotalSeconds;
            decimal horasTranscurridas = unixTimestamp / 3600;
            decimal horasACobrar = Math.Ceiling(horasTranscurridas);
            decimal diasACobrar = Math.Floor(horasACobrar / 24);
            decimal horasParaCobroPorDia = horasACobrar % 24;
            if (horasParaCobroPorDia >= Constantes.limiteDeCobroPorHoras) diasACobrar += 1;
            return decimal.ToInt32(diasACobrar);
        }

        public int ObtenerNumeroDeHorasDeEstadia(DateTime fechaIngreso)
        {
            int unixTimestamp = (int)DateTime.Now.Subtract(fechaIngreso).TotalSeconds;
            decimal horasTranscurridas = unixTimestamp / 3600;
            decimal horasACobrar = Math.Ceiling(horasTranscurridas) % 24;
            if (horasACobrar >= Constantes.limiteDeCobroPorHoras) horasACobrar = 0;
            return decimal.ToInt32(horasACobrar);
        }
    }
}
