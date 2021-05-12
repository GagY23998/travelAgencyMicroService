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
    public class UpdateAttractionCommandHandler : IRequestHandler<UpdateAttractionCommand, AttractionDTO>
    {
        public UpdateAttractionCommandHandler(IMapper mapper, IDbSession dbSession)
        {
            Mapper = mapper;
            DbSession = dbSession;
        }

        public IMapper Mapper { get; }
        public IDbSession DbSession { get; }

        public async Task<AttractionDTO> Handle(UpdateAttractionCommand request, CancellationToken cancellationToken)
        {

            DynamicParameters dParams = DynamicParamConverter<AttractionInsertRequest>.UpdateAnonymouseObjectFromType(request.Id, request.AttractionInsertRequest);

            var result = await DbSession.UnitOfWork.AttrRepository.UpdateOneAsync(dParams, DbSession.UnitOfWork.Transaction, nameof(Attraction).ToLower());

            AttractionDTO dto = Mapper.Map<AttractionDTO>(result);

            return dto;
        }
    }
}
