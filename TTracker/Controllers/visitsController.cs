using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TTracker.Models;

namespace TTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class visitsController : ControllerBase
    {
        private readonly TTrackerDbContext _context;

        public visitsController(TTrackerDbContext context)
        {
            _context = context;
        }

        // GET: api/visits/5/2018
        // GET: api/visits/touristId/visit.year
        [HttpGet("{id}/{year}")]
        public IEnumerable<Visit> GetTour([FromRoute] int id, int year)
        {
            return _context.Visits.Where(visit => visit.TouristId == id && visit.Date.Year == year);
        }

        // GET: api/visits/5/2018/05
        // GET: api/visits/touristId/visit.year/vist.mounth
        [HttpGet("{id}/{year}")]
        public IEnumerable<Visit> GetTour([FromRoute] int id, int year, int mounth)
        {
            return _context.Visits.Where(visit => visit.TouristId == id && visit.Date.Year == year);
        }

        // GET: api/visits/5/2018/05/12
        // GET: api/visits/touristId/visit.year/visit.mounth/vist.day
        [HttpGet("{id}/{year}")]
        public IEnumerable<Visit> GetTour([FromRoute] int id, int year, int mounth, int day)
        {
            return _context.Visits.Where(visit => visit.TouristId == id && visit.Date.Year == year);
        }
    }
}