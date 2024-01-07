using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.InputDTO
{

    public class ServiceprovidersubcategoryDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? ParentCategoryId { get; set; }

        public int? MainCategoryId { get; set; }

        public string? ThumnailImagePath { get; set; }

      
    }
}