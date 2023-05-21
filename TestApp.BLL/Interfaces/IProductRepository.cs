using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.DAL.EF;

namespace TestApp.BLL.Interfaces
{
    public interface IProductRepository
    {
        public Product GetProduct(int id);
        public IEnumerable<Product> GetProducts();
        public void Update(Product product);
        public void Delete(Product product);
        public void Create(Product product);
    }
}
