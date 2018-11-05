using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TTracker.Models;
using TTracker.Tools;

namespace TTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevController : ControllerBase
    {
        private readonly TTrackerDbContext _context;

        public DevController(TTrackerDbContext context)
        {
            _context = context;
        }

        // GET: api/dev/genvisits - generates fake visits data
        [HttpGet("genvisits/{chance}")]
        public IEnumerable<Visit> GenVisits([FromRoute] int chance)
        {
            List<Visit> tempVisits = new List<Visit>();
            Random random;

            foreach (Country country in _context.Countries)
            {
                random = new Random();
                RandomDateTime dateRandom = new RandomDateTime();

                foreach (Tourist tourist in _context.Tourists)
                {
                    bool doVisit = random.Next(1, 101) > (100 - chance);

                    if (doVisit)
                    {

                        tempVisits.Add(new Visit(tourist.Id, country.Id, dateRandom.Next(), $"Review from {tourist.Name} about {country.Name}"));
                    }
                }
            }
            _context.Visits.AddRange(tempVisits);
            _context.SaveChanges();

            return _context.Visits;
        }
    }
}