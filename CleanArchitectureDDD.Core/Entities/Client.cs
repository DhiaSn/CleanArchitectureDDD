using CleanArchitectureDDD.Core.Common;

namespace CleanArchitectureDDD.Core.Entities
{
    public class Client : AuditableBaseEntity
    {
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public ICollection<Car>? Cars { get; set; }
    }
}
