using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.TravelService.Domain.Common
{
    public interface IRepository<T> where T: class
    {
        public IDbConnection Connection { get;}
        Task<IEnumerable<T>> GetTAsync(DynamicParameters sqlParameters,IDbTransaction transaction, string tableName); 
        // Task<IEnumerable<T>> GetTIncludeAsync(Func<IDbConnection,IEnumerable<T>> func);
        Task<T> GetTByIdAsync(object sqlParameters, IDbTransaction transaction,string tableName);
        Task<T> InsertOneAsync(DynamicParameters sqlParameters, IDbTransaction transaction,string tableName);
        Task InsertManyAsync(DynamicParameters sqlParameters, IDbTransaction transaction,string tableName);
        Task<T> UpdateOneAsync(DynamicParameters sqlParameters, IDbTransaction transaction, string tableName);
        Task UpdateManyAsync(DynamicParameters sqlParameters, IDbTransaction transaction,string tableName);
        Task<int> DeleteOneAsnyc(object sqlParameters,string tableName);
    }
}
