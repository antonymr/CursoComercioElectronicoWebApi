using Curso.ComercioElectronico.Aplicacion.Dtos.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Aplicacion.Validator
{
    public class OrderValidator : AbstractValidator<CreateOrderDto>
    {
        public OrderValidator()
        {
            //ClientName
            RuleFor(a => a.ClientName).NotEmpty().NotNull();
            RuleFor(a => a.ClientName).MaximumLength(250);

            //Relations
                // Deliverty Method
            RuleFor(a => a.DeliveryMethodId).NotNull().NotEmpty();
            RuleFor(a => a.DeliveryMethodId).MaximumLength(4);
                // Order Type
            RuleFor(a => a.OrderLines).NotNull().NotEmpty();

        }
    }
}
