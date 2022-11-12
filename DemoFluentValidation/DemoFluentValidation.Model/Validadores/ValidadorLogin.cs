using System.Text.RegularExpressions;
using FluentValidation;

namespace DemoFluentValidation.Model.Validadores
{
    public class ValidadorLogin : AbstractValidator<Login>
    {
        private const string REGEX_PATTERN = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!@#$%&/()]).{8,}$";

        public ValidadorLogin()
        {
            // aqui viene la hoja de validaciones sobre los datos del modelo

            // el correo debe ser obligatorio y ser una direccion de correo
            RuleFor(login => login.Correo)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull().WithMessage("{PropertyName} es requerido.")
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("El correo debe ser uno válido");

            RuleFor(login => login.Contrasena)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull().WithMessage("{PropertyName} es requerido.")
                .MinimumLength(8).WithMessage("El tamaño mínimo de {PropertyName} es {MinLength}.");

            When(login => login.Contrasena != null, () =>
            {
                // aqui se colocan las reglas de seguridad de contraseñas
                // normalmente contra una xpresion regular
                // personalizar la contraseña
                RuleFor(login => login.Contrasena)
                .Cascade(CascadeMode.Stop)
                .Must(contra =>
                {
                    // una mayuscula minimo y un caracter especial !@#$%&/()
                    var regEx = Regex.Match(contra, REGEX_PATTERN);
                    return regEx.Success;
                }).WithMessage("La contraseña debe contener al menos una letra mayúscula y un caracter especial --!@#$%&/()--");
            });
        }
    }
}
