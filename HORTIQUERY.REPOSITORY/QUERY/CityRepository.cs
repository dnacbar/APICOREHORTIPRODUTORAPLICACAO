using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using HORTICOMMAND.REPOSITORY;
using DATACOREHORTIQUERY.IQUERIES;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.QUERIES
{
    public sealed class CityRepository : _BaseRepository<ICity>, ICityRepository
    {
        public CityRepository(DBHORTICONTEXT DBHORTICONTEXT) : base(DBHORTICONTEXT) { }
        
        public async Task<ICity> CityById(ConsultCitySignature signature)
        {
            return await EntityByFilter(Where: p => signature.IdCity == p.IdCity,
                                        Select: x => new ICity
                                        {
                                            IdState = x.IdState,
                                            DsCity = x.DsCity,
                                            CdCity = x.CdCity
                                        });
        }

        public async Task<IEnumerable<ICity>> FullListOfCities()
        {
            return await FullListOfEntities(Select: x => new ICity
            {
                IdCity = x.IdCity,
                DsCity = x.DsCity,
                IdState = x.IdState
            },
                                            OrderBy: p => p.DsCity);
        }

        public async Task<IEnumerable<ICity>> ListOfCities(ConsultCitySignature signature)
        {
            return await ListOfEntities(Where: x => (signature.DsCity == null || x.DsCity.Contains(signature.DsCity))
                                                 && (signature.IdCity == null || signature.IdCity == x.IdCity)
                                                 && (signature.IdState == null || signature.IdState == x.IdState),
                                        Select: p => new ICity
                                        {
                                            IdCity = p.IdCity,
                                            DsCity = p.DsCity,
                                            IdState = p.IdState
                                        }, signature.Page, signature.Quantity,
                                        OrderBy: o => o.DsCity);
        }
    }
}
