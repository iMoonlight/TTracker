using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TTracker.Models;

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

            foreach (Tourist tourist in _context.Tourists)
            {
                random = new Random();

                foreach (Country country in _context.Countries)
                {
                    bool doVisit = random.Next(1, 101) > (100-chance);

                    int year = random.Next(2010, 2019);
                    int mounth = random.Next(1, 13);
                    int day = random.Next(1, 29);

                    if (doVisit)
                    {
                        DateTime date = Tools.StringToDate($"{day}/{mounth}/{year}", "uk-UA");

                        tempVisits.Add(new Visit(tourist.TouristId, country.CountryId, date, $"Згенерований відгук від {tourist.Name} про {country.Name}"));
                    }
                }
            }
            _context.Visits.AddRange(tempVisits);
            _context.SaveChanges();

            return _context.Visits;
        }
    }
}