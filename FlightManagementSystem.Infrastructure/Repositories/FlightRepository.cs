using FlightManagementSystem.Domain.Entities;
using FlightManagementSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Infrastructure.Data
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightManagementContext _context;

        public FlightRepository(FlightManagementContext context)
        {
            _context = context;
        }

        public async Task<Flight> GetByIdAsync(int flightId)
        => await _context.Flights
                .Include(f => f.Passengers)
                .FirstOrDefaultAsync(f => f.Id == flightId);

        public async Task UpdateAsync(Flight flight)
        {            
            _context.Flights.Update(flight);
            await _context.SaveChangesAsync();
        }
    }

}
