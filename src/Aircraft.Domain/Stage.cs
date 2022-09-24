using System;

namespace Aircraft.Domain
{
    public class Stage
    {
        public Guid Id { get; set; }
        public Maintenance Maintenance { get; set; }
        public Guid MaintenanceId { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public bool Status { get; set; }
        public string Value { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
