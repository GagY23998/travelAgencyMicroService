using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.Common.Interfaces;

namespace TravelAgency.TravelService.Application.Commands.Handlers
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, object>
    {
        public DeleteCountryCommandHandler(IDbSession dbSession, ILogger<DeleteCountryCommandHandler> logger)
        {
            DbSession = dbSession;
            Logger = logger;
        }

        public IDbSession DbSession { get; }
        public ILogger<DeleteCountryCommandHandler> Logger { get; }

        public async Task<object> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            Logger.LogInformation("Deleting Country with id: {0}", request.Id);

            var result = await DbSession.UnitOfWork.CountryRepository.DeleteOneAsnyc(new { id = request.Id }, nameof(Country).ToLower());

            Logger.LogInformation("Deleting Country with id and got result: {0}", result);

            return result;
        }
    }
}
