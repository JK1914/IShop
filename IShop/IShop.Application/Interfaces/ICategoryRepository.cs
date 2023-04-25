using IShop.Domain.Entities;

namespace IShop.Application.Interfaces
{
    public interface ICategoryRepository
    {
        public void Add(Category category);

        public IEnumerable<Category> GetAll();
    }
}
