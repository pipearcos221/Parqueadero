using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Parqueadero.Core.Domain.Services;
using Android.Support.Design.Widget;
using Parqueadero.Core.Domain;
using System;
using Parqueadero.Core.Domain.Enumerations;
using Parqueadero.Core.Resources;
using Parqueadero.Core.Domain.Exceptions;

namespace Parqueadero.Droid
{
    [Activity(Label = "FormActivity", Theme = "@style/AppTheme")]
    public class FormActivity : AppCompatActivity
    {
        ServiceDomain services = new ServiceDomain();
        Button btnRegistrarse;
        RadioGroup tipoVehiculo;
        TextInputLayout textInputLayoutPlaca;
        TextInputLayout textInputLayoutCilindraje;
        TextInputEditText inputPlaca;
        TextInputEditText inputCilindraje;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_form);
            Title = "Registro";

            btnRegistrarse = FindViewById<Button>(Resource.Id.btn_finalizar_registro);
            tipoVehiculo = FindViewById<RadioGroup>(Resource.Id.radiogroup_tipo);
            textInputLayoutPlaca = FindViewById<TextInputLayout>(Resource.Id.textinputlayout_placa);
            textInputLayoutCilindraje = FindViewById<TextInputLayout>(Resource.Id.textinputlayout_cilindraje);
            inputPlaca = FindViewById<TextInputEditText>(Resource.Id.input_placa);
            inputCilindraje = FindViewById<TextInputEditText>(Resource.Id.input_cilindraje);

            btnRegistrarse.Click += BtnRegistrarse_Click;
        }

        private void BtnRegistrarse_Click(object sender, System.EventArgs e)
        {
            var x = tipoVehiculo.Selected;
            Toast.MakeText(Application.Context, $"Valor: {x}", ToastLength.Short).Show();
        private Vehiculo ObtenerDatosDelFormulario()
        {
            VehicleType tipoDeVehiculoSeleccionado = tipoVehiculo.CheckedRadioButtonId == Resource.Id.radio_carro ? VehicleType.Carro : VehicleType.Moto;
            string placaDelVehiculo = inputPlaca.Text != null ? inputPlaca.Text : String.Empty;
            string textCilindraje = inputCilindraje.Text != null ? inputCilindraje.Text : String.Empty;
            int cilindraje = int.Parse(textCilindraje != String.Empty ? textCilindraje : MensajesGenerales.CodigoErrorCampoObligatorio);
            DateTime fechaDeIngreso = DateTime.Now;

            return new Vehiculo(tipoDeVehiculoSeleccionado, cilindraje, placaDelVehiculo, fechaDeIngreso);
        }
        }
    }
}
