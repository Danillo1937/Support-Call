using Support_Call1.Domain.Enumerators;

namespace Support_Call1.Domain.Entities
{
    public class Technical
    {
        public Guid id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Speciality { get; set; } = string.Empty;
        public EnumTypeOfThecnical TypeOfThecnical { get; set; }
        public EnumSeniority Seniority { get; set; }
  

    }
}
