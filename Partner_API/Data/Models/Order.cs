using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618
namespace Partner_API.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PartnerId { get; set; }
        public int Count { get; set; }
        public DateOnly Date { get; set; }

        public Partner? Partner { get; set; }
        public Product? Product { get; set; }
    }
    public class OrderDTO
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PartnerId { get; set; }
        public int Count { get; set; }
        public DateOnly Date { get; set; }
    }
}
