using System.ComponentModel.DataAnnotations;

namespace DriverLicense.Models
{
    public class ClickedRadioButton
    {
        [Required(ErrorMessage = "Выберите тип фильтрации")]
        [MinLength(1, ErrorMessage = "ывывпв")]
        public string Text { get; set; }
    }
}