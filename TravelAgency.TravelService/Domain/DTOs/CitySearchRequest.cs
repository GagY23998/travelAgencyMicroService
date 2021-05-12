using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.TravelService.Domain.DTOs
{
    public class CitySearchRequest
    {
        public string Name { get; set; }
        public float FromRating { get; set; }
        public float ToRating { get; set; }
        public int CountryId {get; set;}
    }
}
