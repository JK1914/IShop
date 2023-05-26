using IShop.Application.Interfaces;
using IShop.Web.Common;
using IShop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IConfiguration _config;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(IProductRepository productRepository, IConfiguration config, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _config = config;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var entity = _productRepository.GetProducts();
            var categories = _categoryRepository.GetAll();
            var model = new HomeViewModel
            {
                Products = entity.Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Category = p.Category,
                    ApplicationType = p.ApplicationType,
                    Image = _config["ImagePath"] + p.Image,
                }).ToList(),
                Categories = categories.Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToList(),
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var cart = new List<ShoppingCart>();
            var sessionGet = HttpContext.Session.Get<List<ShoppingCart>>("SessionCart");
            if(sessionGet!=null && sessionGet.Count > 0)
            {
                cart = sessionGet;
            }
            var entity = _productRepository.GetProductById(id);

            var productDetails = new DetailsViewModel
            {
                Product = new ProductViewModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    Price = entity.Price,
                    Category = entity.Category,
                    ApplicationType=entity.ApplicationType,
                    Image = _config["ImagePath"] + entity.Image
                },
                IsExistsInCart = false
            };

            foreach(var item in cart)
            {
                if(item.ProductId == productDetails.Product.Id)
                {
                    productDetails.IsExistsInCart = true;
                }                
            }

            return View(productDetails);
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var shopCart = new List<ShoppingCart>();
            var sessionGet = HttpContext.Session.Get<List<ShoppingCart>>("SessionCart");
            if (sessionGet != null && sessionGet.Count > 0)
            {
                shopCart = sessionGet;
            }

            shopCart.Add(new ShoppingCart { ProductId = id});
            HttpContext.Session.Set("SessionCart", shopCart);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            var shopCart = new List<ShoppingCart>();
            var sessionGet = HttpContext.Session.Get<List<ShoppingCart>>("SessionCart");
            if (sessionGet != null && sessionGet.Count > 0)
            {
                shopCart = sessionGet;
            }

            var itemToRemove = shopCart.FirstOrDefault(x => x.ProductId == id);
            if(itemToRemove != null)
            {
                shopCart.Remove(itemToRemove);
            }

            HttpContext.Session.Set("SessionCart", shopCart);
            return RedirectToAction("Index");
        }
    }
}