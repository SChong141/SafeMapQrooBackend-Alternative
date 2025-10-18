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

namespace SafeMapQROOBackend.Controllers
{
    [Route("api/shelters")]
    [ApiController]
    public class ShelterController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ShelterController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shelters = await _context.Shelter.ToListAsync();
            
            var shelterDTO = shelters.Select(s => s.ToShelterDTO());

            return Ok(shelters);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var shelters = await _context.Shelter.FindAsync(id);

            if (shelters == null)
            {
                return NotFound();
            }

            return Ok(shelters.ToShelterDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateShelterRequestDTO shelterDTO)
        {
            var shelterModel = shelterDTO.ToShelterFromCreateDTO();
            await _context.Shelter.AddAsync(shelterModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = shelterModel.Id }, shelterModel.ToShelterDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateShelterRequestDTO updateDTO)
        {
            var shelterModel = await _context.Shelter.FirstOrDefaultAsync(x => x.Id == id);

            if (shelterModel == null)
            {
                return NotFound();
            }

            shelterModel.Name = updateDTO.Name;
            shelterModel.Latitude = updateDTO.Latidude;
            shelterModel.Longitude = updateDTO.Longitude;
            shelterModel.Capacity = updateDTO.Capacity;
            shelterModel.Occupants = updateDTO.Occupants;
            shelterModel.Address = updateDTO.Address;
            shelterModel.Available = updateDTO.Available;

            await _context.SaveChangesAsync();

            return Ok(shelterModel.ToShelterDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var shelterModel = await _context.Shelter.FirstOrDefaultAsync(x => x.Id == id);

            if (shelterModel == null)
            {
                return NotFound();
            }

            _context.Shelter.Remove(shelterModel);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}