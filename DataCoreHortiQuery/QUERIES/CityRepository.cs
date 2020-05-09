using APPDTOCOREHORTIQUERY.SIGNATURE;
using DataAccessCoreHortiCommand;
using DATACOREHORTIQUERY.IQUERIES;
using DOMAINCOREHORTICOMMAND;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace DATACOREHORTIQUERY.QUERIES
{
    public sealed class CityRepository : ICityRepository
    {
        private readonly DBHORTICONTEXT dBHORTICONTEXT;

        public CityRepository(DBHORTICONTEXT _dBHORTICONTEXT)
        {
            dBHORTICONTEXT = _dBHORTICONTEXT;
        }

        public async Task<City> CityById(ConsultCitySignature signature)
        {
            var city = new City();
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                                                    TransactionScopeAsyncFlowOption.Enabled))
            {
                using (dBHORTICONTEXT)
                {
                    city = await dBHORTICONTEXT.City
                                               .Select(x => new City
                                               {
                                                   IdState = x.IdState,
                                                   DsCity = x.DsCity,
                                                   CdCity = x.CdCity
                                               })
                                               .AsNoTracking()
                                               .FirstOrDefaultAsync(x => signature.IdCity == x.IdCity);
                }
                scope.Complete();
            }
            return city;
        }

        public async Task<IEnumerable<City>> FullListOfCities()
        {
            var listOfCities = new List<City>();
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                                                    TransactionScopeAsyncFlowOption.Enabled))
            {
                using (dBHORTICONTEXT)
                {
                    listOfCities = await dBHORTICONTEXT.City
                                                       .Select(x => new City
                                                       {
                                                           IdState = x.IdState,
                                                           DsCity = x.DsCity,
                                                           CdCity = x.CdCity
                                                       })
                                                       .AsNoTracking()
                                                       .OrderBy(x => x.DsCity)
                                                       .ToListAsync();
                }
                scope.Complete();
            }
            return listOfCities;
        }

        public async Task<IEnumerable<City>> ListOfCities(ConsultCitySignature signature)
        {
            var listOfCities = new List<City>();
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                                                    TransactionScopeAsyncFlowOption.Enabled))
            {
                using (dBHORTICONTEXT)
                {
                    listOfCities = await dBHORTICONTEXT.City
                                                       .Where(x => (string.IsNullOrEmpty(signature.DsCity) || signature.DsCity == x.DsCity)
                                                                && (signature.IdCity == null || signature.IdCity == x.IdCity)
                                                                && (signature.IdState == null || signature.IdState == x.IdState))
                                               .Select(x => new City
                                               {
                                                   IdState = x.IdState,
                                                   DsCity = x.DsCity,
                                                   CdCity = x.CdCity
                                               })
                                               .AsNoTracking()
                                               .Skip(signature.Page * signature.Quantity)
                                               .Take(signature.Quantity)
                                               .OrderBy(x => x.DsCity)
                                               .ToListAsync();
                }
                scope.Complete();
            }
            return listOfCities;
        }
    }
}
