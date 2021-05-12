using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.Common;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Queries.Handlers
{
    public class GetAttractionByIdQueryHandler : IRequestHandler<GetAttractionByIdQuery, AttractionDTO>
    {
        public GetAttractionByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Configuration = configuration;
        }

        public IMapper Mapper { get; }
        public IUnitOfWork UnitOfWork { get; }
        public IConfiguration Configuration { get; }

        public async Task<AttractionDTO> Handle(GetAttractionByIdQuery request, CancellationToken cancellationToken)
        {

            var result = await UnitOfWork.AttrRepository.GetTByIdAsync(request.Id, UnitOfWork.Transaction,nameof(Attraction).ToLower());

            var dto = Mapper.Map<AttractionDTO>(result);

            return dto;
        }
    }
}
