using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618
namespace Partner_API.Data.Models
{
    public class Partner
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronumic { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Index { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Inn { get; set; }
        public int Rating { get; set; }
    }
}
