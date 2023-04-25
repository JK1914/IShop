using IShop.Application.Interfaces;
using IShop.Domain.Entities;
using IShop.Presistance.Repository;
using IShop.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace IShop.Web.Controllers
{
    public class CategoryController : Controller
    {
        public readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var categories = _repository.GetAll();
            var model = categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            })
                .ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }  
        
        [HttpPost]
        public IActionResult Create(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var category = new Category
            {
                Name = model.Name,
            };
            _repository.Add(category);
            return RedirectToAction("Index");
        }
    }
}
