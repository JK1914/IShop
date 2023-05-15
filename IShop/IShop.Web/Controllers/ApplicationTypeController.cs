using IShop.Application.Interfaces;
using IShop.Domain.Entities;
using IShop.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace IShop.Web.Controllers
{
    public class ApplicationTypeController : Controller
    {
        public readonly IApplicationTypeRepository _repository;

        public ApplicationTypeController(IApplicationTypeRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var appTypes = _repository.GetAll();
            var model = appTypes.Select(a => new ApplicationTypeViewModel
            {
                Id = a.Id,
                Name = a.Name,
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
        public IActionResult Create(ApplicationTypeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }            

            var applicationType = new ApplicationType
            {
                Name = model.Name                
            };
            _repository.Add(applicationType);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var appType = _repository.GetById(id);
            var model = new ApplicationTypeViewModel { Name = appType.Name };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationTypeViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var appType = new ApplicationType
            {
                Id = model.Id,
                Name = model.Name
            };

            _repository.Update(appType);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var appType = _repository.GetById(id);
            _repository.Remove(appType);
            return RedirectToAction("Index");
        }
    }
 
}
