namespace NewVision.Models.DTOs
{
    public class ProductDisplayModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<PType> PTypes { get; set; }
        public string STerm { get; set; } = "";
        public int PTypeId { get; set; } = 0;
    }
}
