using AutoMapper;
using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.Common;
using TravelAgency.TravelService.Domain.Common.Interfaces;
using TravelAgency.TravelService.Domain.DTOs;
using TravelAgency.TravelService.Infrastructure.Helper;
using TravelAgency.TravelService.Infrastructure.Repositories;

namespace TravelAgency.TravelService.Application.Commands.Handlers
{
    public class CreateTransportCompanyCommandHandler : IRequestHandler<CreateTransportCompanyCommand, TransportCompanyDTO>
    {

        public CreateTransportCompanyCommandHandler(IMapper mapper, IDbSession dbSession, IConfiguration configuration)
        {
            Mapper = mapper;
            DbSession = dbSession;
            Configuration = configuration;
        }
        public IMapper Mapper { get; }
        public IDbSession DbSession { get; }
        public IConfiguration Configuration { get; }

        public async Task<TransportCompanyDTO> Handle(CreateTransportCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                DynamicParameters dParams =  DynamicParamConverter<TransportCompanyInsertRequest>.CreateAnonymouseObjectFromType(request.InsertRequest);

                    var result = await DbSession.UnitOfWork.TCompanyRepository.InsertOneAsync(dParams, DbSession.UnitOfWork.Transaction, nameof(TransportCompany).ToLower());

                TransportCompanyDTO dto = Mapper.Map<TransportCompanyDTO>(result);

                return dto; 
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
