using PractiseTests.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PractiseTests.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CertificationDbContext _context;
        public OrderRepository(CertificationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Order> GetAll()
        {
            return _context.Order.ToList();
        }

        public Order GetOrderById(int Id)
        {
            return _context.Order.Where(o => o.OrderId == Id).FirstOrDefault();
        }
        
        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void AddEntity(object model)
        {
            _context.Add(model);
        }
    }
}
