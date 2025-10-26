using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SafeMapQROOBackend.Data;
using SafeMapQROOBackend.Dtos.Shelter;
using SafeMapQROOBackend.Interfaces;
using SafeMapQROOBackend.Models;

namespace SafeMapQROOBackend.Repository
{
    public class ShelterRepository : IShelterRepository
    {
        private readonly ApplicationDBContext _context;
        public ShelterRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Shelter> CreateAsync(Shelter shelterModel)
        {
            await _context.Shelter.AddAsync(shelterModel);
            await _context.SaveChangesAsync();
            return shelterModel;
        }

        public async Task<Shelter?> DeleteAsync(int id)
        {
            var shelterModel = await _context.Shelter.FirstOrDefaultAsync(x => x.Id == id);

            if (shelterModel == null)
            {
                return null;
            }

            _context.Shelter.Remove(shelterModel);
            await _context.SaveChangesAsync();
            return shelterModel;
        }

        public async Task<List<Shelter>> GetAllAsync()
        {
            return await _context.Shelter.ToListAsync();
        }

        public async Task<Shelter?> GetByIdAsync(int id)
        {
            return await _context.Shelter.FindAsync(id);
        }

        public async Task<Shelter?> UpdateAsync(int id, UpdateShelterRequestDTO shelterDTO)
        {
            var existingShelter = await _context.Shelter.FirstOrDefaultAsync(x => x.Id == id);

            if (existingShelter == null)
            {
                return null;
            }

            existingShelter.Name = shelterDTO.Name;
            existingShelter.Latitude = shelterDTO.Latidude;
            existingShelter.Longitude = shelterDTO.Longitude;
            existingShelter.Capacity = shelterDTO.Capacity;
            existingShelter.Occupants = shelterDTO.Occupants;
            existingShelter.Address = shelterDTO.Address;
            existingShelter.Available = shelterDTO.Available;

            await _context.SaveChangesAsync();

            return existingShelter;
        }
    }
}