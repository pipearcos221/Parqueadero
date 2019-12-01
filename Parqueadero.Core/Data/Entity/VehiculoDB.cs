using System;
using Realms;

namespace Parqueadero.Core.Data.Entity
{
    public class VehiculoDB : RealmObject
    {
        [PrimaryKey]
        public String Id { get; set; } = Guid.NewGuid().ToString();
        public int Tipo { get; set; }
        public int Cilindraje { get; set; }
        public string Placa { get; set; }
        public string FechaIngreso { get; set; }
    }
}
