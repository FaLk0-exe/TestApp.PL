using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.BLL.Dependency_Injection;
using TestApp.BLL.Interfaces;
using TestApp.DAL.EF;

namespace TestApp.BLL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private TestContext _testContext;
        public OrderRepository(TestContext testContext)
        {
            _testContext = testContext;
        }

        public CustomerOrder GetOrder(int id)
        {
            return _testContext.CustomerOrders.Include(co => co.OrderDetails).ThenInclude(od => od.Product).FirstOrDefault(co => co.Id == id);
        }

        public IEnumerable<CustomerOrder> GetOrders()
        {
            return _testContext.CustomerOrders.Include(co => co.OrderDetails).ThenInclude(od => od.Product).AsEnumerable();
        }

        public void Create(CustomerOrder order, List<OrderDetail> orderDetails)
        {
            _testContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _testContext.SaveChanges();
            foreach(var detail in orderDetails)
            {
                detail.CustomerOrderId = order.Id;
                _testContext.Entry(detail).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            _testContext.SaveChanges();
        }

        public void CreateDetails(OrderDetail detail)
        {
            _testContext.Entry(detail).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _testContext.SaveChanges();
        }

        public void Delete(CustomerOrder customerOrder)
        {
            _testContext.Entry(customerOrder).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _testContext.SaveChanges();
        }

        public void DeleteDetails(OrderDetail orderDetail)
        {
            _testContext.Entry(orderDetail).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _testContext.SaveChanges();
        }


        public void Update(CustomerOrder order)
        {
            _testContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _testContext.SaveChanges();
        }

        public void UpdateDetails(OrderDetail detail)
        {
            _testContext.Entry(detail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _testContext.SaveChanges();
        }
    }
}
