using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.BLL.Interfaces;
using TestApp.DAL.EF;

namespace TestApp.BLL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        //Я ЮЗАЮ LINQ TO DATABASE!!!!
        private TestContext _testContext;
        public ProductRepository(TestContext testContext)
        {
                _testContext= testContext;
        }
        public void Create(Product product)
        {
            _testContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _testContext.SaveChanges();
        }

        public void Delete(Product product)
        {
            _testContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _testContext.SaveChanges();
        }

        public Product GetProduct(int id)
        {
            return _testContext.Products.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _testContext.Products.AsEnumerable();
        }

        public void Update(Product product)
        {
            _testContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _testContext.SaveChanges();
        }
    }
}
