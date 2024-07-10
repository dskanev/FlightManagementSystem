using FlightManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Infrastructure.Data
{
    public interface IFlightRepository
    {
        Task<Flight> GetByIdAsync(Guid id);
        Task UpdateAsync(Flight flight);
    }
}
