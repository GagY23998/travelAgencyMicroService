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

namespace TravelAgency.TravelService.Application.Queries.Handlers
{
    public class GetTransportCompanyByIdQueryHandler : IRequestHandler<GetTransportCompanyByIdQuery, TransportCompanyDTO>
    {
        public GetTransportCompanyByIdQueryHandler(IMapper mapper, IDbSession dbSession)
        {
            Mapper = mapper;
            DbSession = dbSession;
        }

        public IMapper Mapper { get; }
        public IDbSession DbSession { get; }

        public async Task<TransportCompanyDTO> Handle(GetTransportCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await DbSession.UnitOfWork.TCompanyRepository.GetTByIdAsync(request.Id, DbSession.UnitOfWork.Transaction,nameof(TransportCompany).ToLower());

            TransportCompanyDTO dto = Mapper.Map<TransportCompanyDTO>(result);
            return dto;
        }
    }
}
