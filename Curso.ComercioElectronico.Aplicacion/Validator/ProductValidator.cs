using Curso.ComercioElectronico.Aplicacion.Dtos.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Aplicacion.Validator
{
    public class ProductValidator : AbstractValidator<CreateProductDto>
    {
        public ProductValidator()
        {
            //Name
            RuleFor(a => a.Name).NotEmpty().NotNull();
            RuleFor(a => a.Name).MaximumLength(100);

            //Description
            RuleFor(a => a.Description).MaximumLength(256);

            //Price
            RuleFor(a => a.Price).NotNull();

            //Relations
                // Brand
            RuleFor(a => a.BrandId).NotNull().NotEmpty();
            RuleFor(a => a.BrandId).MaximumLength(4);
                // Product Type
            RuleFor(a => a.ProductTypeId).NotNull().NotEmpty();
            RuleFor(a => a.ProductTypeId).MaximumLength(4);

        }
    }
}
