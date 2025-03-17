using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618
namespace Partner_API.Data.Models
{
    public class Material
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public double PercentDefective { get; set; }
    }
}
