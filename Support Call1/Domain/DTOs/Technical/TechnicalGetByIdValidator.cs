using FluentValidation;

namespace Support_Call1.Domain.DTOs.Technical
{
    public class TechnicalGetByIdValidator : AbstractValidator<TechnicalGetById>
    {
        public TechnicalGetByIdValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("O Id deve ser preenchido.");
        }
    }
}
