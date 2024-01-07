namespace MahaanidhiWebAPI.InputDTO
{
    public class RegisterDto1
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string? MiddleName { get; set; }

        public string LastName { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string? Email { get; set; }

        public string MobileNumber { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? Role { get; set; }

        public string? Token { get; set; }
    }
}
