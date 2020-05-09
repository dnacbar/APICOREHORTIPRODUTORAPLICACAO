using APPDTOCOREHORTIQUERY.SIGNATURE;
using DataAccessCoreHortiCommand;
using DATACOREHORTIQUERY.IQUERIES;
using DOMAINCOREHORTICOMMAND;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.QUERIES
{
    public sealed class CityRepository : _BaseRepository<City>, ICityRepository
    {
        public CityRepository(DBHORTICONTEXT dBHORTICONTEXT) : base(dBHORTICONTEXT) { }
        public async Task<City> CityById(ConsultCitySignature signature)
        {
            return await EntityByFilter(Where: p => signature.IdCity == p.IdCity,
                                        Select: x => new City
                                        {
                                            IdState = x.IdState,
                                            DsCity = x.DsCity,
                                            CdCity = x.CdCity
                                        });
        }

        public async Task<IEnumerable<City>> FullListOfCities()
        {
            return await FullListOfEntities(Select: x => new City
            {
                IdCity = x.IdCity,
                DsCity = x.DsCity,
                IdState = x.IdState
            },
                                            OrderBy: p => p.DsCity);
        }

        public async Task<IEnumerable<City>> ListOfCities(ConsultCitySignature signature)
        {
            return await ListOfEntities(Where: x => (signature.DsCity == null || signature.DsCity == x.DsCity)
                                                 && (signature.IdCity == null || signature.IdCity == x.IdCity)
                                                 && (signature.IdState == null || signature.IdState == x.IdState),
                                        Select: p => new City
                                        {
                                            IdCity = p.IdCity,
                                            DsCity = p.DsCity,
                                            IdState = p.IdState
                                        }, signature.Page, signature.Quantity,
                                        OrderBy: o => o.DsCity);
        }
    }
}
