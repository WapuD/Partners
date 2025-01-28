using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618
namespace Partner_API.Data.Models
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public double koef { get; set; }
    }
}
