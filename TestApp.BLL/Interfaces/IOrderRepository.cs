using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.DAL.EF;

namespace TestApp.BLL.Interfaces
{
    public interface IOrderRepository
    {
        public CustomerOrder GetOrder(int id);
        public IEnumerable<CustomerOrder> GetOrders();
        public void Create(CustomerOrder order,List<OrderDetail> orderDetails);
        public void Update(CustomerOrder order);
        public void UpdateDetails(OrderDetail detail);
        public void CreateDetails(OrderDetail detail);
        public void Delete(CustomerOrder customerOrder);
        public void DeleteDetails(OrderDetail orderDetail);
    }
}
