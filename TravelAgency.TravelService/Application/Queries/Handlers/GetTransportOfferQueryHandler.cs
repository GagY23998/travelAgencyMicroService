using AutoMapper;
using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
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
    public class GetTransportOfferQueryHandler : IRequestHandler<GetTransportOfferQuery, IEnumerable<TransportOfferDTO>>
    {
        public IMediator Mediator { get; }
        public IMapper Mapper { get; }
        public IUnitOfWork UnitOfWork { get; }
        public IConfiguration Configuration { get; }
        public ILogger<GetTransportOfferQueryHandler> Logger { get; }
        public GetTransportOfferQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration configuration, ILogger<GetTransportOfferQueryHandler> logger)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Configuration = configuration;
            Logger = logger;
        }


        public async Task<IEnumerable<TransportOfferDTO>> Handle(GetTransportOfferQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Logger.Log(LogLevel.Information,"Starting conversion of params at {0}", DateTime.Now);
                DynamicParameters dParams = DynamicParamConverter<TransportOfferSearchRequest>.GetAnonymousObjectFromType(request.SearchRequest);
                IEnumerable<TransportOffer> result;
                
                result = await UnitOfWork.TOfferRepository.GetTAsync(dParams,UnitOfWork.Transaction,nameof(TransportOffer).ToLower());
                
                Logger.LogInformation("Got result in count: {0}", result.Count());
                string destinationCityQuery = request.SearchRequest.CityId!=0?
                $"WHERE t1.cityid = {request.SearchRequest.CityId}":"";
                string query = "SELECT t1.*," +
                    "t2.id AS tcompanyId,t2.name,t2.cityid,t2.description,t2.transporttypeid," +
                    "t3.id AS cityId,t3.name,t3.description,t3.totalvisits,t3.rating FROM transportoffer t1 INNER JOIN transportcompany t2 ON (t1.transportcompanyid=t2.id)" +
                    "INNER JOIN city t3 ON(t2.cityid = t3.id)";
                Logger.LogInformation(destinationCityQuery);
                Logger.LogInformation(query);
                var dto = Mapper.Map<List<TransportOfferDTO>>(result);
                var oke = UnitOfWork.Connection.Query<TransportOffer, TransportCompany,City, TransportOffer>(query+ destinationCityQuery, (tOffer,tCompany,city)=> {
                        tOffer.TransportCompany = tCompany;
                        tCompany.City = city;
                     return tOffer;
                 }, param:dParams,splitOn:"tcompanyId,cityId");

                return Mapper.Map<IEnumerable<TransportOfferDTO>>(oke);
            }catch(Exception e)
            {
                Logger.LogError("Error happend at transportOfferQueryHandler at{0}, message{1}", DateTime.Now, e.Message);
            }
            return null;
        }
    }
}
