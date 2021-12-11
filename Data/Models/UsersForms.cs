using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class UsersForms
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string MilitaryTicket { get; set; }
        public string Category { get; set; }
        public string PassportID { get; set; }
        
        public virtual Users Users { get; set; }    
        public virtual Category Categories { get; set; }
        // public virtual Customers Customers { get; set; }
    }
}