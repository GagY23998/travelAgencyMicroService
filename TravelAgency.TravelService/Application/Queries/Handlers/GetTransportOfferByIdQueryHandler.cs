using AutoMapper;
using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
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
    public class GetTransportOfferByIdQueryHandler : IRequestHandler<GetTransportOfferByIdQuery, TransportOfferDTO>
    {
        public GetTransportOfferByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Configuration = configuration;
        }

        public IMapper Mapper { get; }
        public IUnitOfWork UnitOfWork { get; }
        public IConfiguration Configuration { get; }

        public async Task<TransportOfferDTO> Handle(GetTransportOfferByIdQuery request, CancellationToken cancellationToken)
        {

            var result = await UnitOfWork.TOfferRepository.GetTByIdAsync(request.Id, UnitOfWork.Transaction,nameof(TransportOffer).ToLower());
         
            var dto = Mapper.Map<TransportOfferDTO>(result);

            return dto;
        }
    }
}
