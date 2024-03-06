using CleanArchitectureDDD.App.DTOs.CarsDTOs;
using CleanArchitectureDDD.App.DTOs.ClientDTOs;
using CleanArchitectureDDD.App.Wrappers;
using CleanArchitectureDDD.Core.Entities;

namespace CleanArchitectureDDD.App.Interfaces
{
    public interface IClientService
    {
        Task<PagedResponse<List<GetAllClientResponse>>> GetAllAsync(int pageNumber, int pageSize);
        Task<Response<GetClientByIdResponse>> GetByIdAsync(Guid id);
        Task<Response<PostClientResponse>> PostAsync(PostClientRequest req);
        Task<Response<PutClientResponse>> PutAsync(PutClientRequest req); 
        Task<Response<Client>> DeleteAsync(Guid id);
        Task<Response<GetClientByIdResponse>> AddCarAsync(PostCarRequest req); 
    }
}
