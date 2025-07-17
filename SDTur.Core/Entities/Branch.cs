using System.Collections.Generic;

namespace SDTur.Core.Entities
{
    public class Branch : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        
        // Navigation properties
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
} 