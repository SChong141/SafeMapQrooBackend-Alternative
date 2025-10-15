using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SafeMapQROOBackend.Data;

namespace SafeMapQROOBackend.Controllers
{
    [Route("api/alberges")]
    [ApiController]
    public class AlberguesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public AlberguesController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var alberges = _context.Albergues.ToList();

            return Ok(alberges);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var alberges = _context.Albergues.Find(id);

            if (alberges == null)
            {
                return NotFound();
            }

            return Ok(alberges);
        }
    }
}