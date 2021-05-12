using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.TravelService.Domain.Common
{
    public interface IUnitOfWork : IDisposable
    {
        public IDbConnection Connection { get; set; }
        public IDbTransaction Transaction { get; set; }
        public IRepository<TransportCompany> TCompanyRepository { get; set; }
        public IRepository<TransportOffer> TOfferRepository { get; set; }
        public IRepository<TransportType> TTypeRepository { get; set; }
        public IRepository<City> CityRepository { get; set; }
        public IRepository<Attraction> AttrRepository { get; set; }
        public IRepository<Tour> TourRepository { get; set; }
        public IRepository<TransportReview> TReviewRepository { get; set; }
        public IRepository<Country> CountryRepository { get; set; }

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
