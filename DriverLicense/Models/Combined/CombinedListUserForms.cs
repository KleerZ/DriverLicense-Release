using System.Collections.Generic;
using Data.Models;
using DriverLicense.Models.UsersForms;

namespace DriverLicense.Models.Combined
{
    public class CombinedListUserForms
    {
        public UsersFormsViewModel UsersFormsViewModel { get; set; }
        public List<Data.Models.Category> Categories { get; set; }
        public Category Category { get; set; }
    }
}