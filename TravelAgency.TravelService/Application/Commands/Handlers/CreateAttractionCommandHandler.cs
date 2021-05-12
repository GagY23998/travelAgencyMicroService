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
    public class CreateAttractionCommandHandler : IRequestHandler<CreateAttractionCommand, object>
    {
        public CreateAttractionCommandHandler(IMapper mapper, IDbSession dbSession, IConfiguration configuration)
        {
            Mapper = mapper;
            DbSession = dbSession;
            Configuration = configuration;
        }

        public IMapper Mapper { get; }
        public IDbSession DbSession { get; }
        public IConfiguration Configuration { get; }

        public async Task<object> Handle(CreateAttractionCommand request, CancellationToken cancellationToken)
        {
            DynamicParameters dParams = DynamicParamConverter<AttractionInsertRequest>.CreateAnonymouseObjectFromType(request.InsertRequest);

            var result = await DbSession.UnitOfWork.AttrRepository.InsertOneAsync(dParams, DbSession.UnitOfWork.Transaction, nameof(Attraction).ToLower());

            AttractionDTO dto = Mapper.Map<AttractionDTO>(result);

            return dto;
        }
    }
}
