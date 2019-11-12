using System;
using System.Collections.Generic;
using System.Linq;
using Parqueadero.Core.Data.Entity;
using Parqueadero.Core.Domain.Repository;
using Realms;

namespace Parqueadero.Core.Data
{
    public class VehiculoRepositoryImpl : IRepository
    {
        private Realm realm = Realm.GetInstance();

        public void RegistrarVehiculo(VehiculoDB vehiculo)
        {
            realm.Write(() =>
            {
                realm.Add(vehiculo);
            });
        }

        public List<VehiculoDB> ListarVehiculosPorTipo(int tipo)
        {
            List<VehiculoDB> lista = realm.All<VehiculoDB>().Where(v => v.Tipo == tipo).ToList();
            return lista;
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
