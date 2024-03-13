using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewVision.Models
{
    [Table("PType")]
    public class PType
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string ProductType { get; set; }
        public List<Product> Products { get; set; }
    }
}
