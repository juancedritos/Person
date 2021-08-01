
namespace Persona.API.Validators
{
    using Persona.API.Models;
    using FluentValidation;
    using System;

    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("El parametro Name no puede estar vacio")
                .MaximumLength(20).WithMessage("El parametro Name puede tener maximo 20 caracteres");

            RuleFor(p => p.Age)
                .NotNull().WithMessage("El parametro Age no puede ser nulo")
                .Must(price => price > 0).WithMessage("La edad debe ser mayor a cero")
                .InclusiveBetween(10, 90).WithMessage("La edad debe estar entre 10 y 90 años");

            RuleFor(p => p.Email)
               .NotEmpty().WithMessage("El parametro Email no puede ser nulo")
               .EmailAddress().WithMessage("El email debe tener el formato xxxx@xxx.com");

            RuleFor(p => p.Adress)
               .NotEmpty().WithMessage("El parametro Adress no puede ser nulo");

            RuleFor(p => p.Phone)
               .NotEmpty().WithMessage("El parametro Phone no puede ser nulo");

            RuleFor(p => p.Mobile)
             .NotNull().WithMessage("El parametro Mobile no puede ser nulo")
             .Length(10).WithMessage("El celular debe contener 10 digitos");

            RuleFor(p => p.State)
              .NotEmpty().WithMessage("El parametro State no puede ser nulo");

            RuleFor(p => p.BirthDate)
               .NotEmpty().WithMessage("El parametro BirthDate no puede ser nulo")
               .LessThan(p => DateTime.Now).WithMessage("La fecha de nacimiento no puede ser mayor a la fecha actual")
               .Must(date => date != default(DateTime)).WithMessage("La fecha de nacimiento es requerida");


            RuleFor(p => p.ZipCode)
               .NotNull().WithMessage("El parametro ZipCode no puede ser nulo")
             .InclusiveBetween(0, 999999).WithMessage("El código Zio debe contener 6 dígitos");


        }

    }
}
