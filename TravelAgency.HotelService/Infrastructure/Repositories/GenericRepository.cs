using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Common;
using TravelAgency.HotelService.Infrastructure.Data;

namespace TravelAgency.HotelService.Infrastructure.Repositories
{
    public class GenericRepository<TEntity, TEntityDTO, TEntityCreateRequest, TEntityUpdateRequest, TEntitySearchRequest>
        : IGenericRepository<TEntity, TEntityDTO, TEntityCreateRequest, TEntityUpdateRequest, TEntitySearchRequest>
        where TEntity : class,new ()
        where TEntityDTO : class, new ()
        where TEntityCreateRequest : class
        where TEntityUpdateRequest : class
        where TEntitySearchRequest : class
    {
        private readonly IMapper mapper;
        private readonly HotelDbContext _context;

        public GenericRepository(IMapper mapper,HotelDbContext hotelDbContext)
        {
            this.mapper = mapper;
            this._context = hotelDbContext;
        }
        public TEntityDTO Add(TEntityCreateRequest insertRequest)
        {
            TEntity entity = mapper.Map<TEntity>(insertRequest);
            _context.Add(entity);
            _context.SaveChanges();

            return mapper.Map<TEntityDTO>(entity);
            
        }

        public virtual async Task<IEnumerable<TEntityDTO>> Get(TEntitySearchRequest searchRequest)
        {

            var query = _context.Set<TEntity>().AsQueryable();
           
            query = SetIncludeClause(query,searchRequest);
            query = await SetWhereClause(query,searchRequest);


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

        async Task<IQueryable<TEntity>> SetWhereClause(IQueryable<TEntity> query,object searchObject,string childPropertyName="")
        {
            var properties = searchObject.GetType().GetProperties();
            var myentity = Activator.CreateInstance<TEntity>();
            IEnumerable<string> entityProps = myentity.GetType().GetProperties().Select(_ => _.Name);
            foreach (var property in properties)
            {
                if (!entityProps.Contains(property.Name))
                {
                    continue;
                }
                object objValue = property.GetValue(searchObject);
                Type propertyType = property.PropertyType;
                
                if(propertyType== typeof(string))
                {
                    if (string.IsNullOrEmpty((string)objValue)) continue;
                }

                object defaultValue = Activator.CreateInstance(propertyType);
                if (objValue.Equals(defaultValue)) continue;
                
                if (!propertyType.IsValueType)
                {
                   childPropertyName = property.Name;
                   query = await SetWhereClause(query, objValue,childPropertyName);
                }

                var propertyName = childPropertyName != "" ? $"{childPropertyName}.{property.Name}" : property.Name;
                var value = propertyType == typeof(string)? $"\"{property.GetValue(searchObject,null)}\"" : property.GetValue(searchObject,null);
               
                if (propertyType != typeof(DateTime))

                {
                    query = query.Where($"{propertyName}=@0", value);
                }

               

            }
            return query;
        }
        IQueryable<TEntity> SetIncludeClause(IQueryable<TEntity> query,object searchObject)
        {

            var properties = typeof(TEntity).GetProperties().Where(_=>_.PropertyType != typeof(string)).ToList();
            foreach(var prop in properties){
                if((prop.PropertyType.IsClass || prop.PropertyType.IsInterface) && prop.PropertyType != typeof(string)){
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
