using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
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
    public class UpdateTransportReviewCommandHandler : IRequestHandler<UpdateTransportReviewCommand, TransportReviewDTO>
    {
        public UpdateTransportReviewCommandHandler(IMediator mediator, IMapper mapper, IDbSession dbSession, ILogger<UpdateTransportReviewCommandHandler> logger)
        {
            Mediator = mediator;
            Mapper = mapper;
            DbSession = dbSession;
            Logger = logger;
        }

        public IMediator Mediator { get; }
        public IMapper Mapper { get; }
        public IDbSession DbSession { get; }
        public ILogger<UpdateTransportReviewCommandHandler> Logger { get; }

        public async Task<TransportReviewDTO> Handle(UpdateTransportReviewCommand request, CancellationToken cancellationToken)
        {
            var dParams = DynamicParamConverter<TransportReviewInsertRequest>.UpdateAnonymouseObjectFromType(request.Id, request.TransportReviewInsertRequest);
            var result = await DbSession.UnitOfWork.TReviewRepository.UpdateOneAsync(dParams, DbSession.UnitOfWork.Transaction, nameof(TransportOffer).ToLower());

            var updatedObject = Mapper.Map<TransportReviewDTO>((TransportReview)result);

            return updatedObject;
        }
    }
}
