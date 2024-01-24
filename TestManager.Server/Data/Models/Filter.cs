namespace TestManager.Server.Data.Models
{
    public class Filter
    {
        public string? FwVersion { get; set; } = null;
        public string? RackName { get; set; } = null;
        public string? Status { get; set; } = null;

        public DateTime? SpecifiedDate { get; set; } = null;
        public DateTime? StartDate { get; set; } = null;

        public DateTime? EndDate { get; set; } = null;

        public bool All { get; set; } = false;

    }
}
