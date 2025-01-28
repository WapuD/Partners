using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618
namespace Partner_API.Data.Models
{
    public class Material
    {
        [Key]
        public int Id { get; set; }
        public string type { get; set; }
        public double percentDefective { get; set; }
    }
}
