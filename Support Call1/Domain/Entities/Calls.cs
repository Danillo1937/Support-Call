using Microsoft.OpenApi.MicrosoftExtensions;
using Support_Call1.Domain.Enumerators;

namespace Support_Call1.Domain.Entities
{
    public class Calls
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public EnumProblemType ProblemType { get; set; }
        public EnumState State { get; set; }
        public required Users User { get; set; }
    }
}
