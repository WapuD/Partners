using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618
namespace Partner_API.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int type { get; set; }
        public string name { get; set; }
        public int articul { get; set; }
        public double minCost { get; set; }

        public ProductType? Type { get; set; }
    }
}
