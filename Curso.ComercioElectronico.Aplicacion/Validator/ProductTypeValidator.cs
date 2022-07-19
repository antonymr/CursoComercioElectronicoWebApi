using Curso.ComercioElectronico.Aplicacion.Dtos.Create;
using FluentValidation;

namespace Curso.ComercioElectronico.Aplicacion.Validator
{
    public class ProductTypeValidator : AbstractValidator<CreateProductTypeDto>
    {
        public ProductTypeValidator()
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
