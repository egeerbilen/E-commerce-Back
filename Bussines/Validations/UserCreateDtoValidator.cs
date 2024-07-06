using Entity.DTOs;
using FluentValidation;

namespace Bussines.Validations
{
    public class UserCreateDtoValidator : AbstractValidator<UserCreateDto> // kimi validate edeceğiz ProductDto onu yazdık
    {
        // validation larımızın yapıldığı yerdir
        public UserCreateDtoValidator()
        {
            // PropertyName name dediğimizde Name ismi direk olarak buraya geliyor
            RuleFor(x => x.FirstName).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MinimumLength(3).MaximumLength(50).WithMessage("{PropertyName} must be between 3 and 50 characters long.");

            // Price default olarak 0 dırbunun için NotNull NotEmpity işe yaramaz double int float null olamaz
            // bunun için dahil edeceğimiz aralığı belirtiriz InclusiveBetween
            RuleFor(x => x.LastName).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MinimumLength(3).MaximumLength(50).WithMessage("{PropertyName} must be between 3 and 50 characters long.");
            RuleFor(x => x.Email).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MinimumLength(3).MaximumLength(50).WithMessage("{PropertyName} must be between 3 and 50 characters long.");
            RuleFor(x => x.Password).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MinimumLength(3).MaximumLength(50).WithMessage("{PropertyName} must be between 3 and 50 characters long.");
        }


    }
}
