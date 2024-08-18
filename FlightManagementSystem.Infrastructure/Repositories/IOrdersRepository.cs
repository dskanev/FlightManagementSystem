using FlightManagementSystem.Application.Models.Output;
using FlightManagementSystem.Domain.Entities.Orders;
using FlightManagementSystem.Domain.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Infrastructure.Repositories
{
    public interface IOrdersRepository
    {
        Task CreateOrder(Order order);
        Task<IEnumerable<OrderOutputModel>> GetAllOrders();
        Task CreateProduct(Product product);
        Task<Product> GetProduct(Guid id);
        Task<IEnumerable<Product>> GetProducts(IList<Guid> ids);
        Task<IEnumerable<ProductOutputModel>> GetAllProducts();
        Task<Customer> GetCustomer(Guid id);
    }
}
