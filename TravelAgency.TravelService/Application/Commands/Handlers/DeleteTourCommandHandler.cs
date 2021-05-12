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
    public class DeleteTourCommandHandler : IRequestHandler<DeleteTourCommand, object>
    {
        public DeleteTourCommandHandler(IMapper mapper, IDbSession dbSession)
        {
            Mapper = mapper;
            DbSession = dbSession;
        }

        public IMapper Mapper { get; }
        public IDbSession DbSession { get; }

        public async Task<object> Handle(DeleteTourCommand request, CancellationToken cancellationToken)
        {
            var result = await DbSession.UnitOfWork.TourRepository.DeleteOneAsnyc(request.Id, nameof(Tour).ToLower());

            return result;

        }
    }
}
