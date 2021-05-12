using System;

namespace Contracts
{
    public interface SubmitHotelCity // better to use interfaces for messaging than classes
    {
        public int CityId { get; set; }
    }
}
