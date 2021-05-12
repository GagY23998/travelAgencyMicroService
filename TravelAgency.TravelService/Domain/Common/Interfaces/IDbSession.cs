using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.TravelService.Domain.Common.Interfaces
{
    public interface IDbSession
    {
        public IUnitOfWork UnitOfWork { get; set; }
    }
}
