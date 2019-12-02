using System;
using Android.App;
using Android.Runtime;
using Unity; 

namespace Parqueadero.Droid.DependencyInjection
{
   [Application(Label = "@string/app_name")]
    public class AndroidAppInjector : Application
    {
        public static AndroidAppInjector Instance { get; private set; }
        static UnityContainer DiContainer { get; set; }
        public AndroidAppInjector(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
            Instance = this;
            DiContainer = new UnityContainer();
            AndroidDependencyRegistry.RegisterTypes(DiContainer);
        }
        public override void OnCreate()
        {
            base.OnCreate();
            AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironmentUnhandledExceptionRaiser;
        }
        public static TRequest Resolve<TRequest>()
        {
            if (DiContainer == null)
            {
                throw new InvalidOperationException("El contenedor de inyecciones aún no esta listo");
            }
            return DiContainer.Resolve<TRequest>();
        }
        void AndroidEnvironmentUnhandledExceptionRaiser(object sender, RaiseThrowableEventArgs e)
        {   
            //Log.Error("", "", + e.Exception);
        }
    }
}
