using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Threading.Tasks;
using TravelAgency.UserService.Domain.Common;
using TravelAgency.UserService.Infrastructure.Data;

namespace TravelAgency.UserService.Infrastructure.Repositories
{
    public class GenericRepository<TEntity, TEntityDTO,TEntityInsertRequest,TEntityUpdateRequest,TEntitySearchRequest>
        : IGenericRepository<TEntity, TEntityDTO,TEntityInsertRequest,TEntityUpdateRequest,TEntitySearchRequest>
        where TEntity : class
        where TEntityDTO : class
        where TEntityInsertRequest : class
        where TEntityUpdateRequest : class
        where TEntitySearchRequest : class
    {
        private readonly IMapper mapper;
        protected readonly UserDbContext _context;

        public GenericRepository(IMapper mapper, UserDbContext hotelDbContext)
        {
            this.mapper = mapper;
            this._context = hotelDbContext;
        }
        public TEntityDTO Add(TEntityInsertRequest insertRequest)
        {
            TEntity entity = mapper.Map<TEntity>(insertRequest);
            _context.Add(entity);
            _context.SaveChanges();

            return mapper.Map<TEntityDTO>(entity);
            
        }

        public IEnumerable<TEntityDTO> Get(TEntitySearchRequest searchRequest)
        {

            var query = _context.Set<TEntity>().AsQueryable();

            if (searchRequest == null) return mapper.Map<IEnumerable<TEntityDTO>>(query);

            query = SetInsertClause(query,searchRequest);
            query = SetWhereClause(query,searchRequest);


            List<TEntity> list = query.ToList();
            IEnumerable<TEntityDTO> result = mapper.Map<IEnumerable<TEntityDTO>>(list);
            
            return result;
        }

        public TEntityDTO GetById(object Id)
        {
            TEntity entity = _context.Find<TEntity>(Id);

            if (entity != null)
            {
                return mapper.Map<TEntityDTO>(entity);
            }
            return null;
        }


        public TEntityDTO Update(object Id, TEntityUpdateRequest updateRequest)
        {
            TEntity entity = _context.Find<TEntity>(Id);
            _context.Entry<TEntity>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            TEntity updatedEntity = mapper.Map<TEntity>(updateRequest);
            entity = updatedEntity;
            entity.GetType().GetProperty("Id").SetValue(entity,Id);
            _context.Update<TEntity>(entity);
            _context.SaveChanges();

            return mapper.Map<TEntityDTO>(entity);
        }
        private object GetDefaultTypeValue(Type myType)
        {
            if (myType.IsValueType && Nullable.GetUnderlyingType(myType) == null)
            {
                return Activator.CreateInstance(myType);
            }
            return null;
        }
        IQueryable<TEntity> SetWhereClause(IQueryable<TEntity> query,object searchObject,string childPropertyName="")
        {
            var properties = searchObject.GetType().GetProperties();

            foreach (var property in properties)
            {
                var myentity = Activator.CreateInstance<TEntity>();
                if (!myentity.GetType().GetProperties().Select(_ => _.Name).Contains(property.Name))
                {
                    continue;
                }


                var propertyType = property.PropertyType;
                var defaultVal = this.GetDefaultTypeValue(propertyType);
                var propertyValue = property.GetValue(searchObject, null);

                if (propertyValue == null) continue;
                if (propertyValue.Equals(defaultVal))
                {
                    continue;
                }
                var propertyName = childPropertyName != "" ? $"{childPropertyName}.{property.Name}" : property.Name;


                var value = property.PropertyType == typeof(string) ? $"\"{property.GetValue(searchObject, null)}\"" : property.GetValue(searchObject, null);

                query = query.Where($"{property.Name}={value}");

        }
            return query;
        }
        IQueryable<TEntity> SetInsertClause(IQueryable<TEntity> query,object searchObject)
        {
            var properties = typeof(TEntity).GetProperties().Where(_=>_.PropertyType.IsClass == true).ToList();
            foreach(var prop in properties){
                if(prop.PropertyType.IsClass == true && prop.PropertyType!= typeof(string)){
                    query = query.Include($"{prop.Name}");
                }
            }
            return query;
        }
        public TEntityDTO Remove(object Id)
        {
            var result = _context.Set<TEntity>().Find(Id);
            if (result != null)
            {
                
                _context.Remove(result);
                _context.SaveChanges();
                return mapper.Map<TEntityDTO>(result);
            }
                return null;
        }

    }
}
