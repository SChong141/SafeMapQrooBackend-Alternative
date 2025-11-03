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

namespace SafeMapQROOBackend.Controllers
{
    [Route("api/shelters")]
    [ApiController]
    public class ShelterController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IShelterRepository _shelterRepo;
        public ShelterController(ApplicationDBContext context, IShelterRepository shelterRepo)
        {
            _shelterRepo = shelterRepo;
            _context = context;
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