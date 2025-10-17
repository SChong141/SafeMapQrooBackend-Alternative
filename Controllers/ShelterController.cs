using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SafeMapQROOBackend.Data;
using SafeMapQROOBackend.Mappers;
using SafeMapQROOBackend.Models;
using SafeMapQROOBackend.Dtos.Shelter;

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
        public IActionResult GetAll()
        {
            var shelters = _context.Shelter.ToList().Select(s => s.ToShelterDTO());

            return Ok(shelters);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var shelters = _context.Shelter.Find(id);

            if (shelters == null)
            {
                return NotFound();
            }

            return Ok(shelters.ToShelterDTO());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateShelterRequestDTO shelterDTO)
        {
            var shelterModel = shelterDTO.ToShelterFromCreateDTO();
            _context.Shelter.Add(shelterModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = shelterModel.Id }, shelterModel.ToShelterDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateShelterRequestDTO updateDTO)
        {
            var shelterModel = _context.Shelter.FirstOrDefault(x => x.Id == id);

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

            _context.SaveChanges();

            return Ok(shelterModel.ToShelterDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var shelterModel = _context.Shelter.FirstOrDefault(x => x.Id == id);

            if (shelterModel == null)
            {
                return NotFound();
            }

            _context.Shelter.Remove(shelterModel);

            _context.SaveChanges();

            return NoContent();
        }
    }
}