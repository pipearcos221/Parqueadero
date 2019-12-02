using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace Parqueadero.Droid
{
    [Activity(Label = "PayActivity", Theme = "@style/AppTheme")]
    public class PayActivity : AppCompatActivity
    {
        #region Declarar variables
        ServiceDomain services = new ServiceDomain();
        TextInputLayout textInputLayoutPlacaFacturar;
        TextInputEditText textInputEditTextPlacaFacturar;
        Button btnBuscar;
        Button btnPagar;
        TextView precio;
        Vehiculo vehiculoDeSalida = new Vehiculo();
        #endregion

        #region Ciclo de vida
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_pay);
            Title = "Facturacion";
        }
    }
}
