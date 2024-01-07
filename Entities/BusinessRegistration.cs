﻿using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class BusinessRegistration
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? Address { get; set; }
}
