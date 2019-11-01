using System;
using Realms;

namespace Parqueadero.Core.Data.Entity
{
    public class VehiculoDB : RealmObject
    {
        [PrimaryKey]
        public long Id { get; set; } = Convert.ToInt64(Guid.NewGuid().ToString());
        public int Tipo { get; set; }
        public int Cilindraje { get; set; }
        public string Placa { get; set; }
        public string FechaIngreso { get; set; }
    }
}
