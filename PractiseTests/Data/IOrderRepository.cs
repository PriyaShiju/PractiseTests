using PractiseTests.Data.Entities;

namespace PractiseTests.Data
{
    public interface IOrderRepository
    {
        void AddEntity(object model);
        IEnumerable<Order> GetAll();
        Order GetOrderById(int Id);
        bool SaveChanges();
    }
}