using AutoMapper;
using Microsoft.Extensions.Configuration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.Common;
using TravelAgency.TravelService.Domain.DTOs;
using TravelAgency.TravelService.Domain.Common.Interfaces;

namespace TravelAgency.TravelService.Application.Queries.Handlers
{
    public class GetTransportReviewByIdQueryHandler : IRequestHandler<GetTransportReviewByIdQuery, TransportReviewDTO>
    {
        public GetTransportReviewByIdQueryHandler(IMapper mapper, IDbSession session, IConfiguration configuration)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            Session = session;
            Configuration = configuration;
        }

        public IMapper Mapper { get; }
        public IDbSession Session { get; }
        public IUnitOfWork UnitOfWork { get; }
        public IConfiguration Configuration { get; }

        public async Task<TransportReviewDTO> Handle(GetTransportReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await Session.UnitOfWork.TReviewRepository.GetTByIdAsync(request, Session.UnitOfWork.Transaction, nameof(TransportReview).ToLower());

            var dto = Mapper.Map<TransportReviewDTO>(result);

            return dto;
        }
    }
}
