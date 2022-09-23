using System;

namespace Aircraft.API.Request
{
    public class StageRequest
    {
        public string Value { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int Type { get; set; }
        public Guid MaintenanceId { get; set; }
        public DateTime CreatedAt => DateTime.Now;
    }
}
