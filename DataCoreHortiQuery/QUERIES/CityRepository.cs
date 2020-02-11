using APPDTOCOREHORTIQUERY.SIGNATURE;
using DataAccessCoreHortiCommand;
using DATACOREHORTIQUERY.IQUERIES;
using DomainCoreHortiCommand;
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

        public async Task<IEnumerable<City>> ListOfCities()
        {
            var listOfCities = new List<City>();
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                                                    TransactionScopeAsyncFlowOption.Enabled))
            {
                using (dBHORTICONTEXT)
                {
                    listOfCities = await dBHORTICONTEXT.City
                                               .OrderBy(x => x.Id.DsState)
                                               .Select(x => new City
                                               {
                                                   IdState = x.IdState,
                                                   IdCity = x.IdCity,
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

        public async Task<IEnumerable<City>> ListOfCitiesByQuantity(ConsultByQuantitySignature signature)
        {
            var listOfCities = new List<City>();
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                                                    TransactionScopeAsyncFlowOption.Enabled))
            {
                using (dBHORTICONTEXT)
                {
                    listOfCities = await dBHORTICONTEXT.City
                                               .OrderBy(x => x.Id.DsState)
                                               .Select(x => new City
                                               {
                                                   IdState = x.IdState,
                                                   DsCity = x.DsCity,
                                                   CdCity = x.CdCity
                                               })
                                               .AsNoTracking()
                                               .Skip(signature.Page * signature.Quantity)
                                               .Take(signature.Quantity)
                                               .OrderBy(x => x.DsCity).ToListAsync();
                }
                scope.Complete();
            }
            return listOfCities;
        }

        public async Task<IEnumerable<City>> ListOfCitiesByName(ConsultCityByIdNameSignature signature)
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
                                           .Where(x => x.DsCity.Contains(signature.DsCity))
                                           .Take(signature.Quantity)
                                           .OrderBy(x => x.DsCity).ToListAsync();
                }
            }
            return listOfCities;
        }

        public async Task<City> CityById(ConsultCityByIdNameSignature signature)
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
                                       .OrderBy(x => x.DsCity)
                                       .FirstOrDefaultAsync(x => x.IdCity == signature.IdCity);
                }
                scope.Complete();
            }
            return city;
        }

        public async Task<IEnumerable<City>> ListOfCitiesByState(ConsultCityByStateSignature signature)
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
                                       .Where(x => x.IdState == signature.IdState)
                                       .ToListAsync();
                }
                scope.Complete();
            }
            return listOfCities;
        }
    }
}
