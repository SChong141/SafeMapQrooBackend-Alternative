using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SafeMapQROOBackend.Data;
using SafeMapQROOBackend.Mappers;
using SafeMapQROOBackend.Models;
using SafeMapQROOBackend.Dtos.Shelter;
using Microsoft.EntityFrameworkCore;
using SafeMapQROOBackend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using SafeMapQROOBackend.Service;

namespace SafeMapQROOBackend.Controllers
{
    [Route("api/shelters")]
    [ApiController]
    public class ShelterController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IShelterRepository _shelterRepo;
        private readonly ILocationService _locationService;
        public ShelterController(ApplicationDBContext context, IShelterRepository shelterRepo, ILocationService locationService)
        {
            _context = context;
            _shelterRepo = shelterRepo;
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shelters = await _shelterRepo.GetAllAsync();

            var shelterDTO = shelters.Select(s => s.ToShelterDTO());

            return Ok(shelterDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var shelter = await _shelterRepo.GetByIdAsync(id);

            if (shelter == null)
            {
                return NotFound();
            }

            // return Ok(shelters.ToShelterDTO());
            return Ok(shelter);
        }

        [HttpGet]
        [Route("{lat},{lon}")]
        public async Task<IActionResult> GetNearest([FromRoute] double lat, double lon)
        {
            var allShelters = await _shelterRepo.GetAllAsync();

            // Find the nearest site using Haversine formula
            var nearestShelter = allShelters
            .Where(result => result.Deleted == false && (result.Occupancy.OrderByDescending(res => res.UpdatedOn)?.FirstOrDefault()?.CurrentOccupancy < result.Capacity || result.Occupancy!.Count() < 1))
            .Select(shelter => new
            {
                Shelter = shelter,
                Distance = _locationService.CalculateDistance(lat, lon, shelter.Latitude, shelter.Longitude)
            })
            
            .OrderBy(result => result.Distance) // Take the first (nearest) site
            .FirstOrDefault();

            if (nearestShelter == null)
            {
                return NotFound("No sites found.");
            }

            return Ok(nearestShelter);
        }

        [HttpGet("GetArea/{SupIzqLat:double},{SupIzqLon:double},{InfDerLat:double},{InfDerLon:double}")]
        public async Task<IActionResult> GetArea([FromRoute] double SupIzqLat, double SupIzqLon, double InfDerLat, double InfDerLon)
        {
            var shelterModel = await _shelterRepo.SheltersInArea(SupIzqLat, SupIzqLon, InfDerLat, InfDerLon);

            if (shelterModel == null || shelterModel.Count == 0)
            {
                return NotFound("No sites found.");
            }

            return Ok(shelterModel);
        }
        [HttpPost]
        
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateShelterRequestDTO shelterDTO)
        {
            var shelterModel = shelterDTO.ToShelterFromCreateDTO();

            await _shelterRepo.CreateAsync(shelterModel);

            return CreatedAtAction(nameof(GetById), new { id = shelterModel.Id }, shelterModel.ToShelterDTO());
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateShelterRequestDTO updateDTO)
        {
            var shelterModel = await _shelterRepo.UpdateAsync(id, updateDTO);

            if (shelterModel == null)
            {
                return NotFound();
            }

            return Ok(shelterModel.ToShelterDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var shelterModel = await _shelterRepo.DeleteAsync(id);

            if (shelterModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}