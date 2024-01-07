using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.InputDTO;

public partial class CustomfieldDTO
{
    public int Id { get; set; }

    public int? CategoryId { get; set; }

    public string? FieldName { get; set; }

    public string? FieldTitle { get; set; }

    public string? Type { get; set; }

    public string? Options { get; set; }

    public bool? IsRequired { get; set; }

    public string? HelpText { get; set; }

    public string? ShowInDetail { get; set; }

    public string? ShowInSearch { get; set; }

    public string? SortOrder { get; set; }

    public string? Status { get; set; }
}
