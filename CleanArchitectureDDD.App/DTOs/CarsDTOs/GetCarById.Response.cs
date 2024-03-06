using CleanArchitectureDDD.Core.Entities;

namespace CleanArchitectureDDD.App.DTOs.CarsDTOs
{
    public class GetCarByIdResponse(Car car)
    {
        public Guid Id { get; set; } = car.Id; 
        public DateTime CreatedDate { get; set; } = car.CreatedDate; 
        public DateTime UpdatedDate { get; set; } = car.UpdatedDate; 
        public string Brand { get; set; } = car.Brand; 
        public double Mileage { get; set; } = car.Mileage; 

    }
}
