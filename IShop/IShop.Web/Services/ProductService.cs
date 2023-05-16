using IShop.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IShop.Web.Services
{
    public class ProductService
    {
        private readonly ICategoryRepository _categoryRepository;
        public ProductService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
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
    }
}
