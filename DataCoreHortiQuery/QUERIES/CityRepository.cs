using DomainCoreHortiCommand;
using DataCoreHortiQuery.IQUERIES;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataCoreHortiCommand;

namespace DataCoreHortiQuery.QUERIES
{
    public class CityRepository : ICityRepository, IDisposable
    {
        private readonly DBHORTICONTEXT dBHORTICONTEXT;

        public CityRepository(DBHORTICONTEXT _dBHORTICONTEXT)
        {
            dBHORTICONTEXT = _dBHORTICONTEXT;
        }

        public async Task<IEnumerable<City>> ListOfCities()
        {
            using (dBHORTICONTEXT)
            {
                return await dBHORTICONTEXT.City
                                           .OrderBy(x => x.Id.DsState)
                                           .Select(x => new City
                                           {
                                               IdCountry = x.IdCountry,
                                               IdState = x.IdState,
                                               IdCity = x.IdCity,
                                               DsCity = x.DsCity,
                                               CdCity = x.CdCity
                                           })
                                           .AsNoTracking().ToListAsync();
            }
        }

        public async Task<IEnumerable<City>> ListOfCities(int idPage, int idSize)
        {
            using (dBHORTICONTEXT)
            {
                return await dBHORTICONTEXT.City
                                           .OrderBy(x => x.Id.DsState)
                                           .Select(x => new City
                                           {
                                               IdCountry = x.IdCountry,
                                               IdState = x.IdState,
                                               IdCity = x.IdCity,
                                               DsCity = x.DsCity,
                                               CdCity = x.CdCity
                                           })
                                           .Skip(idPage * idSize)
                                           .Take(idSize)
                                           .AsNoTracking().ToListAsync();
            }
        }

        public async Task<City> GetCityByCode(int idCity)
        {
            return await dBHORTICONTEXT.City
                                       .Select(x => new City
                                       {
                                           IdCountry = x.IdCountry,
                                           IdState = x.IdState,
                                           IdCity = x.IdCity,
                                           DsCity = x.DsCity,
                                           CdCity = x.CdCity
                                       })
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync(x => x.IdCity == idCity);
        }

        public async Task<City> GetCityByName(string strCity)
        {
            return await dBHORTICONTEXT.City
                                       .Select(x => new City
                                       {
                                           IdCity = x.IdCity,
                                           DsCity = x.DsCity,
                                           CdCity = x.CdCity
                                       }).FirstOrDefaultAsync(x => x.DsCity == strCity);
        }

        public async void Dispose()
        {
            await dBHORTICONTEXT.DisposeAsync();
        }
    }
}
