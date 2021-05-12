using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using TravelAgency.TravelService.Domain.Common;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;

namespace TravelAgency.TravelService.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T:class
    {
        public IDbConnection Connection { get;}
        public string TableName { get; set; }
        public ILogger<Repository<T>> Logger { get; }

        public Repository(IConfiguration configuration, ILogger<Repository<T>> logger)
        {
            Connection = new NpgsqlConnection(configuration.GetConnectionString("TravelServiceDB"));
            TableName = typeof(T).Name.ToLower();
            Logger = logger;
        }

        public async Task<IEnumerable<T>> GetTAsync(DynamicParameters sqlParameters,IDbTransaction transaction,string tableName)
        {
            try
            {
                if (sqlParameters == null) return await Connection.QueryAsync<T>($"SELECT * FROM {tableName};");
                string query = generateSearchQuery(sqlParameters);    
                return await Connection.QueryAsync<T>(query,sqlParameters,transaction);
            }catch(Exception e)
            {
                Logger.LogError("Error happend, Message:{0}", e.Message);
                throw e;
            }
        }

        public async Task<T> GetTByIdAsync(object sqlParameters, IDbTransaction transaction,string tableName)
        {
            return await Connection.QuerySingleAsync<T>($"SELECT * FROM {tableName} WHERE id=@id" , new { id = sqlParameters }, transaction);
        }

        public async Task<T> InsertOneAsync(DynamicParameters sqlParameters, IDbTransaction transaction,string tableName)
        {
            try
            {
                string insertSql = GenerateInsertQuery(tableName);
                var result =await Connection.ExecuteScalarAsync<T>(insertSql, sqlParameters);

                return result;

            }catch (Exception)
            {
                return null;
            }
        }

        public async Task InsertManyAsync(DynamicParameters sqlParameters, IDbTransaction transaction,string tableName)
        {
            try
            {
                string sqlCommand = "";

                await Connection.ExecuteAsync(sqlCommand);
            }catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<T> UpdateOneAsync(DynamicParameters sqlParameters, IDbTransaction transaction,string tableName)
        {
            string generatedQuery = GenerateUpdateOneQuery(sqlParameters);
            return await Connection.ExecuteScalarAsync<T>(generatedQuery, sqlParameters, transaction);
        }

        public async Task UpdateManyAsync(DynamicParameters sqlParameters, IDbTransaction transaction, string tableName)
        {
            string query = GenerateUpdateManyQuery((IEnumerable<T>)sqlParameters);
            await Connection.ExecuteAsync(query,sqlParameters, transaction: transaction);
        }


        public async Task<int> DeleteOneAsnyc(object sqlParameters,string tableName)
        {
            return await Connection.ExecuteAsync($"DELETE {nameof(T).ToLower()} WHERE id=@id", sqlParameters);
        }

      
        string GenerateUpdateOneQuery(DynamicParameters sqlParameters)
        {
            StringBuilder updateBuilder = new StringBuilder($"UPDATE {typeof(T).Name.ToLower()} as t1 SET ");


            var properties = typeof(T).GetProperties();

            foreach (var prop in properties)
            {
                if (prop.GetValue(sqlParameters) != null)
                {
                    updateBuilder.Append($"{prop.Name}= @{prop.Name},");
                }
            }
            updateBuilder.Remove(updateBuilder.Length - 1, 1);
            updateBuilder.Append(";");

            return updateBuilder.ToString();
        }

        string GenerateInsertQuery(string tableName)
        {
            StringBuilder insertQuery = new StringBuilder($"INSERT INTO {tableName} ");

            insertQuery.Append('(');

            var properties = typeof(T).GetProperties();

            foreach (var propertyName in properties)
            {
                insertQuery.Append($"{propertyName},");
            }
            insertQuery.Remove(insertQuery.Length-1,1).Append(") VALUES (");
            foreach (var prop in properties)
            {
                insertQuery.Append($@"{prop.Name},");
            }
            insertQuery.Remove(insertQuery.Length - 1, 1).Append(");");

            return insertQuery.ToString();
        }
        private string generateSearchQuery(DynamicParameters sqlParameters)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append($"SELECT * FROM {TableName} WHERE ");
            var properties = typeof(T).GetProperties();
            foreach (var prop in properties)
            {
                if (sqlParameters.ParameterNames.Contains(prop.Name))
                    if (prop.PropertyType == typeof(DateTime))
                    {
                        if(prop.Name.Contains("start",StringComparison.InvariantCultureIgnoreCase))
                        {
                            stringBuilder.Append($"{prop.Name}>@{prop.Name} AND ");
                        }
                        else
                        {
                            stringBuilder.Append($"{prop.Name}<@{prop.Name} AND ");
                        }

                    }
                    else
                    {
                        stringBuilder.Append($"{prop.Name}=@{prop.Name} AND ");

                    }
                

            }
            stringBuilder.Remove(stringBuilder.Length - 4, 3).Append(';');

            return stringBuilder.ToString().ToLower();
        }

        string GenerateUpdateManyQuery(IEnumerable<T> obj)
        {

            StringBuilder updateQuery = new StringBuilder($"UPDATE {typeof(T).Name.ToLower()} as t1 SET ");


            typeof(T).GetProperties().Select(_ => _.Name).ToList().ForEach(propName => updateQuery.Append($"{propName} = t2.{propName},"));

            updateQuery.Remove(updateQuery.Length - 1, 1);
            updateQuery.Append(")");

            var itemId = typeof(T).GetProperties().FirstOrDefault(_ => _.Name == "Id");

            updateQuery.Append("FROM (VALUES ");

            foreach (var item in obj)
            {
                updateQuery.Append("(");
                item.GetType().GetProperties().ToList()
                                              .ForEach(val=> updateQuery.Append($"{val.GetValue(val)},"));
                updateQuery.Remove(updateQuery.Length - 1, 1);
                updateQuery.Append("),");
            }
            updateQuery.Remove(updateQuery.Length - 1, 1);
            updateQuery.Append("as t2(");
            typeof(T).GetProperties().Select(_ => _.Name).ToList().ForEach(propName => updateQuery.Append($"{propName},"));
            updateQuery.Remove(updateQuery.Length - 1, 1);
            updateQuery.Append(")");
            updateQuery.Append($"WHERE t1.{itemId.Name} = t2.{itemId.Name}");

            return updateQuery.ToString();
        }

        
    }
}
