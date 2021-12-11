using System.ComponentModel.DataAnnotations;

namespace DriverLicense.Models.Account
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Поле 'Имя' должно быть заполнено")]
        [MaxLength(15, ErrorMessage = "Размерность поля не должна превышать 15 символов")]
        [MinLength(3, ErrorMessage = "Минимальная размерность поля - 3 символа")]
        // [RegularExpression(@"A-Za-zА-я", ErrorMessage = "Некорректные данные")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Поле 'Фамилия' должно быть заполнено")]
        [MaxLength(15, ErrorMessage = "Размерность поля не должна превышать 15 символов")]
        [MinLength(3, ErrorMessage = "Минимальная размерность поля - 3 символа")]
        // [RegularExpression(@"A-Za-zА-я", ErrorMessage = "Некорректные данные")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Поле 'Пароль' должно быть заполнено")]
        [MaxLength(15, ErrorMessage = "Размерность поля не должна превышать 15 символов")]
        [MinLength(8, ErrorMessage = "Минимальная размерность поля - 8 символов")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Поле 'Подтверждение пароля' должно быть заполнено")]
        [MaxLength(15, ErrorMessage = "Размерность поля не должна превышать 15 символов")]
        [MinLength(8, ErrorMessage = "Минимальная размерность поля - 8 символов")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordCheck { get; set; }
        
        [Required(ErrorMessage = "Заполните поле")]
        [MinLength(13, ErrorMessage = "Минимальная размерность поля - 13")]
        [MaxLength(13, ErrorMessage = "Минимальная размерность поля - 13")]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}