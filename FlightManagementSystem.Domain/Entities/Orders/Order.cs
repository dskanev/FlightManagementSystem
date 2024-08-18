using FlightManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightManagementSystem.Domain.Entities.Orders
{
    public class Order
    {
        public Guid Id { get; private set; }
        public DateTime Placed { get; private set; }
        public DateTime? Fulfilled { get; private set; }
        private readonly List<Product> _products = new List<Product>();
        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();
        public Customer Customer { get; private set; }
        public Guid? CustomerId { get; private set; }
        public OrderStatus Status { get; private set; }

        public double Total => _products.Sum(x => x.Price);
        public int Items => _products.Count;

        private Order() { }

        private Order(Guid? customerId, Customer customer)
        {
            Id = Guid.NewGuid();
            Placed = DateTime.UtcNow;
            Status = OrderStatus.New;

            if (customer != null)
            {
                Customer = customer;
                CustomerId = customer.Id;
            }
            else if (customerId.HasValue)
            {
                CustomerId = customerId.Value;
            }
            else
            {
                throw new ArgumentException("Either customer or customerId must be provided.");
            }
        }

        public static Order Create(Guid? customerId, Customer customer, IEnumerable<Product> products)
        {
            if (customer == null && !customerId.HasValue)
            {
                throw new ArgumentException("Either customer or customerId must be provided.");
            }

            var order = new Order(customerId, customer);

            foreach (var product in products)
            {
                order.AddProduct(product);
            }

            if (order.Items < 1)
            {
                throw new InvalidOperationException("At least one product is required to create an order.");
            }

            return order;
        }

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _products.Add(product);
        }

        public void ProcessOrder()
        {
            if (Status != OrderStatus.New)
            {
                throw new InvalidOperationException("Only new orders can be processed.");
            }

            Status = OrderStatus.Processing;
        }

        public void ShipOrder()
        {
            if (Status != OrderStatus.Processing)
            {
                throw new InvalidOperationException("Only processed orders can be shipped.");
            }

            Fulfilled = DateTime.UtcNow;
            Status = OrderStatus.ShippedToCustomer;
        }
    }
}
