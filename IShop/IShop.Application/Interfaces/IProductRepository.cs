using IShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShop.Application.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public IEnumerable<Product> GetProducts();

    }
}
