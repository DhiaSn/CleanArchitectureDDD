using CleanArchitectureDDD.App.Extensions;
using CleanArchitectureDDD.App.Interfaces;
using CleanArchitectureDDD.gRPC.Exentions;
using Grpc.Core;

namespace CleanArchitectureDDD.gRPC.Services
{
    public class ClientService : clientGrpc.clientGrpcBase
    {
        #region Local Variables + Constructor
        private readonly ILogger<ClientService> _logger;
        private readonly IClientService _clientService;

        public ClientService(IClientService clientService, ILogger<ClientService> logger)
        {
            _logger = logger;
            _clientService = clientService;
        }
        #endregion

        #region GetAll
        public override async Task<GetAllClientResponse> GetAll(GetAllClientRequest request, ServerCallContext context)
        {
            if (request.PageNumber == default)
                request.PageNumber = 1;
            if (request.PageSize == default)
                request.PageSize = 10;

            var clients = await _clientService.GetAllAsync(request.PageNumber, request.PageSize);

            GetAllClientResponse result = new();

            result.Clients.AddRange(clients.Data.ToCastedList(c => new GetAllClientItemResponse
            {
                Age = c.Age,
                PhoneNumber = c.PhoneNumber,
                Id = c.Id.ToString(),
            }));

            return await Task.FromResult(result);
        }
        #endregion

        #region GetById
        public override async Task<GetClientByIdResponse> GetById(ClientByIdRequest request, ServerCallContext context)
        {
            var client = await _clientService.GetByIdAsync(Guid.Parse(request.Id)) ?? throw new RpcException(new Status(StatusCode.NotFound, "Client not found"));

            GetClientByIdResponse result = new GetClientByIdResponse
            {
                Id = client.Data.Id.ToString(),
                Age = client.Data.Age,
                PhoneNumber = client.Data.PhoneNumber,
                CreatedDate = client.Data.CreatedDate.ToGrpcTimestamp(),
                UpdatedDate = client.Data.UpdatedDate.ToGrpcTimestamp()
            };
            result.Cars.AddRange(client.Data.Cars.ToCastedList(c => new GetCarByIdResponse
            {
                Brand = c.Brand,
                CreatedDate = c.CreatedDate.ToGrpcTimestamp(),
                Id = c.Id.ToString(),
                Mileage = c.Mileage,
                UpdatedDate = c.UpdatedDate.ToGrpcTimestamp(),
            }));

            return result;
        }
        #endregion

        #region Post
        public override async Task<PostClientResponse> Post(PostClientRequest request, ServerCallContext context)
        {
            var client = await _clientService.PostAsync(new App.DTOs.ClientDTOs.PostClientRequest
            {
                Age = request.Age,
                PhoneNumber = request.PhoneNumber,
            }) ?? throw new RpcException(new Status(StatusCode.Internal, "Problem in creating a new client"));

            return new PostClientResponse
            {
                Id = client.Data.Id.ToString(),
                Age = client.Data.Age,
                PhoneNumber = client.Data.PhoneNumber,
                CreatedDate = client.Data.CreatedDate.ToGrpcTimestamp(),
                UpdatedDate = client.Data?.UpdatedDate.ToGrpcTimestamp()
            };
        }
        #endregion

        #region Put
        public override async Task<PutClientResponse> Put(PutClientRequest request, ServerCallContext context)
        {
            var result = await _clientService.PutAsync(new App.DTOs.ClientDTOs.PutClientRequest
            {
                Age = request.Age,
                PhoneNumber = request.PhoneNumber,
                Id = Guid.Parse(request.Id)
            });

            return new PutClientResponse
            {
                Id = result.Data.Id.ToString(),
                Age = result.Data.Age,
                CreatedDate = result.Data.CreatedDate.ToGrpcTimestamp(),
                UpdatedDate = result.Data.UpdatedDate.ToGrpcTimestamp(),
                PhoneNumber = result.Data.PhoneNumber,
            };
        }
        #endregion

        #region Delete
        public override async Task<Empty> Delete(ClientByIdRequest request, ServerCallContext context)
        {
            var client = await _clientService.GetByIdAsync(Guid.Parse(request.Id)) ?? throw new RpcException(new Status(StatusCode.NotFound, "Client not found"));

            await _clientService.DeleteAsync(client.Data.Id);

            return new Empty();
        }
        #endregion

        #region AddCarAsync
        public override async Task<GetClientByIdResponse> AddCarAsync(PostCarRequest request, ServerCallContext context)
        {
            var client = await _clientService.AddCarAsync(new App.DTOs.CarsDTOs.PostCarRequest
            {
                Brand = request.Brand,
                ClientId = Guid.Parse(request.ClientId),
                Mileage = request.Mileage,
            }) ?? throw new RpcException(new Status(StatusCode.Internal, "Problem in adding car to this client!"));


            GetClientByIdResponse result = new GetClientByIdResponse
            {
                Id = client.Data.Id.ToString(),
                Age = client.Data.Age,
                PhoneNumber = client.Data.PhoneNumber,
                CreatedDate = client.Data.CreatedDate.ToGrpcTimestamp(),
                UpdatedDate = client.Data.UpdatedDate.ToGrpcTimestamp()
            };
            result.Cars.AddRange(client.Data.Cars.ToCastedList(c => new GetCarByIdResponse
            {
                Brand = c.Brand,
                CreatedDate = c.CreatedDate.ToGrpcTimestamp(),
                Id = c.Id.ToString(),
                Mileage = c.Mileage,
                UpdatedDate = c.UpdatedDate.ToGrpcTimestamp(),
            }));

            return result;
        }
        #endregion


    }
}
