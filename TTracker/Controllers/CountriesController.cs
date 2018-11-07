using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TTracker.Models;

namespace TTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly TTrackerDbContext _context;

        public CountriesController(TTrackerDbContext context)
        {
            _context = context;
        }

        // GET: api/countries/all
        [HttpGet("all")]
        public IEnumerable<Country> GetCountries()
        {
            return _context.Countries;
        }

        // GET: api/countries/by/id/5
        [HttpGet("by/{id}")]
        public async Task<IActionResult> GetCountry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }
    }
}