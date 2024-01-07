using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.InputDTO
{

    public class UserDTO
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? MobileNumber { get; set; }

        public string? Address { get; set; }

        public ICollection<UserroleDTO> UserrolesDTO { get; set; } = new List<UserroleDTO>();
    }
}
