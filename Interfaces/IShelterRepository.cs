using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeMapQROOBackend.Dtos.Shelter;
using SafeMapQROOBackend.Models;

namespace SafeMapQROOBackend.Interfaces
{
    public interface IShelterRepository
    {
        Task<List<Shelter>> GetAllAsync();
        Task<Shelter?> GetByIdAsync(Guid id);
        Task<Shelter> CreateAsync(Shelter shelterModel);
        Task<Shelter?> UpdateAsync(Guid id, UpdateShelterRequestDTO shelterDTO);
        Task<Shelter?> DeleteAsync(Guid id);
    }
}