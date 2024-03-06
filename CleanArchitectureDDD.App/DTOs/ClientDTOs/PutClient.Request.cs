using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureDDD.App.DTOs.ClientDTOs
{
    public class PutClientRequest
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
    }
}
