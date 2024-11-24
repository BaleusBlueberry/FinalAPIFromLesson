using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public sealed class ProductsRepository(DALContext context) : Repository<Product>(context)
    {
        public override IEnumerable<Product> GetAll()
        {
            return context.Product.Include(p => p.Category);
        }
        public override Product? GetById(int id)
        {
            return context.Product.Include(p => p.Category).SingleOrDefault(P=>P.Id == id);
        }
    }
}
