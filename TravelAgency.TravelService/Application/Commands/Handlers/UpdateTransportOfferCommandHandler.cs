using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.Common.Interfaces;
using TravelAgency.TravelService.Domain.DTOs;
using TravelAgency.TravelService.Infrastructure.Helper;

namespace TravelAgency.TravelService.Application.Commands.Handlers
{
    public class UpdateTransportOfferCommandHandler : IRequestHandler<UpdateTransportOfferCommand, TransportOfferDTO>
    {
        public UpdateTransportOfferCommandHandler(IMapper mapper, IDbSession dbSession)
        {
            Mapper = mapper;
            DbSession = dbSession;
        }

        public IMapper Mapper { get; }
        public IDbSession DbSession { get; }

        public async Task<TransportOfferDTO> Handle(UpdateTransportOfferCommand request, CancellationToken cancellationToken)
        {
            var dParams = DynamicParamConverter<TransportOfferInsertRequest>.UpdateAnonymouseObjectFromType(request.Id, request.SqlParameters);
            var result = await DbSession.UnitOfWork.TOfferRepository.UpdateOneAsync(dParams,DbSession.UnitOfWork.Transaction, nameof(TransportOffer).ToLower());

            var updatedObject = Mapper.Map<TransportOfferDTO>((TransportOffer)result);

            return updatedObject;
        }
    }
}
