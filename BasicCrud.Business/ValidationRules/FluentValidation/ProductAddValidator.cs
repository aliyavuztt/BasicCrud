using BasicCrud.Entities.Dtos;
using FluentValidation;

namespace BasicCrud.Business.ValidationRules.FluentValidation
{
    public class ProductAddValidator : AbstractValidator<ProductAddDto>
    {
        public ProductAddValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).Length(2, 50);
            RuleFor(p => p.Price).NotEmpty();
            RuleFor(p => p.Price).GreaterThanOrEqualTo(1);
            RuleFor(p => p.Stock).NotEmpty();
            RuleFor(p => p.Stock).GreaterThanOrEqualTo(1);
        }
    }
}
