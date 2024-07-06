using Entity.DTOs;
using FluentValidation;

namespace Bussines.Validations
{
    public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto> 
    {
        public UserUpdateDtoValidator()
        {
            RuleFor(x => x.FirstName).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MinimumLength(3).MaximumLength(50).WithMessage("{PropertyName} must be between 3 and 50 characters long.");
            RuleFor(x => x.LastName).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MinimumLength(3).MaximumLength(50).WithMessage("{PropertyName} must be between 3 and 50 characters long.");
            RuleFor(x => x.Email).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MinimumLength(3).MaximumLength(50).WithMessage("{PropertyName} must be between 3 and 50 characters long.");
            RuleFor(x => x.Password).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MinimumLength(3).MaximumLength(50).WithMessage("{PropertyName} must be between 3 and 50 characters long.");
        }
    }
}
