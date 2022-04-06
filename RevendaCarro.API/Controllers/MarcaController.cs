using System;
using Microsoft.AspNetCore.Mvc;
using RevendaCarro.Domain.Events.Brand;
using RevendaCarro.Application.ViewModels;
using RevendaCarro.Infra.Services.Interfaces;
using Rebus.Bus;
using System.Threading.Tasks;

namespace RevendaCarro.API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/v1/[controller]")]
    public class MarcaController : Controller
    {

        private readonly IBus _bus;
        private readonly IBrandService _service;

        public MarcaController(IBus bus, IBrandService service)
        {
            _bus = bus;
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public async Task<ActionResult> Post(BrandViewModel brandViewModel)
        {
            await _service.Add(brandViewModel);

            //Publicando evento
            var @event = new BrandCreatedEvent()
            {
                Name = brandViewModel.Name,
                Status = brandViewModel.Status
            };

            await _bus.Publish(@event);

            return Ok();
        }

    }
}
