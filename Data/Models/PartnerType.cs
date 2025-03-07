using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618
namespace Partner_API.Data.Models
{
    public class PartnerType
    {
        [Key]
        public int Id { get; set; }
        public string TypeName { get; set; }
    }
}
