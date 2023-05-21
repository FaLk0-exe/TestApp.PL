using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using TestApp.BLL.Interfaces;
using TestApp.BLL.Services;
using TestApp.DAL.EF;
using TestApp.PL.ViewModels;

namespace TestApp.PL.Controllers
{

    public class ProductController : Controller
    {
        public ProductController()
        {
        }

        public ActionResult Get([FromServices] IProductRepository productRepository)
        {
            return View(productRepository.GetProducts());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult TryCreate([FromServices] ProductService productService, ProductVM model)
        {
            try
            {
                productService.CreateProduct(model.ConvertToProduct());
                return Redirect("Get");
            }
            catch (ArgumentException ex)
            {
                ViewData["Exception"] = ex.Message;
                return View("Create");
            }
        }

        public ActionResult Delete([FromServices] ProductService productService, int id)
        {
            try
            {
                productService.DeleteProduct(id);
                return Redirect("/product/get");
            }
            catch (InvalidOperationException ex)
            {
                return Redirect("/product/get");
            }
        }

        public ActionResult Update([FromServices] IProductRepository productRepository,
            [FromServices] ProductService productService, int id)
        {
            var product = productRepository.GetProduct(id);
            if (product is null)
            {
                return Redirect("/product/get");
            }
            return View(product);
        }

        public ActionResult TryUpdate([FromServices] ProductService productService,Product model)
        {
            try
            {
                productService.UpdateProduct(model);
                return Redirect("/product/get");
            }
            catch (ArgumentException ex) 
            {
                ViewData["Exception"] = ex.Message;
                return View("Update",model);
            }
        }
    }
}

