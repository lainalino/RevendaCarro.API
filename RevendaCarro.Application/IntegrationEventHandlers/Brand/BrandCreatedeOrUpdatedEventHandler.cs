using Rebus.Handlers;
using System.Threading.Tasks;
using RevendaCarro.Domain.Events.Brand;
using RevendaCarro.Domain.EventHandlers.Base;
using RevendaCarro.Domain.UnitOfWork.Interface;


namespace RevendaCarro.Domain.EventHandlers.Brand
{
    public class BrandCreatedeOrUpdatedEventHandler : EventHandlerBase, IHandleMessages<BrandCreatedEvent>,
        IHandleMessages<BrandUpdatedEvent>
    {
        public BrandCreatedeOrUpdatedEventHandler(IUofW uow) : base(uow) { }

        public async Task Handle(BrandCreatedEvent receivedEvent)
        {
            if (1 == 1)
            {
                //Entrou!
            }
        }

        public async Task Handle(BrandUpdatedEvent receivedEvent)
        {
           
        }

    }
}
