using System.Collections.Generic;
using Data.Models;
using Users = DocumentFormat.OpenXml.Spreadsheet.Users;

namespace DriverLicense.Models.Combined
{
    public class CombineFormsRadio
    {
        public IEnumerable<Data.Models.UsersForms> UsersForms { get; set; }
        public ClickedRadioButton ClickedRadioButton { get; set; }
        public FiltrType FiltrType { get; set; }
    }
}