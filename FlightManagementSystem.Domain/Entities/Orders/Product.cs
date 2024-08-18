using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Domain.Entities.Orders
{
    public class Product
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        private readonly List<Order> _orders = new List<Order>();
        public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();

        private Product() { }

        public Product(double price)
        {
            this.Price = price;
        }
    }
}
