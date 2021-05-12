using AutoMapper;
using Microsoft.Extensions.Configuration;
using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.Common;
using TravelAgency.TravelService.Domain.DTOs;
using TravelAgency.TravelService.Infrastructure.Helper;
using TravelAgency.TravelService.Domain.Common.Interfaces;

namespace TravelAgency.TravelService.Application.Queries.Handlers
{
    public class GetTransportReviewQueryHandler : IRequestHandler<GetTransportReviewQuery, IEnumerable<TransportReviewDTO>>
    {
        public GetTransportReviewQueryHandler(IMapper mapper, IDbSession session, IConfiguration configuration)
        {
            Mapper = mapper;
            Session = session;
            Configuration = configuration;
        }

        public IMapper Mapper { get; }
        public IDbSession Session { get; }
        public IConfiguration Configuration { get; }

        public async Task<IEnumerable<TransportReviewDTO>> Handle(GetTransportReviewQuery request, CancellationToken cancellationToken)
        {
            DynamicParameters dParams = DynamicParamConverter<TransportReviewSearchRequest>.GetAnonymousObjectFromType(request.SearchRequest);

            var result = await Session.UnitOfWork.TReviewRepository.GetTAsync(dParams, Session.UnitOfWork.Transaction, nameof(TransportReview).ToLower());

            var dto = Mapper.Map<IEnumerable<TransportReviewDTO>>(result);

            return dto;
        }

    }
}