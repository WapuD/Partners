using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618
namespace Partner_API.Data.Models
{
    public class Partner
    {
        [Key]
        public int Id { get; set; }
        public int Type { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(20, ErrorMessage = "Фамилия не может содержать больше 20 символов")]
        [DataType(DataType.Text)]
        public string Surname { get; set; }
        [StringLength(20, ErrorMessage = "Имя не может содержать больше 20 символов")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [StringLength(20, ErrorMessage = "Отчество не может содержать больше 20 символов")]
        [DataType(DataType.Text)]
        public string Patronumic { get; set; }
        [StringLength(100, ErrorMessage = "Поле не может содержать больше 100 символов")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [StringLength(6, ErrorMessage = "Поле не может содержать больше 6 символов")]
        public string Index { get; set; }
        [StringLength(30, ErrorMessage = "Поле не может содержать больше 30 символов")]
        public string Region { get; set; }
        [StringLength(30, ErrorMessage = "Поле не может содержать больше 30 символов")]
        public string City { get; set; }
        [StringLength(30, ErrorMessage = "Поле не может содержать больше 30 символов")]
        public string Street { get; set; }
        [StringLength(4, ErrorMessage = "Поле не может содержать больше 4 символов")]
        public string House { get; set; }
        [StringLength(12, ErrorMessage = "Поле не может содержать больше 12 символов")]
        public string Inn { get; set; }
        [StringLength(3, ErrorMessage = "Поле не может содержать больше 3 символов")]
        [Range(0, 10, ErrorMessage = "Значение должно быть в диапазоне от 0 до 10")]
        public int Rating { get; set; }
    }
}
