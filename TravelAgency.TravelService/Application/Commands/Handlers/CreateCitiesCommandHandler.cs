using AutoMapper;
using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.Common;
using TravelAgency.TravelService.Domain.Common.Interfaces;
using TravelAgency.TravelService.Domain.DTOs;
using TravelAgency.TravelService.Infrastructure.Helper;

namespace TravelAgency.TravelService.Application.Commands.Handlers
{
    public class CreateCitiesCommandHandler : IRequestHandler<CreateCityCommand, object>
    {
        public CreateCitiesCommandHandler(IMapper mapper, IDbSession dbSession, IConfiguration configuration)
        {
            Mapper = mapper;
            DbSession = dbSession;
            Configuration = configuration;
        }

        public IMapper Mapper { get; }
        public IDbSession DbSession { get; }
        public IUnitOfWork UnitOfWork { get; }
        public IConfiguration Configuration { get; }

        public async Task<object> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {

            DynamicParameters dParams = DynamicParamConverter<CityInsertRequest>.CreateAnonymouseObjectFromType(request.InsertRequest);


            var result = await DbSession.UnitOfWork.CityRepository.InsertOneAsync(dParams, DbSession.UnitOfWork.Transaction, nameof(City).ToLower());

            if(result!=null){
                using(FileStream ms = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory+"/Images/" + nameof(City).ToLower()+ result.Name),FileMode.Create)){
                    await request.InsertRequest.Image.CopyToAsync(ms);
                }
            }

            CityDTO dto = Mapper.Map<CityDTO>(result);

            return dto;
        }
    }
}
