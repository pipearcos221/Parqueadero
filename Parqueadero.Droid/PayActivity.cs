using System;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Widget;
using Parqueadero.Core.Domain;
using Parqueadero.Core.Domain.Exceptions;
using Parqueadero.Core.Domain.Services;
using Parqueadero.Core.Resources;

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

            textInputLayoutPlacaFacturar = FindViewById<TextInputLayout>(Resource.Id.textinputlayout_facturar_placa);
            textInputEditTextPlacaFacturar = FindViewById<TextInputEditText>(Resource.Id.input_facturar_placa);
            btnBuscar = FindViewById<Button>(Resource.Id.btn_buscar);
            btnPagar = FindViewById<Button>(Resource.Id.btn_pagar);
            precio = FindViewById<TextView>(Resource.Id.txt_precio);

            btnBuscar.Click += BtnBuscar_Click;
            btnPagar.Click += BtnPagar_Click;

        }
        #endregion

        }
    }
}
