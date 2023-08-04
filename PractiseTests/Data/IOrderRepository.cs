using PractiseTests.Data.Entities;
using PractiseTests.ViewModels;

namespace PractiseTests.Data
{
    public interface IOrderRepository
    {
        void AddEntity(object model);
        IEnumerable<Order> GetAll();
        Order GetOrderById(int Id);
        IEnumerable<OrderItemViewModel> GetItemsById(int Id);
        bool SaveChanges();
    }
}