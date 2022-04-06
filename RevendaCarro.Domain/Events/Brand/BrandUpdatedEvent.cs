using MediatR;
using System.ComponentModel.DataAnnotations;

namespace RevendaCarro.Domain.Events.Brand
{
    public class BrandUpdatedEvent : INotification
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }
    }
}
