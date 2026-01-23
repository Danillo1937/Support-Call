using FluentValidation;

namespace Support_Call1.Domain.DTOs.Calls
{
    public class CallsPostDtoValidator : AbstractValidator<CallsPostDto>
    {
        public CallsPostDtoValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("A descrição deve ser preenchida.")
                .MaximumLength(1000).WithMessage("A descrição não pode exceder 1000 caracteres.");

            RuleFor(p => p.ProblemType)
                .NotEmpty().WithMessage("O tipo de problema deve ser preenchido.");

            RuleFor(p => p.State)
                .NotEmpty().WithMessage("O estado de andamento deve ser preenchido.");
        }
    }
}
