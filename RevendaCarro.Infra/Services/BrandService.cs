using System.Threading.Tasks;
using RevendaCarro.Domain.Models;
using RevendaCarro.Application.ViewModels;
using RevendaCarro.Infra.Services.Interfaces;
using RevendaCarro.Infra.Repositories.Interface;

namespace RevendaCarro.Infra.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<Brands> Add(BrandViewModel brandViewModel)
        {
            var brand = new Brands(
               brandViewModel.Name,
               brandViewModel.Status,
               brandViewModel.Id
           );

            return await _brandRepository.Add(brand);
        }

    }
}
