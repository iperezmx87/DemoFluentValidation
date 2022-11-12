using System.Collections.ObjectModel;
using DemoFluentValidation.Model;
using DemoFluentValidation.Model.Validadores;
using FluentValidation;
using FluentValidation.Results;
using Xamarin.Forms;

namespace AppChida
{
    public partial class RegisterPage : ContentPage
    {
        private ObservableCollection<ValidationFailure> lstErroresValidacion;
        private IValidator<Usuario> validadorUsuario;

        public RegisterPage()
        {
            InitializeComponent();

            cllValidaciones.IsVisible = false;
            lstErroresValidacion = new ObservableCollection<ValidationFailure>();
            cllValidaciones.ItemsSource = lstErroresValidacion;

            validadorUsuario = new ValidadorUsuario();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            cllValidaciones.IsVisible = false;
            lstErroresValidacion.Clear();

            Usuario nUsuario = new Usuario
            {
                Apellido = txtApellido.Text,
                Contrasena = txtContrasena.Text,
                Correo = txtCorreo.Text,
                Edad = txtEdad.Text != null ? int.Parse(txtEdad.Text) : 0,
                Genero = txtGenero.Text != null ? int.Parse(txtGenero.Text) : 0,
                MedioRecomendado = txtMedioRecomendado.Text != null ? int.Parse(txtMedioRecomendado.Text) : 0,
                Nombre = txtNombre.Text,
                NombreRecomendado = txtNombreRecomendado.Text,
                Recomendado = chkRecomendado.IsChecked,
                Telefono = txtTelefono.Text
            };

            // validando otra vez
            ValidationResult valResult = await validadorUsuario.ValidateAsync(nUsuario);

            if (!valResult.IsValid)
            {
                lstErroresValidacion = new ObservableCollection<ValidationFailure>(valResult.Errors);
                cllValidaciones.ItemsSource = lstErroresValidacion;
                cllValidaciones.IsVisible = true;
            }
            else
            {
                await DisplayAlert("Demo FluentValidation", "Usuario correcto, se registra", "Aceptar");
            }
        }
    }
}

