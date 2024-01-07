using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.InputDTO;

public class UserroleDTO
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? RoleId { get; set; }

    public   RoleDTO? Role { get; set; }

    public   UserDTO? User { get; set; }
}
