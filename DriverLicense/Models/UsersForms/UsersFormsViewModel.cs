using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace DriverLicense.Models.UsersForms
{
    public class UsersFormsViewModel
    {
        [Required(ErrorMessage = "Заполните поле")]
        [MinLength(3, ErrorMessage = "Минимальная размерность поля - 3 символа")]
        [MaxLength(15, ErrorMessage = "Минимальная размерность поля - 15 символа")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Заполните поле")]
        [MinLength(3, ErrorMessage = "Минимальная размерность поля - 3 символа")]
        [MaxLength(15, ErrorMessage = "Минимальная размерность поля - 15 символа")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Заполните поле")]
        [MinLength(13, ErrorMessage = "Минимальная размерность поля - 3 символа")]
        [MaxLength(13, ErrorMessage = "Минимальная размерность поля - 13 символа")]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Выберите вариант из списка")]
        public string MilitaryTicket { get; set; }
        
        [Required(ErrorMessage = "Заполните поле")]
        [MinLength(14, ErrorMessage = "Минимальная размерность поля - 3 символа")]
        [MaxLength(14, ErrorMessage = "Минимальная размерность поля - 13 символа")]
        public string PassportID { get; set; }
        
        // [Required(ErrorMessage = "Выберите вариант из списка")]
        // public string HealthGroup { get; set; }
        
        [Required(ErrorMessage = "Выберите вариант из списка")]
        [MaxLength(3, ErrorMessage = "2")]
        [MinLength(1, ErrorMessage = "1")]
        public string Category { get; set; }
    }
}