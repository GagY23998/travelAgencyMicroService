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
using TravelAgency.TravelService.Domain.Common.Interfaces;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Queries.Handlers
{
    public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, CountryDTO>
    {
        public GetCountryByIdQueryHandler(IMapper mapper, IDbSession session, IConfiguration configuration)
        {
            Mapper = mapper;
            Session = session;
            Configuration = configuration;
        }

        public IMapper Mapper { get; }
        public IDbSession Session { get; }
        public IUnitOfWork UnitOfWork { get; }
        public IConfiguration Configuration { get; }

        public async Task<CountryDTO> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {

            var result = await Session.UnitOfWork.CountryRepository.GetTByIdAsync(request.Id, UnitOfWork.Transaction, nameof(Country).ToLower());

            var dto = Mapper.Map<CountryDTO>(result);

            return dto;
        }
    }
}
