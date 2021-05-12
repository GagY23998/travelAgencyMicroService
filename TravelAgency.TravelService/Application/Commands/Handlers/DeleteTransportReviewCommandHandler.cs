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

namespace TravelAgency.TravelService.Application.Commands.Handlers
{
    public class DeleteTransportReviewCommandHandler  : IRequestHandler<DeleteTransportReviewCommand, int>
    {
        public DeleteTransportReviewCommandHandler(IMediator mediator, IDbSession dbSession, ILogger<DeleteTransportReviewCommandHandler> logger)
        {
            Mediator = mediator;
            DbSession = dbSession;
            Logger = logger;
        }

        public IMediator Mediator { get; }
        public IDbSession DbSession { get; }
        public ILogger<DeleteTransportReviewCommandHandler> Logger { get; }

        public async Task<int> Handle(DeleteTransportReviewCommand request, CancellationToken cancellationToken)
        {
            var result = await DbSession.UnitOfWork.TReviewRepository.DeleteOneAsnyc(request.Id, nameof(TransportReview).ToLower());

            return result;
        }
}
}
