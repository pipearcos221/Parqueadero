using System;
using Parqueadero.Core.Data;
using Parqueadero.Core.Domain.Repository;
using Unity;

namespace Parqueadero.Droid.DependencyInjection
{
    public static class AndroidDependencyRegistry
    {
        public static void RegisterTypes(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IVehiculoRepository, VehiculoRepository>();
        }
    }
}
