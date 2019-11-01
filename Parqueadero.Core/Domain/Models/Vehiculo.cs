using System;
namespace Parqueadero.Core.Domain
{
    public class Vehiculo
    {
        public int Tipo { get; set; }
        public int Cilindraje { get; set; }
        public string Placa { get; set; }
        public DateTime FechaIngreso { get; set; }

        public Vehiculo(int tipo, int cilindraje, string placa, DateTime fechaIngreso)
        {
            Tipo = tipo;
            Cilindraje = cilindraje;
            Placa = placa;
            FechaIngreso = fechaIngreso;
        }
    }
}
