﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization; // DataContract and DataMember from here. Used to hide Lists from serialization to JSON

namespace TTracker.Models
{
    [DataContract]
    public class Country
    {
        [DataMember]
        public int Id { get; set; }

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
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        public List<Visit> Visits { get; set; } = new List<Visit>(); //Only for autogeneration
    }

    [DataContract]
    public class Visit
    {
        [DataMember]
        public int Id { get; set; }

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

    public class YearsRange
    {
        public int min;
        public int max;

        public YearsRange(int _min, int _max)
        {
            min = _min;
            max = _max;
        }
    }

    public class FormatedVisit
    {
        public string touristName;
        public string countryName;
        public int year;
        public List<string> reviews = new List<string>();
        public int visitsCount;

        public FormatedVisit(string tname, string cname, int _year, List<string> _reviews, int vcount)
        {
            touristName = tname;
            countryName = cname;
            year = _year;
            reviews.AddRange(_reviews);
            visitsCount = vcount;
        }
    }
}
