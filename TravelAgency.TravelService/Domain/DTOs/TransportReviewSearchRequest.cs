using System;

namespace TravelAgency.TravelService.Domain.DTOs
{
    public class TransportReviewSearchRequest
    {
        public int TransportcompanyId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
       
    }
}