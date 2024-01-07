using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.InputDTO
{

    public class ServiceprovidercategoryDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? ThumnailImagePath { get; set; }

        public ICollection<CityserviceprovidercategoryDTO> CityserviceprovidercategoriesDTO { get; set; } = new List<CityserviceprovidercategoryDTO>();

        public ICollection<ServiceproviderDTO> ServiceprovidersDTO { get; set; } = new List<ServiceproviderDTO>();

        public ICollection<ServiceprovidersubcategoryDTO> ServiceprovidersubcategoriesDTO { get; set; } = new List<ServiceprovidersubcategoryDTO>();
    }
}
