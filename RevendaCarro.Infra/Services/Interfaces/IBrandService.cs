using System.Threading.Tasks;
using RevendaCarro.Domain.Models;
using RevendaCarro.Application.ViewModels;

namespace RevendaCarro.Infra.Services.Interfaces
{
    public interface IBrandService
    {
        Task<Brands> Add(BrandViewModel brandViewModel);
    }
}
