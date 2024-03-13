namespace NewVision
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Product>> GetProducts(string sTerm = "", int pTypeId = 0);
        Task<IEnumerable<PType>> PTypes();
    }
}