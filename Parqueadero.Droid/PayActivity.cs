using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace Parqueadero.Droid
{
    [Activity(Label = "PayActivity", Theme = "@style/AppTheme")]
    public class PayActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_pay);
            Title = "Facturacion";
        }
    }
}
