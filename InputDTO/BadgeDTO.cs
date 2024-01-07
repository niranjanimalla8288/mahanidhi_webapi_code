using MahaanidhiWebAPI.InputDTO;


namespace MahaanidhiWebAPI.InputDTO
{

    public class BadgeDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? ThumnailImagePath { get; set; }

        //public ICollection<ServiceproviderbadgeDTO> ServiceproviderbadgesDTO { get; set; } = new List<ServiceproviderbadgeDTO>();
    }
}


