using Humanizer.Localisation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewVision.Models
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string? ProductName { get; set; }

        [Required]
        [MaxLength(40)]
        public string? SupplierName { get; set; }
        [Required]
        public double Price { get; set; }
        public string? Image { get; set; }
        [Required]
        public int PTypeId { get; set; }
        public PType PType { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
        public List<CartDetail> CartDetail { get; set; }

        [NotMapped]
        public string ProductType { get; set; }

    }
}
