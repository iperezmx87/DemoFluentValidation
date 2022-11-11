using FluentValidation;
using System.Text.RegularExpressions;

namespace DemoFluentValidation.Model.Validadores
{
    public class ValidadorContrasena : AbstractValidator<string?>
	{
        private const string REGEX_PATTERN = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!@#$%&/()]).{8,}$";

        public ValidadorContrasena()
		{
			// obligatorio
			// minimo de 8 caracteres
			// que cumpla con las reglas de seguridad
			RuleFor(contrasena => contrasena)
				.Empty().WithMessage("{PropertyName} es requerido.")
                .NotNull().WithMessage("{PropertyName} es requerido.")
                .MinimumLength(8).WithMessage("El tamaño mínimo de {PropertyName} es {MinumumLength}.")
                // aqui se colocan las reglas de seguridad de contraseñas
                // normalmente contra una xpresion regular
                // personalizar la contraseña
                .Must(contra => {
                    // una mayuscula minimo y un caracter especial !@#$%&/()
                    var regEx = Regex.Match(contra, REGEX_PATTERN);
					return regEx.Success;
				}).WithMessage("La contraseña debe contener al menos una letra mayúscula y un caracter especial --!@#$%&/()--");
		}
	}
}
