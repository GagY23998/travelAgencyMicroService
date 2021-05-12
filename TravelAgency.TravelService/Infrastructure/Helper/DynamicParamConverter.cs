using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.TravelService.Infrastructure.Helper
{
    public static class DynamicParamConverter<T> where T : class
    {
        
        public static DynamicParameters GetAnonymousObjectFromType(T targetObject)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = targetObject.GetType().GetProperties();
            
            foreach (var prop in properties)
            {
                var objValue = prop.GetValue(targetObject);
                if (prop.PropertyType == typeof(string))
                {
                    if (string.IsNullOrEmpty((string)objValue)) continue;
                    dynamicParameters.Add(prop.Name, objValue);
                    continue;
                }
                object defaultValue = Activator.CreateInstance(prop.PropertyType);

                if (objValue!= null && !objValue.Equals(defaultValue))
                {
                    dynamicParameters.Add(prop.Name, objValue);
                }
            }
            return dynamicParameters;
        }

        public static DynamicParameters CreateAnonymouseObjectFromType(T insertObject)
        {
            Guid id = Guid.NewGuid();
            DynamicParameters dParams = new DynamicParameters();
      
            var properties = insertObject.GetType().GetProperties();
            dParams.Add("id", id);
            foreach (var prop in properties)
            {
                dParams.Add(prop.Name, prop.GetValue(insertObject));
            }
           
            return dParams;
        }

        public static DynamicParameters UpdateAnonymouseObjectFromType(object id, T targetObject)
        {
            DynamicParameters dParams = new DynamicParameters();

            var properties = targetObject.GetType().GetProperties();

            foreach (var prop in properties)
            {
                if (prop.GetValue(targetObject) != null)
                {
    
                    dParams.Add(prop.Name, prop.GetValue(targetObject));

                }
            }

            
            return dParams;
        }

        public static string GenerateSelectQuery(T targetObject){

            return typeof(T).GetProperties().Select(_=>_.Name).Aggregate((f1,f2) => f1+','+f2);
        }
    }
}
