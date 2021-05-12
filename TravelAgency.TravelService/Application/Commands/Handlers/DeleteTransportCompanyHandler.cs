using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.Common.Interfaces;

namespace TravelAgency.TravelService.Application.Commands.Handlers
{
    public class DeleteTransportCompanyHandler : IRequestHandler<DeleteTransportCompanyCommand, object>
    {
        public DeleteTransportCompanyHandler(IMediator mediator, IDbSession dbSession)
        {
            Mediator = mediator;
            DbSession = dbSession;
        }

        public IMediator Mediator { get; }
        public IDbSession DbSession { get; }

        public async Task<object> Handle(DeleteTransportCompanyCommand request, CancellationToken cancellationToken)
        {

            var result = await DbSession.UnitOfWork.TReviewRepository.DeleteOneAsnyc(request.Id, nameof(TransportCompany).ToLower());

            return result;
        }
    }
}
