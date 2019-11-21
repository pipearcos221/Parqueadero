using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Android.Content;

namespace Parqueadero.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btnIngresar;
        Button btnFacturar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            btnIngresar = FindViewById<Button>(Resource.Id.btn_ingresar);
            btnFacturar = FindViewById<Button>(Resource.Id.btn_facturar);

            btnIngresar.Click += BtnIngresar_Click;
            btnFacturar.Click += BtnFacturar_Click;
        }

        private void BtnIngresar_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FormActivity));
            StartActivity(intent);
        }

        private void BtnFacturar_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(PayActivity));
            StartActivity(intent);
        }
      


    }

}

