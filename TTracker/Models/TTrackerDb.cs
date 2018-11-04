using System;
using System.Collections.Generic;
using System.Runtime.Serialization; // DataContract and DataMember from here. Used to hide Lists from serialization to JSON

namespace TTracker.Models
{
    [DataContract]
    public class Country
    {
        [DataMember]
        public int CountryId { get; set; }

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }

        public List<Visit> Visits { get; set; } = new List<Visit>(); //Only for autogeneration
    }

    [DataContract]
    public class Tourist
    {
        [DataMember]
        public int TouristId { get; set; }

        [DataMember]
        public string Name { get; set; }

        public List<Visit> Visits { get; set; } = new List<Visit>(); //Only for autogeneration
    }

    [DataContract]
    public class Visit
    {
        [DataMember]
        public int VisitId { get; set; }

        [DataMember]
        public int TouristId { get; set; }
        [DataMember]
        public int CountryId { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string TouristReview { get; set; }

        public Visit()
        {

        }

        public Visit(int touristId, int countryId, DateTime date, string touristReview)
        {
            TouristId = touristId;
            CountryId = countryId;
            Date = date;
            TouristReview = touristReview;
        }
    }
}
