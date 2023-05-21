using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using TestApp.BLL.Interfaces;
using TestApp.DAL.EF;

namespace TestApp.BLL.Services
{
    public class ProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void CreateProduct(Product product)
        {
            try
            {
                Validate(product);
            }
            catch (ArgumentException)
            {
                throw;
            }

            _productRepository.Create(product);
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                Validate(product);
            }
            catch (ArgumentException)
            {
                throw;
            }
            _productRepository.Update(product);
        }

        public void DeleteProduct(int id)
        {
            var product = _productRepository.GetProduct(id);
            if (product is null)
                throw new InvalidOperationException($"Product with id {id} is not found");
            _productRepository.Delete(product);
        }

        public void Validate(Product product)
        {
            if (product is null || product.Name.IsNullOrEmpty())
            {
                throw new ArgumentException("product is null or fields of product is null");
            }
            if (product.Price < 0)
            {
                throw new ArgumentException("Price should be greater or equals 0");
            }
            if (product.Name.Length > 64 || (!product.Description.IsNullOrEmpty() && product.Description.Length > 256))
            {
                throw new ArgumentException("One of string fields was greater then max length value");
            }
        }
    }
}
