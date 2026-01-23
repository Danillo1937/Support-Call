using FluentValidation;

namespace Support_Call1.Domain.DTOs.Calls
{
    public class CallsGetByIdValidator : AbstractValidator<CallsGetByIdDto>
    {
        public CallsGetByIdValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("O Id deve ser preenchido.");
        }
    }
}
