using FluentValidation;

namespace Support_Call1.Domain.DTOs.Users
{
    public class UserPutDtoValidator: AbstractValidator<UserGetDTO>
    {
        public UserPutDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O nome deve ser preenchido.")
                .MaximumLength(100).WithMessage("Nome não pode exceder 255 caracteres.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("O email deve ser preenchido.")
                .EmailAddress().WithMessage("Um email válido é requerido.");

            RuleFor(p => p.Departament)
                .IsInEnum().WithMessage("Um departamento deve ser preenchido.");
        }
    }
}
