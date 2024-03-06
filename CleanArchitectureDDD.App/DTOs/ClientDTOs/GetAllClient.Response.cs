using CleanArchitectureDDD.Core.Entities;

namespace CleanArchitectureDDD.App.DTOs.ClientDTOs
{
    public class GetAllClientResponse(Client client)
    {
        public Guid Id { get; set; } = client.Id;
        public string PhoneNumber { get; set; } = client.PhoneNumber;
        public int Age { get; set; } = client.Age;
    }
}
