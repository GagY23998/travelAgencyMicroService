using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.Common;
using TravelAgency.TravelService.Domain.Common.Interfaces;
using TravelAgency.TravelService.Infrastructure.Repositories;

namespace TravelAgency.TravelService.Infrastructure.Data
{
    public class DbSession : IDisposable,IDbSession
    {
        public DbSession(IConfiguration configuration,IUnitOfWork unitOfWork)
        {
            connection = new NpgsqlConnection(configuration.GetConnectionString("TravelServiceDB"));
            this.UnitOfWork = unitOfWork;
        }

        private readonly IDbConnection connection;
        private IUnitOfWork unitOfWork;

        public IDbConnection Connection => connection;

        public IUnitOfWork UnitOfWork { get => unitOfWork; set => unitOfWork = value; }

        public void Dispose()
        {
            UnitOfWork.Dispose();
            Connection.Dispose();
        }
    }
}
