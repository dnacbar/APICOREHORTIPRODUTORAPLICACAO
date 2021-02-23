using HORTICOMMAND.DOMAIN.MODEL;
using System.Collections.Generic;
using System.Threading.Tasks;
using HORTICOMMAND.REPOSITORY;
using HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;

namespace HORTIQUERY.REPOSITORY
{
    public sealed class CityRepository : _BaseRepository<City>, ICityRepository
    {
        public CityRepository(DBHORTICONTEXT DBHORTICONTEXT) : base(DBHORTICONTEXT) { }

        public async Task<City> CityByIdOrName(ICityQuerySignature signature)
        {
            return await EntityByFilter(Where: p => signature.Id == p.IdCity || signature.City == p.DsCity,
                                        Select: x => new City
                                        {
                                            IdCity = x.IdCity,
                                            DsCity = x.DsCity,
                                            IdState = x.IdState
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

        public async Task<IEnumerable<City>> ListOfCities(ICityQuerySignature signature)
        {
            return await ListOfEntities(Where: x => (signature.City == null || x.DsCity.Contains(signature.City))
                                                 && (signature.Id == null || signature.Id == x.IdCity)
                                                 && (signature.IdState == null || signature.IdState == x.IdState),
                                        Select: p => new City
                                        {
                                            IdCity = p.IdCity,
                                            DsCity = p.DsCity,
                                            IdState = p.IdState
                                        },
                                        Page: signature.Page, 
                                        Quantity: signature.Quantity,
                                        OrderBy: o => o.DsCity);
        }
    }
}
