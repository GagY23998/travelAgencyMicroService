using AutoMapper;
using AutoMapper.Configuration;
using Dapper;
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
using TravelAgency.TravelService.Infrastructure.Helper;

namespace TravelAgency.TravelService.Application.Commands.Handlers
{
    public class CreateTransportReviewCommandHandler : IRequestHandler<CreateTransportReviewCommand, TransportReviewDTO>
    {
        public CreateTransportReviewCommandHandler(IMapper mapper, IDbSession dbSession, ILogger<CreateTransportReviewCommandHandler> logger)
        {
            Mapper = mapper;
            DbSession = dbSession;
            Logger = logger;
        }

        public IMapper Mapper { get; }
        public IDbSession DbSession { get; }
        public ILogger<CreateTransportReviewCommandHandler> Logger { get; }

        public async Task<TransportReviewDTO> Handle(CreateTransportReviewCommand request, CancellationToken cancellationToken)
        {
            try { 
            Logger.LogInformation("Creating parameters for sql");
            DynamicParameters dParams = DynamicParamConverter<TransportReviewInsertRequest>.CreateAnonymouseObjectFromType(request.TransportReviewInsertRequest);
            Logger.LogInformation("Sending request to repository");
            var result = await DbSession.UnitOfWork.TReviewRepository.InsertOneAsync(dParams, DbSession.UnitOfWork.Transaction, nameof(TransportReview).ToLower());
            Logger.LogInformation("Yielded result: {0}", result);
            TransportReviewDTO dto = Mapper.Map<TransportReviewDTO>(result);

            return dto;
       
            }catch(Exception e)
            {
                Logger.LogInformation(e.Message);
                return null;
            }
        }
    }
}
