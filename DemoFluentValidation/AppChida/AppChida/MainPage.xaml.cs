using System.Collections.Generic;
using System.Collections.ObjectModel;
using DemoFluentValidation.Model;
using DemoFluentValidation.Model.Validadores;
using FluentValidation;
using FluentValidation.Results;
using Xamarin.Forms;

namespace AppChida
{
    public partial class MainPage : ContentPage
    {
        private IValidator<Login> validadorLogin;
        private ObservableCollection<ValidationFailure> lstErroresValidacion;

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            validadorLogin = new ValidadorLogin();

            cllValidaciones.IsVisible = false;
            lstErroresValidacion = new ObservableCollection<ValidationFailure>();
            cllValidaciones.ItemsSource = lstErroresValidacion;
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            // ocultar el set de validadores
            cllValidaciones.IsVisible = false;
            lstErroresValidacion.Clear();

            Login modeloLogin = new Login()
            {
                Contrasena = txtContra.Text,
                Correo = txtEmail.Text
            };

            // validando ando
            ValidationResult resLogin = await validadorLogin.ValidateAsync(modeloLogin);

            if (!resLogin.IsValid)
            {
                lstErroresValidacion = new ObservableCollection<ValidationFailure>(resLogin.Errors);
                cllValidaciones.ItemsSource = lstErroresValidacion;
                cllValidaciones.IsVisible = true;
            }
            else
            {
                await DisplayAlert("Demo FluentValidation", "Todo en orden", "Aceptar");
            }
        }

        async void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {
            await App.nvp.PushAsync(new RegisterPage());
        }
    }
}

