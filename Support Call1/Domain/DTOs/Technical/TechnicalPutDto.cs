using Support_Call1.Domain.Enumerators;

namespace Support_Call1.Domain.DTOs.Technical
{
    public class TechnicalPutDto
    {
        public string Name { get; set; }
        public string Speciality { get; set; }
        public EnumTypeOfThecnical TypeOfThecnical { get; set; }
        public EnumSeniority Seniority { get; set; }
    }
}
