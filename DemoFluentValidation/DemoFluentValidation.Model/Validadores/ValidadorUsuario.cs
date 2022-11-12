using System;
using FluentValidation;

namespace DemoFluentValidation.Model.Validadores
{
	public class ValidadorUsuario : AbstractValidator<Usuario>
	{
		public ValidadorUsuario()
		{
			// reglas para validar el formulario de registro

		}
	}
}
