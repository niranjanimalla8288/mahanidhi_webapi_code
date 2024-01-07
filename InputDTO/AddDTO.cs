namespace MahaanidhiWebAPI.InputDTO
{
    public class AddDTO
    {
        public int Id { get; set; }

        public int? Cityid { get; set; }

        public string? AddImage { get; set; }

        public string? AddPlace { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public bool? IsActive { get; set; }
    }
}
