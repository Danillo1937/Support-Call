using Support_Call1.Domain.Enumerators;

namespace Support_Call1.Domain.DTOs.Users
{
    public class UserGetByIdDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public EnumDepartamento Departament { get; set; }
    }
}
