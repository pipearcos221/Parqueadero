using System;
using System.Globalization;
using Parqueadero.Core.Domain.Interfaces;

namespace Parqueadero.Core.Domain
{
    public class AutorizacionDeAccesoAParqueaderoImpl : IAutorizacionDeAccesoAParqueadero
    {
        public bool ValidarAutorizacionParaAccederAlParqueadero(string placa)
        {
            string primeraLetraPlaca = placa.Length != 0 ? placa.Substring(0, 1) : "";
            DateTime fechaActual = DateTime.Now;
            DateTimeFormatInfo dateTimeFormat = new CultureInfo("es-ES").DateTimeFormat;
            string diaActual = fechaActual.ToString("dddd", dateTimeFormat);
            if (String.Equals("A", primeraLetraPlaca, StringComparison.OrdinalIgnoreCase))
            {
                return String.Equals("lunes", diaActual, StringComparison.OrdinalIgnoreCase) || String.Equals("domingo", diaActual, StringComparison.OrdinalIgnoreCase);
            }
            return true;
        }
    }
}
