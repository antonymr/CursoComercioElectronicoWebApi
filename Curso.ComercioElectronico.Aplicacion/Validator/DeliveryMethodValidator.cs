using Curso.ComercioElectronico.Aplicacion.Dtos.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Aplicacion.Validator
{
    public class DeliveryMethodValidator : AbstractValidator<CreateDeliveryMethodDto>
    {
        public DeliveryMethodValidator()
        {
            RuleFor(a => a.Code).NotNull().NotEmpty();
            RuleFor(a => a.Code).Length(4);

            RuleFor(a => a.Name).NotNull().NotEmpty();
            RuleFor(a => a.Name).MaximumLength(256);
            
            RuleFor(a => a.Description).NotNull().NotEmpty();
            RuleFor(a => a.Description).MaximumLength(256);
        }
    }
}
