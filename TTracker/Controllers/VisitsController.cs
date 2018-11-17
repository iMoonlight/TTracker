using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TTracker.Models;

namespace TTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        private readonly TTrackerDbContext _context;

        List<Visit> unformatedVisits = new List<Visit>();

        public VisitsController(TTrackerDbContext context)
        {
            _context = context;
        }

        // GET: api/visits/yearsrange
        [HttpGet("yearsrange")]
        public YearsRange GetYearsRange()
        {
            HashSet<int> years = new HashSet<int>();
            years.UnionWith(_context.Visits.Select(v => v.Date.Year));

            if (years.Count < 1) return new YearsRange(2010, DateTime.Today.Year);

            return new YearsRange(years.Min(), years.Max());
        }

        // GET: api/visits/by/tourist/5/country/2/year/2010
        // GET: api/visits/by/tourist/tourist.id/country/country.id/year/visit.date.year
        [HttpGet("by/tourist/{tid}/country/{cid}/year/{year}")]
        public IEnumerable<FormatedVisit> GetVisitsBy([FromRoute] int tid, int cid, int year)
        {
            unformatedVisits.AddRange(_context.Visits);

            if (unformatedVisits.Count < 1) return new List<FormatedVisit>();

            if (tid > 0) unformatedVisits = unformatedVisits.Where(v => v.TouristId == tid).ToList();
            if (cid > 0) unformatedVisits = unformatedVisits.Where(v => v.CountryId == cid).ToList();
            if (year > 0) unformatedVisits = unformatedVisits.Where(v => v.Date.Year == year).ToList();

            return FormatVisits(unformatedVisits);
        }

        List<FormatedVisit> FormatVisits(List<Visit> unformatedVisits)
        {
            List<FormatedVisit> result = new List<FormatedVisit>();

            HashSet<int> uniqueTouristsIDs = new HashSet<int>();
            HashSet<int> uniqueCountriesIDs = new HashSet<int>();
            HashSet<int> uniqueYears = new HashSet<int>();

            uniqueTouristsIDs.UnionWith(unformatedVisits.Select(v => v.TouristId));
            uniqueCountriesIDs.UnionWith(unformatedVisits.Select(v => v.CountryId));
            uniqueYears.UnionWith(unformatedVisits.Select(v => v.Date.Year));

            List<Visit> visitsFiltered = new List<Visit>();
            List<string> reviews = new List<string>();

            int visitsCount = 0;

            foreach (int year in uniqueYears)
            {
                foreach(int countryId in uniqueCountriesIDs)
                {
                    foreach(int touristId in uniqueTouristsIDs)
                    {
                        visitsFiltered.Clear();
                        reviews.Clear();

                        visitsFiltered.AddRange(unformatedVisits.Where(v => v.TouristId == touristId && v.CountryId == countryId && v.Date.Year == year));

                        if (visitsFiltered.Count < 1) continue;

                        string touristName = _context.Tourists.Single(t => t.Id == touristId).Name;
                        string countryName = _context.Countries.Single(t => t.Id == countryId).Name;

                        reviews.AddRange(visitsFiltered.Select(v => v.TouristReview));

                        visitsCount = visitsFiltered.Count();

                        result.Add(new FormatedVisit(touristName, countryName,  year, reviews, visitsCount));
                    }
                }
            }

            return result;
        }
    }
}