using MediatR;
using System.ComponentModel.DataAnnotations;

namespace RevendaCarro.Domain.Events.Brand
{
    [Display(Description = "Marca criada")]
    public class BrandCreatedEvent : INotification
    {
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }
    }
}
