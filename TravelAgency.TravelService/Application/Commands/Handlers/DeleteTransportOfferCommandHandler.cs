using AutoMapper;
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
    public class DeleteTransportOfferCommandHandler : IRequestHandler<DeleteTransportOfferCommand, object>
    {
        public DeleteTransportOfferCommandHandler(IMapper mapper, IDbSession dbSession)
        {
            Mapper = mapper;
            DbSession = dbSession;
        }

        public IMapper Mapper { get; }
        public IDbSession DbSession { get; }

        public async Task<object> Handle(DeleteTransportOfferCommand request, CancellationToken cancellationToken)
        {

            var result = await DbSession.UnitOfWork.TOfferRepository.DeleteOneAsnyc(new { id = request.Id }, nameof(TransportOffer).ToLower());
            return result;
        }
    }
}
