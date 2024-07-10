using FlightManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Infrastructure.Data
{
    public class FlightRepository : IFlightRepository
    {
        private readonly ApplicationDbContext _context;

        public FlightRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Flight> GetByIdAsync(Guid id)
        {
            return await _context
                .Flights
                .Include(f => f.Passengers)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task UpdateAsync(Flight flight)
        {
            _context
                .Flights
                .Update(flight);

            await _context
                .SaveChangesAsync();
        }
    }
}
