using CleanArchitectureDDD.App.DTOs.CarsDTOs;
using CleanArchitectureDDD.App.DTOs.ClientDTOs;
using CleanArchitectureDDD.App.Extensions;
using CleanArchitectureDDD.App.Interfaces;
using CleanArchitectureDDD.App.Wrappers;
using CleanArchitectureDDD.Core.Entities;
using CleanArchitectureDDD.Core.Repositories;
using CleanArchitectureDDD.Core.Specifications;
using CleanArchitectureDDD.Infrastructure.Data;

namespace CleanArchitectureDDD.App.Services
{
    public class ClientService(IClientRepository clientRepo) : IClientService
    {

        #region Local Variable + Constructor
        private readonly IClientRepository _clientRepo = clientRepo;
        #endregion

        #region GetAllAsync
        public async Task<PagedResponse<List<GetAllClientResponse>>> GetAllAsync(int pageNumber, int pageSize)
        {
            BaseSpecification<Client> spec = new();

            spec.ApplyPagging(pageSize, pageNumber);

            var clients = (await _clientRepo.GetAllAsync(spec)).ToCastedList(c => new GetAllClientResponse(c));

            return new PagedResponse<List<GetAllClientResponse>>(clients, pageNumber, pageSize, await _clientRepo.CountAsync(spec));
        }
        #endregion

        #region GetByIdAsync
        public async Task<Response<GetClientByIdResponse>> GetByIdAsync(Guid id)
        {
            BaseSpecification<Client> clientSpec = new(c => c.Id == id);

            clientSpec.AddInclude(c => c.Cars);

            Client client = await _clientRepo.GetByIdAsync(clientSpec);

            if (client == null)
                return new Response<GetClientByIdResponse>()
                {
                    Message = "Client doesn't exist...",
                    Succeeded = false,
                };

            return new Response<GetClientByIdResponse>
            {
                Data = new GetClientByIdResponse(client),
                Succeeded = true,
            };

        }
        #endregion

        #region PostAsync
        public async Task<Response<PostClientResponse>> PostAsync(PostClientRequest req)
        {
            Client client = new Client
            {
                PhoneNumber = req.PhoneNumber,
                Age = req.Age,
            };

            client = await _clientRepo.AddAsync(client);

            return new Response<PostClientResponse>
            {
                Data = new PostClientResponse(client),
                Succeeded = true,
                Message = "Success!"
            };
        }
        #endregion

        #region PutAsync
        public async Task<Response<PutClientResponse>> PutAsync(PutClientRequest req)
        {
            Client client = await _clientRepo.GetByIdAsync(req.Id);

            if (client == null)
                if (client == null)
                    return new Response<PutClientResponse>()
                    {
                        Message = "Clientdoesn't exist...",
                        Succeeded = false,
                    };

            client.Age = req.Age;
            client.PhoneNumber = req.PhoneNumber;

            await _clientRepo.UpdateAsync(client);

            return new Response<PutClientResponse>
            {
                Data = new PutClientResponse(client),
                Succeeded = true,
                Message = "Success!"
            };
        }
        #endregion

        #region DeleteAsync
        public async Task<Response<Client>> DeleteAsync(Guid id)
        {
            Client client = await _clientRepo.GetByIdAsync(id);

            if (client == null)
                return new Response<Client>
                {
                    Message = "Clientdoesn't exist...",
                    Succeeded = false,
                };

            await _clientRepo.DeleteAsync(client);

            return new Response<Client>
            {
                Succeeded = true,
            };
        }
        #endregion

        #region AddCarAsync
        public async Task<Response<GetClientByIdResponse>> AddCarAsync(PostCarRequest req)
        {
            BaseSpecification<Client> clientSpec = new(c => c.Id == req.ClientId);

            clientSpec.AddInclude(c => c.Cars);

            Client client = await _clientRepo.GetByIdAsync(clientSpec);

            if (client == null)
                return new Response<GetClientByIdResponse>()
                {
                    Message = "Client doesn't exist...",
                    Succeeded = false,
                };

            client.Cars.Add(new Car
            {
                Brand = req.Brand,
                Mileage = req.Mileage,
            }); 
            await _clientRepo.UpdateAsync(client);

            return await GetByIdAsync(req.ClientId);
        }
        #endregion
    }
}
