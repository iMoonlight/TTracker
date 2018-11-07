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

        // GET: api/dev/visits/gen/chance - generates fake visits data
        [HttpGet("visits/gen/{chance}")]
        public IEnumerable<Visit> GenVisits([FromRoute] int chance)
        {
            List<Visit> tempVisits = new List<Visit>();
            Random random = new Random();

            foreach (Country country in _context.Countries)
            {
                bool doVisit = random.Next(0, 101) > (100 - chance);

                RandomDateTime dateRandom = new RandomDateTime();

                foreach (Tourist tourist in _context.Tourists)
                {
                    if (doVisit)
                    {
                        DateTime date = dateRandom.Next();
                        tempVisits.Add(new Visit(tourist.Id, country.Id, date, $"Review from {tourist.Name} about {country.Name} at " + date.ToShortDateString()));
                    }
                }
            }

            if (tempVisits.Count > 0)
            {
                _context.Visits.AddRange(tempVisits);
                _context.SaveChanges();
            }

            return _context.Visits;
        }
    }
}