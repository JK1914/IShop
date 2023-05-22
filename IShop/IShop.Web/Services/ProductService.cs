using IShop.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IShop.Web.Services
{
    public class ProductService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IApplicationTypeRepository _applicationTypeRepository;
        public ProductService(ICategoryRepository categoryRepository, IApplicationTypeRepository applicationTypeRepository)
        {
            _categoryRepository = categoryRepository;
            _applicationTypeRepository = applicationTypeRepository;
        }

        public List<SelectListItem> GetCategoryList()
        {
            var categories = _categoryRepository.GetAll();
            var dropdown = categories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            })
                .ToList();
            return dropdown;
        }

        public List<SelectListItem> GetApplicationTypeList()
        {
            var appTypes = _applicationTypeRepository.GetAll();
            var dropdown = appTypes.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            })
                .ToList();
            return dropdown;
        }
    }
}
