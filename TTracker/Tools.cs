using System;

namespace TTracker.Tools// Custom toolset
{
    class RandomDateTime
    {
        DateTime start;
        Random gen;
        readonly int range;

        public RandomDateTime()
        {
            start = new DateTime(2008, 1, 1);
            gen = new Random();
            range = (DateTime.Today - start).Days;
        }

        public DateTime Next()
        {
            return start.AddDays(gen.Next(range)).AddHours(gen.Next(0, 24)).AddMinutes(gen.Next(0, 60)).AddSeconds(gen.Next(0, 60));
        }
    }
}
