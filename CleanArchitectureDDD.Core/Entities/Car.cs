using CleanArchitectureDDD.Core.Common;

namespace CleanArchitectureDDD.Core.Entities
{
    public class Car : AuditableBaseEntity
    {
        public string Brand { get; set; }
        public double Mileage { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}
