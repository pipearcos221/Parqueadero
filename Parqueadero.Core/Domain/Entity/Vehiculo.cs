using System;
namespace Parqueadero.Core.Domain
{
    public class Vehiculo
    {
        public string Tipo { get; set; }
        public string Cilindraje { get; set; }
        public string Placa { get; set; }
        public DateTime FechaIngreso { get; set; }

        public Vehiculo(string tipo, string cilindraje, string placa, DateTime fechaIngreso)
        {
            Tipo = tipo;
            Cilindraje = cilindraje;
            Placa = placa;
            FechaIngreso = fechaIngreso;
        }
    }
}
