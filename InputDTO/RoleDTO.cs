using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.InputDTO
{

    public class RoleDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public ICollection<UserroleDTO> UserrolesDTO { get; set; } = new List<UserroleDTO>();
    }
}