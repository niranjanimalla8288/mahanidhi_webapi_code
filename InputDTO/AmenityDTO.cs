using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.InputDTO
{

    public partial class AmenityDTO
    {
        public int Id { get; set; }

        public int? CategoryId { get; set; }

        public string? Options { get; set; }

        public int? Status { get; set; }
    }
}
