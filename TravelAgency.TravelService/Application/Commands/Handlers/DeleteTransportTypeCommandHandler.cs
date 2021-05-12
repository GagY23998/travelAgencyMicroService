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
    public class DeleteTransportTypeCommandHandler : IRequestHandler<DeleteTransportTypeCommand, object>
    {
        public DeleteTransportTypeCommandHandler(IMapper mapper, IDbSession dbSession)
        {
            Mapper = mapper;
            DbSession = dbSession;
        }

        public IMapper Mapper { get; }
        public IDbSession DbSession { get; }

        public async Task<object> Handle(DeleteTransportTypeCommand request, CancellationToken cancellationToken)
        {

            var result = await DbSession.UnitOfWork.TTypeRepository.DeleteOneAsnyc(request.Id, nameof(TransportType).ToLower());
            return result;
        }
    }
}
