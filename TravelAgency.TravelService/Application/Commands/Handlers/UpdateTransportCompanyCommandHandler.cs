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
    public class UpdateTransportCompanyCommandHandler : IRequestHandler<UpdateTransportCompanyCommand, TransportCompanyDTO>
    {
        public UpdateTransportCompanyCommandHandler(IMapper mapper, IDbSession dbSession)
        {
            Mapper = mapper;
            DbSession = dbSession;
        }

        public IMapper Mapper { get; }
        public IDbSession DbSession { get; }

        public async Task<TransportCompanyDTO> Handle(UpdateTransportCompanyCommand request, CancellationToken cancellationToken)
        {
            DynamicParameters dParams = DynamicParamConverter<TransportCompanyInsertRequest>.UpdateAnonymouseObjectFromType(request.Id, request.InsertRequest);

            var result = await DbSession.UnitOfWork.TCompanyRepository.UpdateOneAsync(dParams, DbSession.UnitOfWork.Transaction, nameof(TransportCompany).ToLower());
            TransportCompanyDTO dto = Mapper.Map<TransportCompanyDTO>(result);
            return dto;
        }
    }
}
