using CleanArchitectureDDD.App.DTOs.CarsDTOs;
using CleanArchitectureDDD.App.Extensions;
using CleanArchitectureDDD.Core.Entities;

namespace CleanArchitectureDDD.App.DTOs.ClientDTOs
{
    public class GetClientByIdResponse(Client client)
    {
        public Guid Id { get; set; } = client.Id;
        public string PhoneNumber { get; set; } = client.PhoneNumber;
        public int Age { get; set; } = client.Age;
        public DateTime CreatedDate { get; set; } = client.CreatedDate;
        public DateTime UpdatedDate { get; set; } = client.UpdatedDate;
        public List<GetCarByIdResponse> Cars { get; set; } = client.Cars.ToCastedList(c => new GetCarByIdResponse(c)); 
    }
}
