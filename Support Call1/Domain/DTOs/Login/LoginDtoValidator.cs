using FluentValidation;

namespace Support_Call1.Domain.DTOs.Login
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("O email deve ser preenchido.")
                .EmailAddress().WithMessage("Um email válido é requerido.");
            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("A senha deve ser preenchida.")
                .MaximumLength(255).WithMessage("Senha não pode exceder 255 caracteres.");
        }
    }
}
