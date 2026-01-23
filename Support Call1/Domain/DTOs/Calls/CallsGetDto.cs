using FluentValidation;
using Support_Call1.Domain.Enumerators;

namespace Support_Call1.Domain.DTOs.Calls
{
    public class CallsGetDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public EnumProblemType ProblemType { get; set; }
        public EnumState State { get; set; }
    }
}
