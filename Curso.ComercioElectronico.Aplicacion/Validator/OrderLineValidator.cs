using Curso.ComercioElectronico.Aplicacion.Dtos.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Aplicacion.Validator
{
    public class OrderLineValidator : AbstractValidator<CreateOrderLineDto>
    {
        public OrderLineValidator()
        {
            //Quantity
            RuleFor(a => a.Quantity).NotEmpty().NotNull();

            //Taxes
            RuleFor(a => a.TaxRate).NotEmpty().NotNull();

            //Relations
            // Product
            RuleFor(a => a.ProductId).NotNull().NotEmpty();

        }
    }
}
