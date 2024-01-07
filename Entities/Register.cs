﻿using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class Register
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? MobileNumber { get; set; }

    public string? Address { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public string? Token { get; set; }
}
