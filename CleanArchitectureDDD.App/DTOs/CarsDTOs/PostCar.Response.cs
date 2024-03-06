using CleanArchitectureDDD.Core.Entities;

namespace CleanArchitectureDDD.App.DTOs.CarsDTOs
{
    public class PostCarResponse(Car car)
    {
        public Guid Id { get; set; } = car.Id;
        public string Brand { get; set; } = car.Brand;
        public double Mileage { get; set; } = car.Mileage;
        public DateTime CreatedDate { get; set; } = car.CreatedDate;
    }
}
