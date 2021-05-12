using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.UserService.Domain.Common
{
    public interface IGenericRepository<TEntity,TEntityDTO,TEntityInsertRequest,TEntityUpdateRequest,TEntitySearchRequest>
        where TEntity : class
        where TEntityDTO : class
        where TEntityInsertRequest : class
        where TEntityUpdateRequest : class
        where TEntitySearchRequest : class
    {
        TEntityDTO Add(TEntityInsertRequest insertRequest);
        TEntityDTO Update(object Id, TEntityUpdateRequest updateRequest);
        IEnumerable<TEntityDTO> Get(TEntitySearchRequest searchRequest);
        TEntityDTO GetById(object Id);
        TEntityDTO Remove(object Id);
    }
}
