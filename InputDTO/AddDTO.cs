namespace MahaanidhiWebAPI.InputDTO
{
    public class AddDTO
    {
        public int Id { get; set; }

        public int? CityId { get; set; }

        public int CategoryId { get; set; }

        public string? AddImage { get; set; }

        public string? AddPlace { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

    }
}
