using AutoMapper;
using Dapper;
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
    public class UpdateTransportTypeCommandHandler : IRequestHandler<UpdateTransportTypeCommand, TransportTypeDTO>
    {
        public UpdateTransportTypeCommandHandler(IMapper mapper, IDbSession dbSession)
        {
            Mapper = mapper;
            DbSession = dbSession;
        }

        public IMapper Mapper { get; }
        public IDbSession DbSession { get; }

        public async Task<TransportTypeDTO> Handle(UpdateTransportTypeCommand request, CancellationToken cancellationToken)
        {
            DynamicParameters dParams = DynamicParamConverter<TransportTypeInsertRequest>.UpdateAnonymouseObjectFromType(request.Id, request.TransportTypeInsertRequest);

            var result = await DbSession.UnitOfWork.TTypeRepository.UpdateOneAsync(dParams, DbSession.UnitOfWork.Transaction, nameof(TransportType).ToLower());

            var dto = Mapper.Map<TransportTypeDTO>(result);

            return dto;
        }
    }
}
