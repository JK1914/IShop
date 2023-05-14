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

            Random rnd = new Random();

            var applicationType = new ApplicationType
            {
                Name = model.Name                
            };
            _repository.Add(applicationType);
            return RedirectToAction("Index");
        }
    }
 
}
