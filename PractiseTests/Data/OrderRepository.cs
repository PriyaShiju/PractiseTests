using PractiseTests.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PractiseTests.ViewModels;

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
            //if (includeItems)
            //    return _context.Order.Include(o => o.Pro).thenInclude(p => p.Product).ToList();

            //else
                return _context.Order.ToList();
        }
        public Order GetOrderById(int Id)
        {
            return _context.Order.Where(o => o.OrderId == Id).FirstOrDefault();
        }
        public IEnumerable<OrderItemViewModel> GetItemsById(int Id)
        {
            //var UserInRole = db.UserProfiles.Join(db.UsersInRoles, u => u.UserId, uir => uir.UserId,
           //(u, uir) => new { u, uir }).
           //Join(db.Roles, r => r.uir.RoleId, ro => ro.RoleId, (r, ro) => new { r, ro })
           //.Select(m => new AddUserToRole
           //{
           //    UserName = m.r.u.UserName,
           //    RoleName = m.ro.RoleName
           //});

            var orderitems = _context.Order.Join(_context.OrderItem, o => o.OrderId, oi => oi.OrderId, (o, oi) => new { o, oi })
                .Join(_context.Product, r => r.oi.ProductId, p => p.ProductId, (r, p) => new { r, p })
                .Select(m => new OrderItemViewModel
                {
                    OrderId = m.r.o.OrderId,
                    OrderNo = m.r.o.OrderNo,
                    OrderDate = m.r.o.OrderDate,
                    OrderItemId = m.r.oi.OrderItemId,
                    ProductId = m.p.ProductId,
                    Name = m.p.Name,
                    CategoryCode = m.p.CategoryCode,                    
                    Price = m.p.Price,
                    TotPrice = m.r.oi.TotPrice,
                    Quantity = m.r.oi.Quantity,
                    Description = m.p.Description
                });

            return orderitems.ToList();
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
