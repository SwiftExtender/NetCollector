using System.ComponentModel.DataAnnotations;

namespace NetFighter.RequestModels
{
    public class CreatedHost
    {
        public string Ip;
        public string Info;
    }
    public class UpdatedHost 
    {
        public int Id;
        public string Ip;
        public string Info;
    }
    public class HostsQueryParameters
    {
        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; } = 1;
        [Range(1, 100)]
        public int PageSize { get; set; } = 10;
        public string? Ip { get; set; }
        public string? Status { get; set; }
    }
}
