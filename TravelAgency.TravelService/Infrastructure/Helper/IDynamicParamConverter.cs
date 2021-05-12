using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.TravelService.Infrastructure.Helper
{
    public interface IDynamicParamConverter<T> where T : class
    {
        Dictionary<string,DynamicParameters> GetAnonymousObjectFromType(T targetObject);
    }
}
