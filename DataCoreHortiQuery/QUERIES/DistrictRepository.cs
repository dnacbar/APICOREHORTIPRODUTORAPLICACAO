using DataCoreHortiQuery.IQUERIES;
using DomainCoreHortiCommand;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataCoreHortiCommand;

namespace DataCoreHortiQuery.QUERIES
{
    public class DistrictRepository : IDiscrictRepository
    {
        private readonly DBHORTICONTEXT dBHORTICONTEXT;

        public DistrictRepository(DBHORTICONTEXT _dBHORTICONTEXT)
        {
            dBHORTICONTEXT = _dBHORTICONTEXT;
        }

        public async Task<District> GetDistrict(Guid idDistrict)
        {
            return await dBHORTICONTEXT.District.OrderBy(x => x.DsName)
                                          .Select(x => new District
                                          {
                                              IdDistrict = x.IdDistrict,
                                              DsName = x.DsName,
                                              DtCreation = x.DtCreation,
                                              DtAtualization = x.DtAtualization,
                                              BoActive = x.BoActive,
                                          })
                                          .AsNoTracking()
                                          .FirstOrDefaultAsync(x => x.IdDistrict == idDistrict);
        }

        public async Task<IEnumerable<District>> GetDistricts()
        {
            return await dBHORTICONTEXT.District
                                       .OrderBy(x => x.DsName)
                                       .Select(x => new District
                                       {
                                           IdDistrict = x.IdDistrict,
                                           DsName = x.DsName,
                                           BoActive = x.BoActive,
                                           DtCreation = x.DtCreation,
                                           DtAtualization = x.DtAtualization
                                       })
                                       .AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<District>> GetDistricts(int idPage, int idSize)
        {
            return await dBHORTICONTEXT.District
                                       .OrderBy(x => x.DsName)
                                       .Select(x => new District
                                       {
                                           IdDistrict = x.IdDistrict,
                                           DsName = x.DsName,
                                           BoActive = x.BoActive,
                                           DtCreation = x.DtCreation,
                                           DtAtualization = x.DtAtualization
                                       })
                                       .Skip(idPage * idSize)
                                       .Take(idSize)
                                       .AsNoTracking().ToListAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
