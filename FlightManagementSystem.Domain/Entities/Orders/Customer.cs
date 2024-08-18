using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Domain.Entities.Orders
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public Address Address { get; private set; }

        private Customer()
        {
        }

        public Customer(string name, string phone, string email, Address address)
        {
            Name = name;
            Phone = phone;
            Email = email;

            Address = address;
        }
    }
}
