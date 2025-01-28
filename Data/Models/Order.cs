using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618
namespace Partner_API.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int product { get; set; }
        public int partner { get; set; }
        public int count { get; set; }
        public DateOnly date { get; set; }

        public Partner? Partner { get; set; }
        public Product? Product { get; set; }
    }
    public class OrderDTO
    {
        [Key]
        public int Id { get; set; }
        public int product { get; set; }
        public int partner { get; set; }
        public int count { get; set; }
        public DateOnly date { get; set; }
    }
}
