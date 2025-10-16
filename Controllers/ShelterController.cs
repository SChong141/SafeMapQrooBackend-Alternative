using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SafeMapQROOBackend.Data;
using SafeMapQROOBackend.Mappers;

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
        
        /*[HttpPost]
        public IActionResult Create([FromBody] CreateShelterRequest sheltersDto)
        {
            
        }*/       
    }
}