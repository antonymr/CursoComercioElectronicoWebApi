using Curso.ComercioElectronico.Aplicacion.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Aplicacion.Validator
{
    public class ProductTypeValidator : AbstractValidator<CreateProductTypeDto>
    {
        public ProductTypeValidator()
        {
            //Code
            RuleFor(a => a.Code).NotNull().NotEmpty();
            RuleFor(a => a.Code).MaximumLength(4);

            //Description
            RuleFor(a => a.Description).NotNull().NotEmpty();
            RuleFor(a => a.Description).MaximumLength(256);
        }
    }
}
