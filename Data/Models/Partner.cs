using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618
namespace Partner_API.Data.Models
{
    public class Partner
    {
        [Key]
        public int Id { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronumic { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string index { get; set; }
        public string region { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string house { get; set; }
        public string inn { get; set; }
        public int rating { get; set; }
    }
}
