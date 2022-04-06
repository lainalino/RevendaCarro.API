using RevendaCarro.Data.Context;
using RevendaCarro.Domain.Models;
using RevendaCarro.Infra.Repositories.Interface;

namespace RevendaCarro.Infra.Repositories
{
    public class BrandRepository : RepositoryBase<Brands>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext context) : base(context) { }

    }
}
