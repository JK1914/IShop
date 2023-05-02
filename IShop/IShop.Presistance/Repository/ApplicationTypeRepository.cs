using IShop.Application.Interfaces;
using IShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShop.Presistance.Repository
{
    public class ApplicationTypeRepository : GenericRepository<ApplicationType>, IApplicationTypeRepository
    {
        public ApplicationTypeRepository(AppDbContext context) : base(context)
        {

        }
    }
}
