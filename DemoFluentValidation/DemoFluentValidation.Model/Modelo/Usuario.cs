using System;
namespace DemoFluentValidation.Model
{
    public class Usuario
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

        public string? Correo { get; set; }
        public string? Contrasena { get; set; }

        public int? Edad { get; set; }

        public int? Genero { get; set; }

        public string? Telefono { get; set; }

        public bool Recomendado { get; set; }
        public string? NombreRecomendado { get; set; }
        public int? MedioRecomendado { get; set; }
    }

    public enum Sexo
    {
        Masculino = 1,
        Femenino = 2,
        Indefinido = 3
    }

    public enum Recomendacion
    {
        RedesSociales = 1,
        Buscador = 2,

    }
}
