using FluentValidation;

namespace Support_Call1.Domain.DTOs.Users
{
    public class UserGetByIdDtoValidator : AbstractValidator<UserGetByIdDTO>
    {
        public UserGetByIdDtoValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("O Id do usuário deve ser preenchido.");
        }
    }
}
