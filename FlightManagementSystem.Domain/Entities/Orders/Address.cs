using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Domain.Entities.Orders
{
    public class Address
    {
        public Guid Id { get; set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string PostalCode { get; private set; }

        public Address(string city, string street, string postalCode)
        {
            this.City = city;
            this.Street = street;
            this.PostalCode = postalCode;
        }
    }
}
