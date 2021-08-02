
namespace Person.API.Validators
{
    using Person.API.Models;
    using FluentValidation;
    using System;

    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("El Nombre no puede estar vacio")
                .Length(5, 20).WithMessage("El nombre debe tener mínimo 5 letras 7 máximo de 20 letras")
                .MaximumLength(20).WithMessage("El Nombre puede tener maximo 20 caracteres");

            RuleFor(p => p.Age)
                .NotNull().WithMessage("La edad no puede ser nula")
                .Must(price => price > 0).WithMessage("La edad debe ser mayor a cero")
                .InclusiveBetween(10, 90).WithMessage("La edad debe estar entre 10 y 90 años");

            RuleFor(p => p.Email)
               .NotEmpty().WithMessage("El Email no puede ser nulo")
               .EmailAddress().WithMessage("El email debe tener el formato xxxx@xxx.com");

            RuleFor(p => p.Adress)
               .NotEmpty().WithMessage("La dirección no puede ser nula");

            RuleFor(p => p.Phone)
               .NotEmpty().WithMessage("El teléfono no puede ser nulo")
            .Length(7).WithMessage("El teléfono debe contener 7 digitos")
            .Matches(@"^[\d]+$").WithMessage("El teléfono debe ser un numero, no debe contener letras ni caracteres.");

            RuleFor(p => p.Mobile)
             .NotNull().WithMessage("El celular no puede ser nulo")
             .Length(10).WithMessage("El celular debe contener 10 digitos")
             .Matches(@"^[\d]+$").WithMessage("El celular ser un numero, no debe contener letras ni caracteres.");

            RuleFor(p => p.State)
              .NotEmpty().WithMessage("El Estado no puede ser nulo")
              .Must(x => x == false || x == true).WithMessage("El estado debe ser true o false");

            RuleFor(p => p.BirthDate)
               .NotEmpty().WithMessage("El parametro BirthDate no puede ser nulo")
               .LessThan(p => DateTime.Now).WithMessage("La fecha de nacimiento no puede ser mayor a la fecha actual")
               .Must(date => date != default(DateTime)).WithMessage("La fecha de nacimiento es requerida");


            RuleFor(p => p.ZipCode)
               .NotNull().WithMessage("El código Postal no puede ser nulo");
             

            RuleFor(p=>p.ZipCode.ToString())
                .Length(6).WithMessage("El código Postal debe contener 6 dígitos")
                .Matches(@"^[\d]+$").WithMessage("El código Postal debe ser un número, no debe contener letras ni caracteres.");


        }

    }
}
