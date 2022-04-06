using System;
using System.Threading;
using System.Threading.Tasks;
using RevendaCarro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using RevendaCarro.Domain.UnitOfWork.Interface;

namespace RevendaCarro.Data.Context
{
    public class ApplicationDbContext : DbContext, IUofW
    {
        public DbSet<Brands> Brands { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            BrandModelBuilder(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void BrandModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brands>()
                           .HasKey(d => d.Id);
            modelBuilder.Entity<Brands>()
              .HasIndex(d => d.Id)
               .IsUnique();

            modelBuilder.Entity<Brands>()
                .Property(p => p.Name).HasMaxLength(80).IsRequired();
            modelBuilder.Entity<Brands>()
               .Property(p => p.Status).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
        public async Task SaveChanges(CancellationToken cancellationToken = default(CancellationToken))
        {
            await SaveChangesAsync();
        }
    }
}
