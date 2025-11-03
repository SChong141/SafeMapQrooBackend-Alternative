using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SafeMapQROOBackend.Data;
using SafeMapQROOBackend.Dtos.Occupancy;
using SafeMapQROOBackend.Dtos.Shelter;
using SafeMapQROOBackend.Dtos.User;
using SafeMapQROOBackend.Interfaces;
using SafeMapQROOBackend.Models;

namespace SafeMapQROOBackend.Repository
{
    public class ShelterRepository : IShelterRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ShelterRepository(ApplicationDBContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Shelter> CreateAsync(Shelter shelterModel)
        {
            await _context.Shelter.AddAsync(shelterModel);
            await _context.SaveChangesAsync();
            return shelterModel;
        }

        public async Task<List<Shelter>> GetAllAsync()
        {
            return await _context.Shelter
                .Include(c => c.Occupancy)
                .Where(v => v.Deleted == false)
                .ToListAsync();
        }

        public async Task<ShelterDTO?> GetByIdAsync(Guid id)
        {
            var shelter = await _context.Shelter
                .Include(c => c.Occupancy)
                .Where(v => v.Deleted == false)
                .FirstOrDefaultAsync(i => i.Id == id);

            var organizer = await _userManager.Users.FirstOrDefaultAsync(u => u.AssignedShelter == shelter.Id);

            var response = new ShelterDTO
            {
                Id = shelter.Id,
                Name = shelter.Name,
                Latitude = shelter.Latitude,
                Longitude = shelter.Longitude,
                Capacity = shelter.Capacity,
                Address = shelter.Address,
                Municipality = shelter.Municipality,
                Available = shelter.Available,
                CreatedAt = shelter.CreatedAt,
                Occupancy = shelter.Occupancy.Select(o => new OccupancyDTO
                {
                    Id = o.Id,
                    CurrentOccupancy = o.CurrentOccupancy,
                    UpdatedOn = o.UpdatedOn,
                    ShelterId = o.ShelterId
                }).ToList(),
                Organizer = new UserDTO
                {
                    UserName = organizer.UserName,
                    PhoneNumber = organizer.PhoneNumber,
                    Email = organizer.Email
                }
            };

            return response;
        }

        public async Task<Shelter?> UpdateAsync(Guid id, UpdateShelterRequestDTO shelterDTO)
        {
            var existingShelter = await _context.Shelter.FirstOrDefaultAsync(x => x.Id == id);

            if (existingShelter == null || existingShelter.Deleted == true)
            {
                return null;
            }

            existingShelter.Name = shelterDTO.Name;
            existingShelter.Latitude = shelterDTO.Latidude;
            existingShelter.Longitude = shelterDTO.Longitude;
            existingShelter.Capacity = shelterDTO.Capacity;
            existingShelter.Address = shelterDTO.Address;
            existingShelter.Municipality = shelterDTO.Municipality;
            existingShelter.Available = shelterDTO.Available;

            await _context.SaveChangesAsync();

            return existingShelter;
        }

        public async Task<Shelter?> DeleteAsync(Guid id)
        {
            var shelterModel = await _context.Shelter.FirstOrDefaultAsync(x => x.Id == id);

            if (shelterModel == null)
            {
                return null;
            }

            shelterModel.Deleted = true;

            await _context.SaveChangesAsync();
            
            return shelterModel;
        }


        public async Task<Shelter?> ShelterExist(Guid id)
        {
            return await _context.Shelter.FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}