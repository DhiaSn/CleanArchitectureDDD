using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureDDD.App.DTOs.CarsDTOs
{
    public class PostCarRequest
    {
        public string Brand { get; set; }
        public double Mileage { get; set; }
        public Guid ClientId { get; set; }
    }
}
