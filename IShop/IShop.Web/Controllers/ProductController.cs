using IShop.Application.Interfaces;
using IShop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;        

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var entity = _productRepository.GetAll();
            var products = entity.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
            })
                .ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = _categoryRepository.GetAll();
            var products = new ProductViewModel
            {
                CategoryDropDown = categories.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                })
                .ToList()
            };
            return View(products);
        }
    }
}
