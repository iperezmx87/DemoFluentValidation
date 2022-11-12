using System;
using FluentValidation;

namespace DemoFluentValidation.Model.Validadores
{
	public class ValidadorUsuario : AbstractValidator<Usuario>
	{
		public ValidadorUsuario()
		{
			// reglas para validar el formulario de registro

			// nombre
			RuleFor(us => us.Nombre)
				.Cascade(CascadeMode.Stop)
				.NotEmpty().WithMessage("Oye, debes poner un nombre")
				.NotNull().WithMessage("Hey, no pongas null")
				.Length(5, 20).WithMessage("Aguas! solo puedes poner entre 5 y 20 caracteres");

			RuleFor(us => us.Edad)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Por favor ingresa una edad diferente de 0")
				.NotNull().WithMessage("Debe existir una edad")
				.GreaterThan(1)
				.LessThan(120).WithMessage("Favor de poner una edad razonable");

			When(us => us.Recomendado, () => {
				RuleFor(us => us.NombreRecomendado)
                .Cascade(CascadeMode.Stop)
                .NotNull()
				.NotEmpty().WithMessage("Ingrese quien lo recomendó").WithErrorCode("Err011")
				.Length(10, 50).WithMessage("{PropertyName} no corresponde al tamaño adecuado");
			});

			// genero
			//RuleFor(us => us.Genero)
			//	.Must(gen => {

			//		return System.Enum.IsDefined(typeof(Sexo), gen);

			//	}).WithErrorCode("Erro012")
			//	.WithMessage("Selecciona un genero valido");

			//When(us => us.DireccionUsuario != null, () => {
			//	RuleFor(us => us.DireccionUsuario).SetValidator(new DireccionValidador());
			//});
		}
	}	
}
