using NewVision.Models;
using Microsoft.EntityFrameworkCore;

namespace NewVision.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _db;

        public HomeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<PType>> PTypes()
        {
            return await _db.PTypes.ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProducts(string sTerm = "", int pTypeId = 0)
        {
            sTerm = sTerm.ToLower();
            IEnumerable<Product> products = await (from product in _db.Products
                         join pType in _db.PTypes
                         on product.PTypeId equals pType.Id
                         where string.IsNullOrWhiteSpace(sTerm) || (product != null && product.ProductName.ToLower().StartsWith(sTerm))
                         select new Product
                         {
                             Id = product.Id,
                             Image = product.Image,
                             SupplierName = product.SupplierName,
                             ProductName = product.ProductName,
                             PTypeId = product.PTypeId,
                             Price = product.Price,
                             ProductType = pType.ProductType
                         }
                         ).ToListAsync();
            if (pTypeId > 0)
            {

                products = products.Where(a => a.PTypeId == pTypeId).ToList();
            }
            return products;

        }
    }
}
