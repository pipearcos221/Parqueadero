
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Parqueadero.Core.Domain.Services;

namespace Parqueadero.Droid
{
    [Activity(Label = "FormActivity", Theme = "@style/AppTheme")]
    public class FormActivity : AppCompatActivity
    {
        ServiceDomain services = new ServiceDomain();
        Button btnRegistrarse;
        RadioGroup tipoVehiculo;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_form);
            Title = "Registro";
            btnRegistrarse = FindViewById<Button>(Resource.Id.btn_finalizar_registro);
            tipoVehiculo = FindViewById<RadioGroup>(Resource.Id.radiogroup_tipo);

            btnRegistrarse.Click += BtnRegistrarse_Click;
        }

        

        protected override void OnResume()
        {
            base.OnResume();
            
        }

        private void BtnRegistrarse_Click(object sender, System.EventArgs e)
        {
            var x = tipoVehiculo.Selected;
            Toast.MakeText(Application.Context, $"Valor: {x}", ToastLength.Short).Show();
        }


    }
}
