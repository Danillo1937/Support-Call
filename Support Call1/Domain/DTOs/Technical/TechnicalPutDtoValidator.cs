using FluentValidation;

namespace Support_Call1.Domain.DTOs.Technical
{
    public class TechnicalPutDtoValidator : AbstractValidator<TechnicalPutDto>
    {
        public TechnicalPutDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O nome deve ser preenchido.")
                .MaximumLength(255).WithMessage("O nome não pode exceder 255 caracteres.");

            RuleFor(p => p.Speciality)
                .NotEmpty().WithMessage("A especialidade deve ser preenchida.");

            RuleFor(p => p.TypeOfThecnical)
                .IsInEnum().WithMessage("O tipo do técnico deve ser preenchido.");

            RuleFor(p => p.Seniority)
                .IsInEnum().WithMessage("A senioridade deve ser preenchida.");
        }
    }
}
