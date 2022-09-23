using System;

namespace Aircraft.API.Request
{
    public class MaintenanceRequest
    {
        public string Description { get; set; }
        public bool Status { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt => DateTime.Now;
    }
}
