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
using Parqueadero.Droid.DependencyInjection;
using Parqueadero.Core.Domain.Repository;

namespace Parqueadero.Droid
{
    [Activity(Label = "FormActivity", Theme = "@style/AppTheme")]
    public class FormActivity : AppCompatActivity
    {
        #region Declarar variables
        ServiceDomain services; 
        Button btnRegistrarse;
        RadioGroup tipoVehiculo;
        TextInputLayout textInputLayoutPlaca;
        TextInputLayout textInputLayoutCilindraje;
        TextInputEditText inputPlaca;
        TextInputEditText inputCilindraje;
        #endregion

        #region Ciclo de vida
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_form);
            Title = "Registro";

            services = new ServiceDomain(AndroidAppInjector.Resolve<IVehiculoRepository>()); 

            btnRegistrarse = FindViewById<Button>(Resource.Id.btn_finalizar_registro);
            tipoVehiculo = FindViewById<RadioGroup>(Resource.Id.radiogroup_tipo);
            textInputLayoutPlaca = FindViewById<TextInputLayout>(Resource.Id.textinputlayout_placa);
            textInputLayoutCilindraje = FindViewById<TextInputLayout>(Resource.Id.textinputlayout_cilindraje);
            inputPlaca = FindViewById<TextInputEditText>(Resource.Id.input_placa);
            inputCilindraje = FindViewById<TextInputEditText>(Resource.Id.input_cilindraje);

            btnRegistrarse.Click += BtnRegistrarse_Click;
        }
        #endregion

        #region Listeners
        private void BtnRegistrarse_Click(object sender, System.EventArgs e)
        {
            Vehiculo vehiculo = ObtenerDatosDelFormulario();
            ValidarObligatoriedadDeCampoEnFormulario(vehiculo);

            if (vehiculo.Placa != String.Empty && vehiculo.Cilindraje != int.Parse(MensajesGenerales.CodigoErrorCampoObligatorio)) {
                try {
                    services.RegistrarIngresoDeVehiculo(vehiculo);
                    Toast.MakeText(Application.Context, MensajesGenerales.VehiculoRegistrado, ToastLength.Short).Show();
                    Finish();
                }
                catch (ParkingAccessException exception)
                {
                    Toast.MakeText(Application.Context, exception.Message, ToastLength.Short).Show();
                }
                
            }

        }
        #endregion

        #region Validaciones de vista
        private Vehiculo ObtenerDatosDelFormulario()
        {
            VehicleType tipoDeVehiculoSeleccionado = tipoVehiculo.CheckedRadioButtonId == Resource.Id.radio_carro ? VehicleType.Carro : VehicleType.Moto;
            string placaDelVehiculo = inputPlaca.Text != null ? inputPlaca.Text : String.Empty;
            string textCilindraje = inputCilindraje.Text != null ? inputCilindraje.Text : String.Empty;
            int cilindraje = int.Parse(textCilindraje != String.Empty ? textCilindraje : MensajesGenerales.CodigoErrorCampoObligatorio);
            DateTime fechaDeIngreso = DateTime.Now;

            return new Vehiculo(tipoDeVehiculoSeleccionado, cilindraje, placaDelVehiculo, fechaDeIngreso);
        }

        private void ValidarObligatoriedadDeCampoEnFormulario(Vehiculo vehiculo)
        {
            if (vehiculo.Placa == String.Empty)
            {
                textInputLayoutPlaca.ErrorEnabled = true;
                textInputLayoutPlaca.Error = MensajesGenerales.CampoObligatorio;
            }
            else {
                textInputLayoutPlaca.ErrorEnabled = false;
            }
            if (vehiculo.Cilindraje.ToString() == MensajesGenerales.CodigoErrorCampoObligatorio)
            {
                textInputLayoutCilindraje.ErrorEnabled = true;
                textInputLayoutCilindraje.Error = MensajesGenerales.CampoObligatorio;
            }
            else
            {
                textInputLayoutCilindraje.ErrorEnabled = false;
            }

        }
        #endregion
    }
}
