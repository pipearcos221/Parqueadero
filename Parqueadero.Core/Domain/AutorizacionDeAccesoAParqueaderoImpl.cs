using System;
using System.Globalization;
using Parqueadero.Core.Domain.Interfaces;

namespace Parqueadero.Core.Domain
{
    public class AutorizacionDeAccesoAParqueaderoImpl : IAutorizacionDeAccesoAParqueadero
    {
        public bool ValidarAutorizacionParaAccederAlParqueadero(string placa)
        {
            string primeraLetraPlaca = placa.ToUpper().Substring(0, 1);
            DateTime fechaActual = DateTime.Now;
            DateTimeFormatInfo dateTimeFormat = new CultureInfo("es-ES").DateTimeFormat;
            string diaActual = fechaActual.ToString("dddd", dateTimeFormat).ToLower();
            if (primeraLetraPlaca.Equals("A"))
            {
                if (diaActual.Equals("lunes") || diaActual.Equals("domingo")) return true;
                else return false;
            }
            else
            {
                return true;
            }

        }
    }
}
