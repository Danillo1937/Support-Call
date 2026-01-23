using Support_Call1.Domain.Enumerators;

namespace Support_Call1.Domain.DTOs.Calls
{
    public class CallsPostDto
    {
        public string Description { get; set; } = string.Empty;
        public EnumProblemType ProblemType { get; set; }
        public EnumState State { get; set; }

    }
}
