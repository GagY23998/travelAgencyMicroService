using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.Common;

namespace TravelAgency.TravelService.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbTransaction transaction;
        private IDbConnection connection;
        private IRepository<TransportCompany> tCompanyRepository;
        private IRepository<TransportOffer> tOfferRepository;
        private IRepository<TransportType> tTypeRepository;
        private IRepository<City> cityRepository;
        private IRepository<Tour> tourRepository;
        private IRepository<Attraction> attrRepository;
        private IRepository<Country> countryRepository;
        private IRepository<TransportReview> tReviewRepository;
        public UnitOfWork(IConfiguration configuration, 
                          IRepository<TransportCompany> tCompanyRepository,
                          IRepository<TransportOffer> tOfferRepository,
                          IRepository<TransportType> tTypeRepository,
                          IRepository<City> cityRepository,
                          IRepository<Attraction> attrRepository,
                          IRepository<TransportReview> tReviewRepository,
                          IRepository<Country> countryRepository)
        {
            Disposed = false;
            this.connection = new NpgsqlConnection(configuration.GetConnectionString("TravelServiceDB"));
            TCompanyRepository = tCompanyRepository;
            TOfferRepository = tOfferRepository;
            TTypeRepository = tTypeRepository;
            CityRepository = cityRepository;
            AttrRepository = attrRepository;
            TReviewRepository = tReviewRepository;
            CountryRepository = countryRepository;
            connection.Open();
        } 
        private bool Disposed { get; set; }

        public IDbConnection Connection { get { return connection; } set { connection = value; } }

        public IRepository<TransportCompany> TCompanyRepository { get => tCompanyRepository; set => tCompanyRepository = value; }
        public IRepository<TransportOffer> TOfferRepository { get => tOfferRepository; set => tOfferRepository = value; }
        public IRepository<TransportType> TTypeRepository { get => tTypeRepository; set => tTypeRepository = value; }
        public IRepository<City> CityRepository { get => cityRepository; set => cityRepository = value; }
        public IRepository<Attraction> AttrRepository { get => attrRepository; set => attrRepository = value; }
        public IDbTransaction Transaction { get => transaction; set => transaction = value; }
        public IRepository<Tour> TourRepository { get => tourRepository; set => tourRepository = value; }
        public IRepository<Country> CountryRepository { get => countryRepository; set => countryRepository = value; }
        public IRepository<TransportReview> TReviewRepository { get => tReviewRepository; set => tReviewRepository = value; }

        public void Dispose()
        {
            if (this.Disposed)
            {
                Transaction.Dispose();
                Disposed = true;
            }
        }

        public void BeginTransaction()
        {
            if(connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            Transaction = Connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            Transaction.Commit();
        }

        public void RollbackTransaction()
        {
            Transaction.Rollback();
        }
    }
}
