using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TTracker.Models;

namespace TTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class touristsController : ControllerBase
    {
        private readonly TTrackerDbContext _context;

        public touristsController(TTrackerDbContext context)
        {
            _context = context;
        }

        // GET: api/tourists
        [HttpGet]
        public IEnumerable<Tourist> GetTourists()
        {
            return _context.Tourists;
        }

        // GET: api/tourists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTourist([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tourist = await _context.Tourists.FindAsync(id);

            if (tourist == null)
            {
                return NotFound();
            }

            return Ok(tourist);
        }
    }
}