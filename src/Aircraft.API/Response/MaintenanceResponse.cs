using Aircraft.Domain;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Aircraft.API.Response
{
    public class MaintenanceResponse
    {
        public Guid Id { get; set; }
        public UserProfile User { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<Stage> Stages { get; set; }
    }
}
