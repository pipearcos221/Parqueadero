using System;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Widget;
using Parqueadero.Core.Domain;
using Parqueadero.Core.Domain.Exceptions;
using Parqueadero.Core.Domain.Repository;
using Parqueadero.Core.Domain.Services;
using Parqueadero.Core.Resources;
using Parqueadero.Droid.DependencyInjection;

namespace Parqueadero.Droid
{
    [Activity(Label = "PayActivity", Theme = "@style/AppTheme")]
    public class PayActivity : AppCompatActivity
    {
        #region Declarar variables
        ServiceDomain services;
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

            services = new ServiceDomain(AndroidAppInjector.Resolve<IVehiculoRepository>());

            textInputLayoutPlacaFacturar = FindViewById<TextInputLayout>(Resource.Id.textinputlayout_facturar_placa);
            textInputEditTextPlacaFacturar = FindViewById<TextInputEditText>(Resource.Id.input_facturar_placa);
            btnBuscar = FindViewById<Button>(Resource.Id.btn_buscar);
            btnPagar = FindViewById<Button>(Resource.Id.btn_pagar);
            precio = FindViewById<TextView>(Resource.Id.txt_precio);

            btnBuscar.Click += BtnBuscar_Click;
            btnPagar.Click += BtnPagar_Click;

        }
        #endregion

        #region Listeners
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string placa = textInputEditTextPlacaFacturar.Text != null ? textInputEditTextPlacaFacturar.Text : string.Empty;
            ValidadObligatoriedadDeCampos(placa);
            if (placa != string.Empty)
            {
                try
                {
                    vehiculoDeSalida = services.ObtenerVehiculoPorPlaca(placa);
                    FijarPrecioAPagar(vehiculoDeSalida);
                }
                catch (ParkingAccessException exception)
                {
                    Toast.MakeText(Application.Context, exception.Message, ToastLength.Short).Show();
                }
            }

        }

        private void BtnPagar_Click(object sender, EventArgs e)
        {
            string placa = textInputEditTextPlacaFacturar.Text != null ? textInputEditTextPlacaFacturar.Text : string.Empty;
            ValidadObligatoriedadDeCampos(placa);
            if (vehiculoDeSalida.Placa != null)
            {
                services.RealizarPagoDeFactura(placa);
                Toast.MakeText(Application.Context, MensajesGenerales.PagoExitoso, ToastLength.Short).Show();
                Finish();
            }
            else
            {
                Toast.MakeText(Application.Context, MensajesGenerales.VehiculoNoEncontrado, ToastLength.Short).Show();
            }

        }
        #endregion

        #region Validaciones de vista
        private void ValidadObligatoriedadDeCampos(string placa)
        {
            if (placa == string.Empty)
            {
                textInputLayoutPlacaFacturar.ErrorEnabled = true;
                textInputLayoutPlacaFacturar.Error = MensajesGenerales.CampoObligatorio;
            }
            else
            {
                textInputLayoutPlacaFacturar.ErrorEnabled = false;
            }
        }

        private void FijarPrecioAPagar(Vehiculo vehiculo)
        {
            int numeroDeDiasACobrar = vehiculo.ObtenerNumeroDeDiasDeEstadia();
            int numeroDeHorasACobrar = vehiculo.ObtenerNumeroDeHorasDeEstadia();
            int precioAPagar = vehiculo.CalcularPrecioAPagar(numeroDeDiasACobrar, numeroDeHorasACobrar);
            precio.Text = precioAPagar.ToString();
        }
        #endregion
    }
}
