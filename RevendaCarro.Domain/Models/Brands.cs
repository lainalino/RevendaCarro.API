using System;
using RevendaCarro.Domain.Entities;
using RevendaCarro.Domain.Events.Brand;

namespace RevendaCarro.Domain.Models
{
    public class Brands : Entity
    {
        public string Name { get; private set; }
        public bool Status { get; private set; }

        private Brands(int id) { }
        public Brands(string name, bool status, int id = 0)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome da marca é necessário");
            if (id == 0)
                AddDomainEvent(new BrandCreatedEvent { Name = name, Status = status });

            Id = id;
            Name = name;
            Status = status;

            AddDomainEvent(new BrandUpdatedEvent
            {
                Name = Name,
                Status = status,
                Id = id
            });
        }

    }
}
