using Support_Call1.Domain.Enumerators;

namespace Support_Call1.Domain.Entities
{
    public class Users
    {
        public Guid Id { get; set; }
        public EnumDepartamento departament { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int CodFunc { get; set; }
    }
}
