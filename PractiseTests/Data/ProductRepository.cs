using PractiseTests.Data.Entities;

namespace PractiseTests.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly CertificationDbContext _context;
        public ProductRepository(CertificationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int Id)
        {
            return _context.Products.Where(o => o.ProductId == Id).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
