using System.Collections.Generic;
using System.Linq;
using Parqueadero.Core.Data.Entity;
using Parqueadero.Core.Data.Mappers;
using Parqueadero.Core.Domain;
using Parqueadero.Core.Domain.Repository;
using Realms;

namespace Parqueadero.Core.Data
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private Realm realm = Realm.GetInstance();
        private VehiculoAVehiculoDBMapper vehiculoAVehiculoDBMapper = new VehiculoAVehiculoDBMapper();
        private VehiculoDBAVehiculoMapper vehiculoDBAVehiculoMapper = new VehiculoDBAVehiculoMapper();

        public void RegistrarVehiculo(Vehiculo vehiculo)
        {
            var vehiculoDB = vehiculoAVehiculoDBMapper.Mapear(vehiculo);
            realm.Write(() =>
            {
                realm.Add(vehiculoDB);
            });
        }

        public List<Vehiculo> ListarVehiculosPorTipo(int tipo)
        {
            List<VehiculoDB> lista = realm.All<VehiculoDB>().Where(v => v.Tipo == tipo).ToList();
            List<Vehiculo> listaVehiculos = new List<Vehiculo>();
            foreach (VehiculoDB element in lista)
            {
                Vehiculo vehiculo = vehiculoDBAVehiculoMapper.Mapear(element);
                listaVehiculos.Add(vehiculo);
            }
            return listaVehiculos;
        }

        public void EliminarVehiculoPorPlaca(string placa)
        {
            var vehiculoAEliminar = realm.All<VehiculoDB>().First(v => v.Placa == placa);
            using var transaction = realm.BeginWrite();
            realm.Remove(vehiculoAEliminar);
            transaction.Commit();
        }
    }
}
