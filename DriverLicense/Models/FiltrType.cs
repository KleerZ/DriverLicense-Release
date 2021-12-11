using System.ComponentModel.DataAnnotations;

namespace DriverLicense.Models
{
    public class FiltrType
    {
        [Required(ErrorMessage = "Введите данные для фильтрации")]
        [MinLength(1, ErrorMessage = "ывывпв")]
        public string Type { get; set; }
    }
}