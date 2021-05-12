using AutoMapper;
using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
    public class CreateTransportOfferCommandHandler : IRequestHandler<CreateTransportOfferCommand,TransportOfferDTO>
    {
        public CreateTransportOfferCommandHandler(IMapper mapper, IDbSession dbSession, IConfiguration configuration, ILogger<CreateTransportOfferCommandHandler> logger)
        {
            Mapper = mapper;
            DbSession = dbSession;
            Configuration = configuration;
            Logger = logger;
        }

        public IMapper Mapper { get; }
        public IDbSession DbSession { get; }
        public IUnitOfWork UnitOfWork { get; }
        public IConfiguration Configuration { get; }
        public ILogger<CreateTransportOfferCommandHandler> Logger { get; }

        public async Task<TransportOfferDTO> Handle(CreateTransportOfferCommand request, CancellationToken cancellationToken)
        {
            try{

                Logger.LogInformation("Creating parameters for sql");
                DynamicParameters dParams = DynamicParamConverter<TransportOfferInsertRequest>.CreateAnonymouseObjectFromType(request.SqlParameters);

                Logger.LogInformation("Sending request to repository");
                var result = await DbSession.UnitOfWork.TOfferRepository.InsertOneAsync(dParams, DbSession.UnitOfWork.Transaction, nameof(TransportOffer).ToLower());
                Logger.LogInformation("Yielded result: {0}", result);
                TransportOfferDTO dto = Mapper.Map<TransportOfferDTO>(result);

                return dto;

            }catch(Exception e)
            {
                Logger.LogInformation(e.Message);
                return null;
            }
        }
    }
}

