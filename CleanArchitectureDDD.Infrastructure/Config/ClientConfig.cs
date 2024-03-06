using CleanArchitectureDDD.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureDDD.Infrastructure.Config
{
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasMany(c => c.Cars)
                   .WithOne(c => c.Client)
                   .HasForeignKey(c => c.ClientId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
