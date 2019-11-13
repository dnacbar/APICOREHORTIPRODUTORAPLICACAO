using DataCoreHortiQuery.CONTEXT;
using DataCoreHortiQuery.IQUERIES;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataCoreHortiQuery.QUERIES
{
    public class CityRepository : ICityRepository, IDisposable
    {
        private readonly DBHORTICONTEXT _dBHORTICONTEXT;

        public CityRepository(DBHORTICONTEXT dBHORTICONTEXT)
        {
            _dBHORTICONTEXT = dBHORTICONTEXT;
        }

        public async Task<IEnumerable<City>> ListOfCities()
        {
            return await _dBHORTICONTEXT.City
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

        public async Task<City> GetCityByCode(int idCity)
        {
            return await _dBHORTICONTEXT.City
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

        public async void Dispose()
        {
            await _dBHORTICONTEXT.DisposeAsync();
        }
    }
}
