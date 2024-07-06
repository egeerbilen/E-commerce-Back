using Core.DTOs;
using FluentValidation;

namespace NLayer.Service.Validations
{
    public class CategoryCreateDtoValidator : AbstractValidator<CategoryDto>
    {
        public CategoryCreateDtoValidator()
        {
            // PropertyName name dediğimizde Name ismi direk olarak buraya geliyor
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MinimumLength(3).MaximumLength(50).WithMessage("{PropertyName} must be between 3 and 50 characters long.");
        }
    }
}
