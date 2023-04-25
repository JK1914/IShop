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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _repository.GetById(id);
            var model = new CategoryViewModel { Name = category.Name };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CategoryViewModel model)
        {
            if (!ModelState.IsValid) 
                return View(model);
            var category = new Category
            {
                Id = model.Id,
                Name = model.Name
            };

            _repository.Update(category);
            return RedirectToAction("Index");
        }

    }
}
