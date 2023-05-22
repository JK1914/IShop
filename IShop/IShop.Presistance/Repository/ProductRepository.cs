using IShop.Application.Interfaces;
using IShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShop.Presistance.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }        

        public IEnumerable<Product> GetProducts()
        {
            var products = _appDbContext.Products
                .Include(p => p.Category).Include(a=>a.ApplicationType);
            return products;
        }
    }
}
