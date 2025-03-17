using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618
namespace Partner_API.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public string Name { get; set; }
        public int Articul { get; set; }
        public double MinCost { get; set; }

        public ProductType? ProductType { get; set; }
    }

    public class ProductDTO
    {
        [Key]
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public string Name { get; set; }
        public int Articul { get; set; }
        public double MinCost { get; set; }
    }
}
