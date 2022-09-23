using System;
using System.Collections.Generic;

namespace Aircraft.Domain
{
    public class UserProfile
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }    
        public DateTime CreatedAt => DateTime.Now;
        public IEnumerable<Maintenance> Maintenances { get; set; }
    }
}