using Microsoft.Identity.Client;
using TestApp.DAL.EF;

namespace TestApp.PL.ViewModels
{
    public class ProductVM
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }

        public Product ConvertToProduct()
        {
            return new Product
            {
                Name = Name,
                Description = Description,
                Price = Price
            };
        }
    }
}
