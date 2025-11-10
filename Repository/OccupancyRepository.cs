using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SafeMapQROOBackend.Data;
using SafeMapQROOBackend.Interfaces;
using SafeMapQROOBackend.Models;

namespace SafeMapQROOBackend.Repository
{
    public class OccupancyRepository : IOccupancyRepository
    {
        private readonly ApplicationDBContext _context;
        public OccupancyRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Occupancy> CreateAsync(Occupancy occupancyModel)
        {
            await _context.Occupancy.AddAsync(occupancyModel);
            await _context.SaveChangesAsync();
            return occupancyModel;

        }

        public async Task<List<Occupancy>> GetAllAsync()
        {
            return await _context.Occupancy.ToListAsync();
        }

        public async Task<Occupancy?> GetByIdAsync(Guid id)
        {
            return await _context.Occupancy.FindAsync(id);
        }
    }
}