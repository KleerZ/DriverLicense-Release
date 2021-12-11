using System.Collections.Generic;

namespace Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<UsersForms> UsersFormsCollection { get; set; }
    }
}