using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.HotelService.Domain.Common
{
    public interface IGenericRepository<TEntity,TEntityDTO,TInsertRequest,TUpdateRequest,TSearchRequest>
        where TEntity : class
        where TEntityDTO : class
        where TInsertRequest : class
        where TUpdateRequest : class
        where TSearchRequest : class
    {
        TEntityDTO Add(TInsertRequest insertRequest);
        TEntityDTO Update(object Id,TUpdateRequest updateRequest);
        Task<IEnumerable<TEntityDTO>> Get(TSearchRequest searchRequest);
        TEntityDTO GetById(object Id);
        TEntityDTO Remove(object Id);
    }
}
