using AutoMapper;
using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.Common;
using TravelAgency.TravelService.Domain.DTOs;
using TravelAgency.TravelService.Infrastructure.Helper;

namespace TravelAgency.TravelService.Application.Queries.Handlers
{
    public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, IEnumerable<CityDTO>>
    {
        public GetCitiesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Configuration = configuration;
        }

        public IMapper Mapper { get; }
        public IUnitOfWork UnitOfWork { get; }
        public IConfiguration Configuration { get; }

        public async Task<IEnumerable<CityDTO>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
        {
            DynamicParameters dParams = DynamicParamConverter<CitySearchRequest>.GetAnonymousObjectFromType(request.SearchRequest);
          
            var result = await UnitOfWork.CityRepository.GetTAsync(dParams, UnitOfWork.Transaction,nameof(City).ToLower());
            var dto = Mapper.Map<IEnumerable<CityDTO>>(result);
            foreach(var city in dto){
                city.Image = Convert.ToBase64String(File.ReadAllBytes("Images/city/"+city.Name+".jpg"));
            }
            return dto;
        }
    }
}
