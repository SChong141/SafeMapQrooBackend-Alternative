using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SafeMapQROOBackend.Dtos.Occupancy;
using SafeMapQROOBackend.Interfaces;
using SafeMapQROOBackend.Mappers;
using SafeMapQROOBackend.Models;

namespace SafeMapQROOBackend.Controllers
{
    [Route("api/occupancy")]
    [ApiController]
    public class OccupancyController : ControllerBase
    {
        private readonly IOccupancyRepository _occupancyRepo;
        private readonly IShelterRepository _shelterRepo;
        public OccupancyController(IOccupancyRepository occupancyRepo, IShelterRepository shelterRepo)
        {
            _occupancyRepo = occupancyRepo;
            _shelterRepo = shelterRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var occupations = await _occupancyRepo.GetAllAsync();

            var occupancyDTO = occupations.Select(s => s.ToOccupancyDTO());

            return Ok(occupancyDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var occupancy = await _occupancyRepo.GetByIdAsync(id);

            if (occupancy == null)
            {
                return NotFound();
            }

            return Ok(occupancy.ToOccupancyDTO());
        }

        [HttpPost]
        [Route("{shelterId}")]
        public async Task<IActionResult> Create([FromRoute] Guid shelterId, CreateOccupancyRequestDTO occupancyDTO)
        {
            var shelter = await _shelterRepo.ShelterExist(shelterId);

            if (shelter == null)
            {
                return BadRequest("Shelter does not exist");
            }

            var occupancyModel = occupancyDTO.ToOccupancyFromCreateDTO(shelterId);

            await _occupancyRepo.CreateAsync(occupancyModel);

            return CreatedAtAction(nameof(GetById), new { id = occupancyDTO }, occupancyModel.ToOccupancyDTO());
        }
    }
}