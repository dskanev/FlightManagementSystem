using FlightManagementSystem.Application.Models.Output;
using FlightManagementSystem.Domain.Entities.Orders;
using FlightManagementSystem.Domain.Models.Output;
using FlightManagementSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace FlightManagementSystem.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly FlightManagementContext _context;

        public OrdersRepository(FlightManagementContext context)
        {
            _context = context;
        }

        public async Task CreateOrder(Order order)
        {
            if (order.CustomerId == null)
            {
                await _context.AddAsync(order.Customer);
            }
            await _context.AddAsync(order);

            await _context.SaveChangesAsync();
        }

        public async Task CreateProduct(Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderOutputModel>> GetAllOrders()
        {
            return await _context
                .Orders
                .Include(x => x.Products)
                .Include(x => x.Customer)
                .Include(x => x.Customer.Address)
                .Select(x => new OrderOutputModel
            {
                CustomerEmail = x.Customer.Email,
                CustomerName = x.Customer.Name,
                CustomerPhone = x.Customer.Phone,
                Id = x.Id,
                Items = x.Products.Count,
                Total = x.Products.Sum(y => y.Price),
                Placed = x.Placed,
                City = x.Customer.Address.City
            }).ToListAsync();
        }

        public async Task<IEnumerable<ProductOutputModel>> GetAllProducts()
        {
            return await _context
                .Products
                .Select(x => new ProductOutputModel
                {
                    Id = x.Id,
                    Price = x.Price
                })
                .ToListAsync();
        }

        public async Task<Customer> GetCustomer(Guid id)
        {
            return await _context.Customers.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Product> GetProduct(Guid id)
        {
            return await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts(IList<Guid> ids)
        {
            return await _context.Products.Where(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}
