using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Android.Content;

namespace Parqueadero.Droid
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
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
        }

        protected override void OnResume()
        {
            base.OnResume();
            btnIngresar.Click += delegate
            {
                Intent intent = new Intent(this, typeof(FormActivity));
                StartActivity(intent);
                //Toast.MakeText(Application.Context, "sisisi", ToastLength.Long).Show();
            };
            btnFacturar.Click += delegate
            {
                Intent intent = new Intent(this, typeof(PayActivity));
            };
            //Intent intent = new Intent(this, AddActivity.class);
            //  startActivity(intent);
        }

        //public void OnClick(View V)
        //{
        //    Toast.MakeText(Application.Context, "sisisi", ToastLength.Long).Show();
        //}


    }

}

