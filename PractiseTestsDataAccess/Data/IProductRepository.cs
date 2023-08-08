using PractiseTests.Data.Entities;

namespace PractiseTests.Data
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetProductById(int Id);
        bool SaveChanges();
    }
}