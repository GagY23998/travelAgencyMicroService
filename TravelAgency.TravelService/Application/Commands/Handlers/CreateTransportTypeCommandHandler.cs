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
    public class CreateTransportTypeCommandHandler : IRequestHandler<CreateTransportTypeCommand,object>
    {
        public CreateTransportTypeCommandHandler(IMapper mapper, IDbSession dbSession, IConfiguration configuration)
        {
            Mapper = mapper;
            DbSession = dbSession;
            Configuration = configuration;
        }

        public IMapper Mapper { get; }
        public IDbSession DbSession { get; }
        public IConfiguration Configuration { get; }

        public async Task<object> Handle(CreateTransportTypeCommand request, CancellationToken cancellationToken)
        {
            DynamicParameters dParams = DynamicParamConverter<TransportTypeInsertRequest>.CreateAnonymouseObjectFromType(request.InsertRequest);
            var result = await DbSession.UnitOfWork.TTypeRepository.InsertOneAsync(dParams, DbSession.UnitOfWork.Transaction, nameof(TransportType).ToLower());

            TransportTypeDTO dto = Mapper.Map<TransportTypeDTO>(result);
            return dto;
        }
    }
}
