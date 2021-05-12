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
using TravelAgency.TravelService.Domain.Common.Interfaces;
using TravelAgency.TravelService.Domain.DTOs;
using TravelAgency.TravelService.Infrastructure.Helper;

namespace TravelAgency.TravelService.Application.Commands.Handlers
{
    public class CreateTourCommandHandler : IRequestHandler<CreateTourCommand,TourDTO>
    {
        public CreateTourCommandHandler(IMapper mapper, IDbSession dbSession, IConfiguration configuration)
        {
            Mapper = mapper;
            DbSession = dbSession;
            Configuration = configuration;
        }

        public IMapper Mapper { get; }
        public IDbSession DbSession { get; }
        public IConfiguration Configuration { get; }

        public async Task<TourDTO> Handle(CreateTourCommand request, CancellationToken cancellationToken)
        {
            DynamicParameters dParams = DynamicParamConverter<TourInsertRequest>.GetAnonymousObjectFromType(request.InsertRequest);

            var result = await DbSession.UnitOfWork.TourRepository.InsertOneAsync(dParams, DbSession.UnitOfWork.Transaction, nameof(Tour).ToLower());

            TourDTO dto = Mapper.Map<TourDTO>(result);
            return dto;

        }
    }
}
