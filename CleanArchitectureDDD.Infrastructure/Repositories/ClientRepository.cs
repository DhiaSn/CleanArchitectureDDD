using CleanArchitectureDDD.Core.Entities;
using CleanArchitectureDDD.Core.Repositories;
using CleanArchitectureDDD.Infrastructure.Data;

namespace CleanArchitectureDDD.Infrastructure.Repositories
{
    public class ClientRepository(AppDbContext dbContext) : GenericRepository<Client>(dbContext), IClientRepository
    {
    }
}
