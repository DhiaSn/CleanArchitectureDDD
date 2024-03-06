using CleanArchitectureDDD.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureDDD.App.DTOs.ClientDTOs
{
    public class PutClientResponse(Client client)
    {
        public Guid Id { get; set; } = client.Id;
        public string PhoneNumber { get; set; } = client.PhoneNumber;
        public int Age { get; set; } = client.Age;
        public DateTime CreatedDate { get; set; } = client.CreatedDate;
        public DateTime UpdatedDate { get; set; } = client.UpdatedDate;
    }
}
