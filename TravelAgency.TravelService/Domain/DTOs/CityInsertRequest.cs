using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TravelAgency.TravelService.Domain.DTOs
{
    public class CityInsertRequest
    {
        public IFormFile Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
