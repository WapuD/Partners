using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618
namespace Partner_API.Data.Models
{
    public class Partner
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Тип партнёра обязателен")]
        [Range(1, int.MaxValue, ErrorMessage = "Тип партнёра должен быть задан")]
        public int Type { get; set; }

        [Required(ErrorMessage = "Название организации обязательно")]
        [StringLength(100, ErrorMessage = "Название не может превышать 100 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁ\s\-]+$", ErrorMessage = "Название может содержать только буквы, пробелы и дефисы")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Фамилия обязательна")]
        [StringLength(20, ErrorMessage = "Фамилия не может содержать больше 20 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁ\-]+$", ErrorMessage = "Фамилия может содержать только буквы и дефисы")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Имя обязательное")]
        [StringLength(20, ErrorMessage = "Имя не может содержать больше 20 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁ\-]+$", ErrorMessage = "Имя может содержать только буквы и дефисы")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Отчество обязательное")]
        [StringLength(20, ErrorMessage = "Отчество не может содержать больше 20 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁ\-]+$", ErrorMessage = "Отчество может содержать только буквы и дефисы")]
        public string Patronumic { get; set; }

        [Required(ErrorMessage = "Email обязательное")]
        [StringLength(100, ErrorMessage = "Email не может превышать 100 символов")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Некорректный формат email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Телефон обязательный")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\+7\d{10}$", ErrorMessage = "Некорректный формат телефона (+7XXXXXXXXXX)")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Индекс обязательный")]
        [StringLength(6, ErrorMessage = "Индекс не может содержать больше 6 символов")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Индекс должен состоять из 6 цифр")]
        public string Index { get; set; }

        [Required(ErrorMessage = "Регион обязательный")]
        [StringLength(30, ErrorMessage = "Регион не может превышать 30 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁ\s\-\.]+$", ErrorMessage = "Регион может содержать только буквы, пробелы, дефисы и точки")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Город обязательный")]
        [StringLength(30, ErrorMessage = "Город не может превышать 30 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁ\s\-\.]+$", ErrorMessage = "Город может содержать только буквы, пробелы, дефисы и точки")]
        public string City { get; set; }

        [Required(ErrorMessage = "Улица обязательная")]
        [StringLength(30, ErrorMessage = "Улица не может превышать 30 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁ\s\-\.]+$", ErrorMessage = "Улица может содержать только буквы, пробелы, дефисы и точки")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Номер дома обязательный")]
        [StringLength(4, ErrorMessage = "Номер дома не может превышать 4 символов")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Номер дома должен состоять из цифр")]
        public string House { get; set; }

        [Required(ErrorMessage = "ИНН обязательный")]
        [StringLength(12, ErrorMessage = "ИНН должен состоять из 12 цифр")]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "ИНН должен состоять из 12 цифр")]
        public string Inn { get; set; }

        [Required(ErrorMessage = "Рейтинг обязателен")]
        [Range(0, 10, ErrorMessage = "Рейтинг должен быть от 0 до 10")]
        public int Rating { get; set; }
    }
}
