using FluentValidation;

namespace Support_Call1.Domain.DTOs.Users
{
    public class UserPostDtoValidator : AbstractValidator<UserPostDTO>
    {
        public UserPostDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O nome deve ser preenchido.")
                .MaximumLength(100).WithMessage("Nome não pode exceder 255 caracteres.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("O email deve ser preenchido.")
                .EmailAddress().WithMessage("Um email válido é requerido.");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("A senha deve ser preenchida.")
                .MaximumLength(255).WithMessage("Senha não pode exceder 255 caracteres.");

            RuleFor(p => p.ConfirmPassword)
                .NotEmpty().WithMessage("A confirmação de senha deve ser preenchida.")
                .Equal(user => user.Password).WithMessage("As senha não coincidem.");

            RuleFor(p => p.Departament)
                .IsInEnum().WithMessage("Um departamento deve ser preenchiddo.");
        }
    }
}
